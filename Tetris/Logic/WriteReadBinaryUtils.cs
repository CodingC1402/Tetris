using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Tetris.Logic
{
    public static class WriteReadBinaryUtils
    {
        private static BinaryFormatter formatter = new BinaryFormatter();

        public static T DeserialLize<T>(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            try
            {
                return (T)formatter.Deserialize(fs);
            }
            catch { return default(T); }
            finally { fs.Close(); }
        }

        public static void Serialize(object obj, string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            try
            {
                formatter.Serialize(fs, obj);
            }
            catch { }
            finally
            {
                fs.Close();
            }
        }
    }
}
