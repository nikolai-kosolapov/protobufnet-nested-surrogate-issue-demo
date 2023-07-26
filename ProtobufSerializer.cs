using ProtoBuf;

namespace ProtobufnetNestedSurrogateIssueDemo
{
    public class ProtobufSerializer
    {
        public T Deserialize<T>(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            {
                return Serializer.Deserialize<T>(ms);
            }
        }

        public byte[] Serialize<T>(T entity)
        {
            using (var ms = new MemoryStream())
            {
                Serializer.Serialize(ms, entity);
                return ms.ToArray();
            }
        }
    }
}
