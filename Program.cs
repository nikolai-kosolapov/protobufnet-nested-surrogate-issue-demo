using ProtobufnetNestedSurrogateIssueDemo;
using System.Data.SqlTypes;

var model = ProtoBuf.Meta.RuntimeTypeModel.Default;
model.Add<SqlDecimalSurrogate>();
model.Add<SqlDecimal>(false).SetSurrogate(typeof(SqlDecimalSurrogate));

var serializer = new ProtobufSerializer();

var entity = new MyClass { MyField = 1 };

var serializedEntity = serializer.Serialize(entity);
var deserializedEntity = serializer.Deserialize<MyClass>(serializedEntity);

Console.WriteLine(deserializedEntity.MyField);
