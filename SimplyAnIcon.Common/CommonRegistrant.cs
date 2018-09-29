using Com.Ericmas001.DependencyInjection.Registrants;
using SimplyAnIcon.Common.Services;
using SimplyAnIcon.Common.Services.Interfaces;

namespace SimplyAnIcon.Common
{
    /// <inheritdoc />
    public class CoreRegistrant : AbstractRegistrant
    {
        /// <inheritdoc />
        protected override void RegisterEverything()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            Register<IPluginService, PluginService>();
        }
    }
}
