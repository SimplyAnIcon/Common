using System.Collections.Generic;
using SimplyAnIcon.Plugins.V1;
using SimplyAnIcon.Plugins.Wpf.V1;

namespace SimplyAnIcon.Common.Models
{
    /// <summary>
    /// PluginCatalog
    /// </summary>
    public class PluginCatalog
    {
        /// <summary>
        /// PluginWpfInstances
        /// </summary>
        public IEnumerable<ISimplyAPlugin> AllPlugins { get; set; }

        /// <summary>
        /// PluginWpfInstances
        /// </summary>
        public IEnumerable<ISimplyAWpfPlugin> ActiveForegroundPlugins { get; set; }

        /// <summary>
        /// PluginInstances
        /// </summary>
        public IEnumerable<ISimplyAPlugin> ActiveBackgroungPlugins { get; set; }
    }
}
