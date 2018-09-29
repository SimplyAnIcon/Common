using System.IO;
using System.Linq;
using System.Reflection;
using Com.Ericmas001.DependencyInjection.RegistrantFinders;
using SimplyAnIcon.Common.Helpers.Interfaces;
using SimplyAnIcon.Common.Models;
using SimplyAnIcon.Common.Services.Interfaces;
using SimplyAnIcon.Plugins.V1;
using SimplyAnIcon.Plugins.Wpf.V1;

namespace SimplyAnIcon.Common.Services
{
    /// <summary>
    /// PluginService
    /// </summary>
    public class PluginService : IPluginService
    {
        /// <summary>
        /// LoadPlugins
        /// </summary>
        public PluginCatalog LoadPlugins(string pluginFolderPath, IInstanceResolverHelper resolverHelper, RegistrantFinderBuilder registrantFinderBuilder = null)
        {
            var registrantBuilder = registrantFinderBuilder ?? new RegistrantFinderBuilder();

            var dir = new DirectoryInfo(pluginFolderPath);
            if (!dir.Exists)
                return new PluginCatalog
                {
                    PluginInstances = new ISimplyAPlugin[0],
                    PluginWpfInstances = new ISimplyAWpfPlugin[0]
                };

            var excludedPrefix = new[]
            {
                "System.",
                "Microsoft.",
                "SimplyAnIcon.Plugins.",
                "netstandard.dll"
            };

            var dlls = dir.GetFiles("*.dll", SearchOption.AllDirectories)
                .Where(d => excludedPrefix.All(x => !d.Name.StartsWith(x))).ToArray();

            var assemblies = dlls.Select(x => Assembly.LoadFile(x.FullName)).ToList();
            assemblies.ForEach(x => registrantBuilder.AddAssembly(x));

            var pTypes = assemblies.SelectMany(x =>
                    x.DefinedTypes.Where(p =>
                        p.IsClass && !p.IsAbstract && typeof(ISimplyAPlugin).IsAssignableFrom(p)))
                .ToArray();

            resolverHelper.EverythingIsRegistered(registrantBuilder.Build().GetAllRegistrations());

            return new PluginCatalog
            {
                PluginInstances = pTypes.Where(p => !typeof(ISimplyAWpfPlugin).IsAssignableFrom(p))
                    .Select(resolverHelper.Resolve).Cast<ISimplyAPlugin>().ToArray(),

                PluginWpfInstances = pTypes.Where(p => typeof(ISimplyAWpfPlugin).IsAssignableFrom(p))
                    .Select(resolverHelper.Resolve).Cast<ISimplyAWpfPlugin>().ToArray()
            };
        }
    }
}
