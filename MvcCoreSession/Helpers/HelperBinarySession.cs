using System.Runtime.Serialization.Formatters.Binary;

namespace MvcCoreSession.Helpers
{
    public class HelperBinarySession
    {
        public static byte[] ObjectToByte(Object objecto)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, objecto);

                return stream.ToArray();
            }
        }

        public static Object ByteToObject(byte[] data)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(data, 0, data.Length);
                stream.Seek(0, SeekOrigin.Begin);

                Object objecto = formatter.Deserialize(stream);

                return objecto;
            }
        }
    }
}