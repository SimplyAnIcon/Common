namespace SimplyAnIcon.Common.Helpers.Interfaces
{
    /// <summary>
    /// IProcessHelper
    /// </summary>
    public interface IProcessHelper
    {
        /// <summary>
        /// ExecuteApp
        /// </summary>
        void ExecuteApp(string path);

        /// <summary>
        /// BePatientBeforeKillingAllProcess
        /// </summary>
        void BePatientBeforeKillingAllProcess(string name);

        /// <summary>
        /// KillAllProcess
        /// </summary>
        void KillAllProcess(string name);
    }
}
