﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using SimplyAnIcon.Common.Helpers.Interfaces;
using SimplyAnIcon.Common.Models;
using SimplyAnIcon.Common.Settings.Interface;

namespace SimplyAnIcon.Common.Settings
{
    /// <summary>
    /// PluginSettings
    /// </summary>
    public class PluginSettings : IPluginSettings
    {
        private readonly IWindowsHelper _windowsHelper;
        private readonly IJsonHelper _jsonHelper;

        /// <summary>
        /// PluginSettings
        /// </summary>
        public PluginSettings(IWindowsHelper windowsHelper, IJsonHelper jsonHelper)
        {
            _windowsHelper = windowsHelper;
            _jsonHelper = jsonHelper;
        }

        /// <inheritdoc />
        public bool IsActive(string pluginName)
        {
            var plugins = LoadPluginSettings().ToArray();

            var plugin = plugins.SingleOrDefault(p => p.Name == pluginName);

            return plugin?.IsActive ?? false;
        }

        /// <inheritdoc />
        public void SetActivationStatus(string pluginName, bool value)
        {
            var plugins = LoadPluginSettings().ToArray();

            var plugin = plugins.SingleOrDefault(p => p.Name == pluginName);

            if (plugin == null)
                return;

            plugin.IsActive = value;

            SavePluginSettings(plugins);
        }

        /// <inheritdoc />
        public void AddPlugin(string name)
        {
            var plugins = LoadPluginSettings().ToList();
            var entry = new PluginSettingEntry
            {
                Name = name,
                IsActive = false,
                Order = plugins.Any() ? plugins.Max(x => x.Order) + 1 : 0
            };
            plugins.Add(entry);
            SavePluginSettings(plugins);
        }

        /// <inheritdoc />
        public IEnumerable<PluginSettingEntry> GetPlugins()
        {
            return LoadPluginSettings().ToArray();
        }

        private IEnumerable<PluginSettingEntry> LoadPluginSettings()
        {
            var fi = new FileInfo(Path.Combine(_windowsHelper.AppRoamingDataPath(), nameof(PluginSettings) + ".json"));
            if (!fi.Exists)
                return new PluginSettingEntry[0];

            return _jsonHelper.DeserializeFile<IEnumerable<PluginSettingEntry>>(fi.FullName);
        }

        private void SavePluginSettings(IEnumerable<PluginSettingEntry> plugins)
        {
            _jsonHelper.SerializeToFile(plugins, Path.Combine(_windowsHelper.AppRoamingDataPath(), nameof(PluginSettings) + ".json"));
        }
    }
}