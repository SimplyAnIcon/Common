#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
using SimplyAnIcon.Plugins.V1;
using SimplyAnIcon.Plugins.Wpf.V1;

namespace SimplyAnIcon.Common.Models
{
    public class PluginInfo
    {
        public ISimplyAPlugin Plugin { get; set; }
        public bool IsActivated { get; set; }
        public bool IsNew { get; set; }

        public ISimplyAWpfPlugin ForegroundPlugin => Plugin as ISimplyAWpfPlugin;
        public bool IsForeground => ForegroundPlugin != null;
    }
}
