using System.Collections.Generic;
using SimplyAnIcon.Common.Models;

namespace SimplyAnIcon.Common.Settings.Interface
{
    /// <summary>
    /// IPluginSettings
    /// </summary>
    public interface IPluginSettings
    {
        /// <summary>
        /// IsActive
        /// </summary>
        bool IsActive(string pluginName);

        /// <summary>
        /// SetActivationStatus
        /// </summary>
        void SetActivationStatus(string pluginName, bool value);

        /// <summary>
        /// AddPlugin
        /// </summary>
        void AddPlugin(string name);

        /// <summary>
        /// GetPlugins
        /// </summary>
        IEnumerable<PluginSettingEntry> GetPlugins();
    }
}
