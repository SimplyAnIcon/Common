using System.Collections.Generic;

namespace SimplyAnIcon.Common.Helpers.Interfaces
{
    /// <summary>
    /// IPluginBasicConfigHelper
    /// </summary>
    public interface IPluginBasicConfigHelper
    {
        /// <summary>
        /// GetPluginBasicConfig
        /// </summary>
        Dictionary<string, object> GetPluginBasicConfig();

        /// <summary>
        /// GetForcedPlugins
        /// </summary>
        IEnumerable<string> GetForcedPlugins();
    }
}
