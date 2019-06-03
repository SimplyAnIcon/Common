using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using SimplyAnIcon.Common.Helpers.Interfaces;

namespace SimplyAnIcon.Common.Helpers
{
    /// <summary>
    /// ProcessHelper
    /// </summary>
    public class ProcessHelper : IProcessHelper
    {
        /// <inheritdoc />
        public void ExecuteApp(string path)
        {
            Process.Start(new ProcessStartInfo(path)
            {
                WorkingDirectory = new FileInfo(path).DirectoryName ?? @"C:\"
            });
        }

        /// <inheritdoc />
        public void BePatientBeforeKillingAllProcess(string name)
        {
            bool ok = false;
            for (int i = 0; !ok && i < 20; ++i)
            {
                Thread.Sleep(500);
                if (!Process.GetProcessesByName(name).Any())
                    ok = true;
            }

            KillAllProcess(name);
        }

        /// <inheritdoc />
        public void KillAllProcess(string name)
        {
            foreach (var process in Process.GetProcessesByName(name))
                process.Kill();
        }
    }
}
