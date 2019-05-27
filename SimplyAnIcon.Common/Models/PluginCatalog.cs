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
        /// AllPlugins
        /// </summary>
        public IEnumerable<ISimplyAPlugin> AllPlugins { get; set; }

        /// <summary>
        /// ActiveForegroundPlugins
        /// </summary>
        public IEnumerable<ISimplyAWpfPlugin> ActiveForegroundPlugins { get; set; }

        /// <summary>
        /// ActiveBackgroungPlugins
        /// </summary>
        public IEnumerable<ISimplyAPlugin> ActiveBackgroungPlugins { get; set; }

        /// <summary>
        /// NewActiveForegroundPlugins
        /// </summary>
        public IEnumerable<ISimplyAWpfPlugin> NewActiveForegroundPlugins { get; set; }

        /// <summary>
        /// NewActiveBackgroungPlugins
        /// </summary>
        public IEnumerable<ISimplyAPlugin> NewActiveBackgroungPlugins { get; set; }
    }
}
