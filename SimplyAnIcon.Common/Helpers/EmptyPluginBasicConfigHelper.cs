using System.Collections.Generic;
using SimplyAnIcon.Common.Helpers.Interfaces;

namespace SimplyAnIcon.Common.Helpers
{
    /// <summary>
    /// EmptyPluginBasicConfigHelper
    /// </summary>
    public class EmptyPluginBasicConfigHelper : IPluginBasicConfigHelper
    {
        /// <inheritdoc />
        public Dictionary<string, object> GetPluginBasicConfig()
        {
            return new Dictionary<string, object>();
        }
    }
}
