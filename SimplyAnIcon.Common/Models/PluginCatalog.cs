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
        public IEnumerable<ISimplyAWpfPlugin> PluginWpfInstances { get; set; }

        /// <summary>
        /// PluginInstances
        /// </summary>
        public IEnumerable<ISimplyAPlugin> PluginInstances { get; set; }
    }
}
