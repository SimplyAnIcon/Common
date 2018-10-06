using System.Collections.Generic;
using SimplyAnIcon.Common.Models;
using SimplyAnIcon.Plugins.V1;

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
        bool IsActive(ISimplyAPlugin plugin);

        /// <summary>
        /// SetActivationStatus
        /// </summary>
        void SetActivationStatus(ISimplyAPlugin plugin, bool value);

        /// <summary>
        /// AddPlugin
        /// </summary>
        void AddPlugin(ISimplyAPlugin plugin);

        /// <summary>
        /// GetPlugins
        /// </summary>
        IEnumerable<PluginSettingEntry> GetPlugins();

        /// <summary>
        /// GetPluginName
        /// </summary>
        string GetPluginName(ISimplyAPlugin plugin);
    }
}
