using System;
using System.IO;
using SimplyAnIcon.Common.Helpers.Interfaces;

namespace SimplyAnIcon.Common.Helpers
{
    /// <summary>
    /// WindowsHelper
    /// </summary>
    public class WindowsHelper : IWindowsHelper
    {
        private readonly IAppNameHelper _appNameHelper;

        /// <summary>
        /// WindowsHelper
        /// </summary>
        public WindowsHelper(IAppNameHelper appNameHelper)
        {
            _appNameHelper = appNameHelper;
        }

        /// <inheritdoc />
        public string AppRoamingDataPath()
        {
            var di = new DirectoryInfo(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                _appNameHelper.GetAppName()));

            if (!di.Exists)
                di.Create();

            return di.FullName;
        }
    }
}
