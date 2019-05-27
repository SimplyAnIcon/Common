using Com.Ericmas001.DependencyInjection.Registrants;
using SimplyAnIcon.Common.Helpers;
using SimplyAnIcon.Common.Helpers.Interfaces;
using SimplyAnIcon.Common.Services;
using SimplyAnIcon.Common.Services.Interfaces;
using SimplyAnIcon.Common.Settings;
using SimplyAnIcon.Common.Settings.Interface;

namespace SimplyAnIcon.Common
{
    /// <inheritdoc />
    public class CoreRegistrant : AbstractRegistrant
    {
        /// <inheritdoc />
        protected override void RegisterEverything()
        {
            RegisterServices();
            RegisterHelpers();
            RegisterSettings();
        }

        private void RegisterHelpers()
        {
            Register<IWindowsHelper, WindowsHelper>();
            Register<IJsonHelper, JsonHelper>();
            Register<IPluginBasicConfigHelper, EmptyPluginBasicConfigHelper>();
            Register<IAppNameHelper, CurrentAppNameHelper>();
        }

        private void RegisterServices()
        {
            Register<IPluginService, PluginService>();
        }
        private void RegisterSettings()
        {
            Register<IPluginSettings, PluginSettings>();
        }
    }
}
