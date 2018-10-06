﻿using System.Collections.Generic;
using GalaSoft.MvvmLight;
using SimplyAnIcon.Common.Settings.Interface;
using SimplyAnIcon.Common.ViewModels.Interfaces;
using SimplyAnIcon.Plugins.V1;

namespace SimplyAnIcon.Common.ViewModels.ConfigurationSections.Plugins.Config
{
    /// <summary>
    /// AbstractConfigPluginsConfigurationSectionViewModel
    /// </summary>
    public abstract class AbstractConfigPluginsConfigurationSectionViewModel : ViewModelBase, IConfigurationSectionViewModel
    {
        private readonly IPluginSettings _pluginSettings;
        private bool _isActivated;

        /// <summary>
        /// Plugin
        /// </summary>
        public ISimplyAPlugin Plugin { get; private set; }

        /// <inheritdoc />
        public string Name => Plugin.Name;

        /// <inheritdoc />
        public virtual object IconPath => null;

        /// <inheritdoc />
        public IEnumerable<IConfigurationSectionViewModel> ChildrenSections => new IConfigurationSectionViewModel[0];

        /// <summary>
        /// AbstractConfigPluginsConfigurationSectionViewModel
        /// </summary>
        protected AbstractConfigPluginsConfigurationSectionViewModel(IPluginSettings pluginSettings)
        {
            _pluginSettings = pluginSettings;
        }

        /// <summary>
        /// IsActivated
        /// </summary>
        public bool IsActivated
        {
            get => _isActivated;
            set
            {
                Set(ref _isActivated, value);
                _pluginSettings.SetActivationStatus(Name, value);
            }
        }

        /// <summary>
        /// OnInternalInit
        /// </summary>
        protected virtual void OnInternalInit(ISimplyAPlugin plugin)
        {
            Plugin = plugin;
            IsActivated = _pluginSettings.IsActive(Name);
        }
    }
}