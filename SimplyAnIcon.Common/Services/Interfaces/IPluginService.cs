using System.Collections.Generic;
using Com.Ericmas001.DependencyInjection.RegistrantFinders;
using SimplyAnIcon.Common.Helpers.Interfaces;
using SimplyAnIcon.Common.Models;

namespace SimplyAnIcon.Common.Services.Interfaces
{
    /// <summary>
    /// IPluginService
    /// </summary>
    public interface IPluginService
    {
        /// <summary>
        /// LoadPlugins
        /// </summary>
        PluginCatalog LoadPlugins(IEnumerable<string> pluginPaths, IInstanceResolverHelper resolverHelper, RegistrantFinderBuilder registrantFinderBuilder = null, IEnumerable<string> forcedPlugins = null);
    }
}
