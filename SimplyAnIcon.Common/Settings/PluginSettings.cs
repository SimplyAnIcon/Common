using System.Collections.Generic;
using System.IO;
using System.Linq;
using SimplyAnIcon.Common.Helpers.Interfaces;
using SimplyAnIcon.Common.Models;
using SimplyAnIcon.Common.Settings.Interface;
using SimplyAnIcon.Plugins.V1;

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
        public bool IsActive(ISimplyAPlugin plugin)
        {
            var plugins = LoadPluginSettings().ToArray();

            var entry = plugins.SingleOrDefault(p => p.Name == GetPluginName(plugin));

            return entry?.IsActive ?? false;
        }

        /// <inheritdoc />
        public void SetActivationStatus(ISimplyAPlugin plugin, bool value)
        {
            var plugins = LoadPluginSettings().ToArray();

            var entry = plugins.SingleOrDefault(p => p.Name == GetPluginName(plugin));

            if (entry == null)
                return;

            entry.IsActive = value;

            SavePluginSettings(plugins);
        }

        /// <inheritdoc />
        public void AddPlugin(ISimplyAPlugin plugin)
        {
            var plugins = LoadPluginSettings().ToList();
            var entry = new PluginSettingEntry
            {
                Name = GetPluginName(plugin),
                IsActive = false,
                Order = plugins.Any() ? plugins.Max(x => x.Order) + 1 : 0
            };
            plugins.Add(entry);
            SavePluginSettings(plugins);
        }

        /// <summary>
        /// GetPluginName
        /// </summary>
        public string GetPluginName(ISimplyAPlugin plugin)
        {
            return plugin.GetType().Assembly.GetName().Name + ";" + plugin.GetType().FullName;
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
