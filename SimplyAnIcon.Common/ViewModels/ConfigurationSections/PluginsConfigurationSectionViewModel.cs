using System.Collections.Generic;
using Com.Ericmas001.DependencyInjection.Resolvers.Interfaces;
using SimplyAnIcon.Common.Models;
using SimplyAnIcon.Common.ViewModels.ConfigurationSections.Plugins;
using SimplyAnIcon.Common.ViewModels.Interfaces;
using SimplyAnIcon.Plugins.Wpf.Util;

namespace SimplyAnIcon.Common.ViewModels.ConfigurationSections
{
    /// <summary>
    /// PluginsConfigurationSectionViewModel
    /// </summary>
    public class PluginsConfigurationSectionViewModel : IConfigurationSectionViewModel
    {
        private readonly IResolverService _resolverService;
        private readonly FastObservableCollection<IConfigurationSectionViewModel> _sections = new FastObservableCollection<IConfigurationSectionViewModel>();

        /// <inheritdoc />
        public string Name => "Plugins";

        /// <inheritdoc />
        public object IconPath => null;

        /// <inheritdoc />
        public IEnumerable<IConfigurationSectionViewModel> ChildrenSections => _sections;
        
        /// <summary>
        /// PluginsConfigurationSectionViewModel
        /// </summary>
        public PluginsConfigurationSectionViewModel(IResolverService resolverService)
        {
            _resolverService = resolverService;
        }

        /// <summary>
        /// 
        /// </summary>
        public void OnInit(PluginCatalog catalog)
        {
            var genPlugin = _resolverService.Resolve<GeneralPluginsConfigurationSectionViewModel>();
            genPlugin.OnInit(catalog);
            _sections.Add(genPlugin);

            var plugins = _resolverService.Resolve<SpecificPluginsConfigurationSectionViewModel>();
            plugins.OnInit(catalog);
            _sections.Add(plugins);
        }
    }
}
