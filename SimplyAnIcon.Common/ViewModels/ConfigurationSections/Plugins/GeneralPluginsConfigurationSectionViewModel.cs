using System.Collections.Generic;
using SimplyAnIcon.Common.Models;
using SimplyAnIcon.Common.ViewModels.Interfaces;

namespace SimplyAnIcon.Common.ViewModels.ConfigurationSections.Plugins
{
    /// <summary>
    /// GeneralPluginsConfigurationSectionViewModel
    /// </summary>
    public class GeneralPluginsConfigurationSectionViewModel : IConfigurationSectionViewModel
    {
        /// <inheritdoc />
        public string Name => "General";

        /// <inheritdoc />
        public object IconPath => null;

        /// <inheritdoc />
        public IEnumerable<IConfigurationSectionViewModel> ChildrenSections => new IConfigurationSectionViewModel[0];

        /// <summary>
        /// OnInit
        /// </summary>
        public void OnInit(PluginCatalog catalog)
        {
            throw new System.NotImplementedException();
        }
    }
}
