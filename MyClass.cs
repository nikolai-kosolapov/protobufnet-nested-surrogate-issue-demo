using ProtoBuf;
using System.Data.SqlTypes;

namespace ProtobufnetNestedSurrogateIssueDemo
{
    [ProtoContract]
    public class MyClass
    {
        [ProtoMember(1)]
        public SqlDecimal MyField { get; set; }
    }
}
