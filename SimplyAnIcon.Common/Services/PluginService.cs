using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Com.Ericmas001.DependencyInjection.RegistrantFinders;
using SimplyAnIcon.Common.Helpers.Interfaces;
using SimplyAnIcon.Common.Models;
using SimplyAnIcon.Common.Services.Interfaces;
using SimplyAnIcon.Common.Settings.Interface;
using SimplyAnIcon.Plugins.V1;

namespace SimplyAnIcon.Common.Services
{
    /// <summary>
    /// PluginService
    /// </summary>
    public class PluginService : IPluginService
    {
        private readonly IPluginSettings _pluginSettings;
        private readonly IPluginBasicConfigHelper _pluginBasicConfigHelper;

        /// <summary>
        /// PluginService
        /// </summary>
        public PluginService(IPluginSettings pluginSettings, IPluginBasicConfigHelper pluginBasicConfigHelper)
        {
            _pluginSettings = pluginSettings;
            _pluginBasicConfigHelper = pluginBasicConfigHelper;
        }

        /// <summary>
        /// LoadPlugins
        /// </summary>
        public IEnumerable<PluginInfo> LoadPlugins(IEnumerable<PluginInfo> currentCatalog, IEnumerable<string> pluginPaths, IInstanceResolverHelper resolverHelper, RegistrantFinderBuilder registrantFinderBuilder = null, IEnumerable<string> forcedPlugins = null)
        {
            var registrantBuilder = registrantFinderBuilder ?? new RegistrantFinderBuilder();

            var forced = forcedPlugins?.ToArray() ?? new string[0];
            var catalog = currentCatalog ?? new PluginInfo[0];
            var dirs = pluginPaths.Select(x => new DirectoryInfo(x)).Where(x => x.Exists);
            var excludedPrefix = new[]
            {
                "System.",
                "Microsoft.",
                "SimplyAnIcon.Plugins",
                "SimplyAnIcon.Common",
                "netstandard.dll"
            };

            var dlls = dirs.SelectMany(dir => dir.GetFiles("*.dll", SearchOption.AllDirectories))
                .Where(d => excludedPrefix.All(x => !d.Name.StartsWith(x))).ToArray();

            if (!dlls.Any())
                return catalog;

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

            foreach (var plugin in plugins.Where(p => pluginSettings.All(x => x.Name != _pluginSettings.GetPluginName(p))))
                _pluginSettings.AddPlugin(plugin);

            var newCatalog = plugins
                .Select(x => new { Plugin = x, Setting = _pluginSettings.GetPluginSetting(x) })
                .OrderBy(x => x.Setting?.Order ?? -1)
                .Select(x => new PluginInfo
                {
                    Plugin = x.Plugin,
                    IsActivated = forced.Contains(x.Setting.Name) || (x.Setting?.IsActive ?? false),
                    IsNew = !catalog.Any(o => o.Plugin.Name == x.Plugin.Name)
                })
                .ToArray();

            foreach (var plugin in newCatalog.Where(x => x.IsNew))
                plugin.Plugin.OnInit(_pluginBasicConfigHelper.GetPluginBasicConfig());

            return newCatalog;
        }
    }
}
