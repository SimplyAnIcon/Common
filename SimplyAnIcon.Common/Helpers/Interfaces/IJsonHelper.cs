namespace SimplyAnIcon.Common.Helpers.Interfaces
{
    /// <summary>
    /// IJsonHelper
    /// </summary>
    public interface IJsonHelper
    {
        /// <summary>
        /// DeserializeFile
        /// </summary>
        T DeserializeFile<T>(string filepath);

        /// <summary>
        /// Deserialize
        /// </summary>
        T Deserialize<T>(string json);

        /// <summary>
        /// SerializeToFile
        /// </summary>
        void SerializeToFile<T>(T obj, string filepath);

        /// <summary>
        /// Serialize
        /// </summary>
        string Serialize<T>(T obj);
    }
}
