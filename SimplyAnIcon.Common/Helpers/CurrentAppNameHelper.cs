using System.Reflection;
using SimplyAnIcon.Common.Helpers.Interfaces;

namespace SimplyAnIcon.Common.Helpers
{
    /// <summary>
    /// CurrentAppNameHelper
    /// </summary>
    public class CurrentAppNameHelper : IAppNameHelper
    {
        /// <inheritdoc />
        public string GetAppName()
        {
            return Assembly.GetEntryAssembly().GetName().Name;
        }
    }
}
