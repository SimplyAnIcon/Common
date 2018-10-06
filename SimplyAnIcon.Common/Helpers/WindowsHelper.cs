using System;
using System.IO;
using System.Reflection;
using SimplyAnIcon.Common.Helpers.Interfaces;

namespace SimplyAnIcon.Common.Helpers
{
    /// <summary>
    /// WindowsHelper
    /// </summary>
    public class WindowsHelper : IWindowsHelper
    {
        /// <inheritdoc />
        public string AppRoamingDataPath()
        {
            var di = new DirectoryInfo(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                Assembly.GetEntryAssembly().GetName().Name));

            if(!di.Exists)
                di.Create();

            return di.FullName;
        }
    }
}
