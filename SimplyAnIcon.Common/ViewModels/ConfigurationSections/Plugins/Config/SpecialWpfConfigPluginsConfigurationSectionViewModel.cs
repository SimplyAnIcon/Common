using SimplyAnIcon.Common.Settings.Interface;
using SimplyAnIcon.Plugins.Wpf.V1;

namespace SimplyAnIcon.Common.ViewModels.ConfigurationSections.Plugins.Config
{
    /// <summary>
    /// SpecialWpfConfigPluginsConfigurationSectionViewModel
    /// </summary>
    public class SpecialWpfConfigPluginsConfigurationSectionViewModel : AbstractConfigPluginsConfigurationSectionViewModel
    {
        /// <summary>
        /// SpecialWpfConfigPluginsConfigurationSectionViewModel
        /// </summary>
        public SpecialWpfConfigPluginsConfigurationSectionViewModel(IPluginSettings pluginSettings) : base(pluginSettings)
        {
        }

        /// <summary>
        /// OnInit
        /// </summary>
        public void OnInit(ISimplyAWpfPlugin plugin)
        {
            OnInternalInit(plugin);
        }
    }
}
