using System.IO;
using System.Linq;
using System.Reflection;
using Com.Ericmas001.DependencyInjection.RegistrantFinders;
using SimplyAnIcon.Common.Helpers.Interfaces;
using SimplyAnIcon.Common.Models;
using SimplyAnIcon.Common.Services.Interfaces;
using SimplyAnIcon.Common.Settings.Interface;
using SimplyAnIcon.Plugins.V1;
using SimplyAnIcon.Plugins.Wpf.V1;

namespace SimplyAnIcon.Common.Services
{
    /// <summary>
    /// PluginService
    /// </summary>
    public class PluginService : IPluginService
    {
        private readonly IPluginSettings _pluginSettings;

        /// <summary>
        /// PluginService
        /// </summary>
        public PluginService(IPluginSettings pluginSettings)
        {
            _pluginSettings = pluginSettings;
        }

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
                    ActiveBackgroungPlugins = new ISimplyAPlugin[0],
                    ActiveForegroundPlugins = new ISimplyAWpfPlugin[0],
                    AllPlugins = new ISimplyAPlugin[0]
                };

            var excludedPrefix = new[]
            {
                "System.",
                "Microsoft.",
                "SimplyAnIcon.Plugins",
                "SimplyAnIcon.Common",
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

            var plugins = pTypes
                .Select(resolverHelper.Resolve)
                .Cast<ISimplyAPlugin>()
                .ToArray();

            var pluginSettings = _pluginSettings.GetPlugins().ToArray();

            foreach (var plugin in plugins)
            {
                if (pluginSettings.All(x => x.Name != _pluginSettings.GetPluginName(plugin)))
                _pluginSettings.AddPlugin(plugin);
            }

            var activePlugins = plugins
                .Select(x => new {Plugin = x, Setting = _pluginSettings.GetPluginSetting(x)})
                .Where(x => x.Setting?.IsActive ?? false)
                .OrderBy(x => x.Setting?.Order ?? -1)
                .Select(x => x.Plugin)
                .ToArray();

            return new PluginCatalog
            {
                AllPlugins = plugins,
                ActiveBackgroungPlugins = activePlugins.Where(p => !(p is ISimplyAWpfPlugin)).ToArray(),
                ActiveForegroundPlugins = activePlugins.OfType<ISimplyAWpfPlugin>().ToArray(),
            };
        }
    }
}
