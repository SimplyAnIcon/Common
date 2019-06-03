using Com.Ericmas001.DependencyInjection.Registrants;
using SimplyAnIcon.Common.Helpers;
using SimplyAnIcon.Common.Helpers.Interfaces;

namespace SimplyAnIcon.Common
{
    /// <inheritdoc />
    public class CoreRegistrant : AbstractRegistrant
    {
        /// <inheritdoc />
        protected override void RegisterEverything()
        {
            RegisterHelpers();
        }

        private void RegisterHelpers()
        {
            Register<IWindowsHelper, WindowsHelper>();
            Register<IJsonHelper, JsonHelper>();
            Register<IAppNameHelper, CurrentAppNameHelper>();
            Register<IProcessHelper, ProcessHelper>();
        }
    }
}
