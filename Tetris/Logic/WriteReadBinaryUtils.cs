using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace Tetris.Logic
{
    public static class WriteReadBinaryUtils
    {
        private static BinaryFormatter formatter = new BinaryFormatter();

        public static T DeserialLize<T>(string fileName)
        {
            if (!File.Exists(fileName))
                return default(T);

            string json = File.ReadAllText(fileName);
            try
            {
                return JsonSerializer.Deserialize<T>(json);
            }
            catch { return default(T); }
        }

        public static void Serialize(object obj, string fileName)
        {
            try
            {
                string json = JsonSerializer.Serialize(obj);
                File.WriteAllText(fileName, json);
            }
            catch { }
        }
    }
}
