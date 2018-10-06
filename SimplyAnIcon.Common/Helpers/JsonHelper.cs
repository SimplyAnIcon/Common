using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SimplyAnIcon.Common.Helpers.Interfaces;

namespace SimplyAnIcon.Common.Helpers
{
    /// <summary>
    /// JsonHelper
    /// </summary>
    public class JsonHelper : IJsonHelper
    {
        private readonly JsonSerializerSettings _settings = new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented,
            Converters = new List<JsonConverter>()
            {
                new StringEnumConverter()
            }
        };

        /// <inheritdoc />
        public T DeserializeFile<T>(string filepath)
        {
            return Deserialize<T>(File.ReadAllText(filepath));
        }

        /// <inheritdoc />
        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, _settings);
        }

        /// <inheritdoc />
        public void SerializeToFile<T>(T obj, string filepath)
        {
            File.WriteAllText(filepath, Serialize(obj));
        }

        /// <inheritdoc />
        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj, _settings);
        }
    }
}
