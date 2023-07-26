using ProtoBuf;
using System.Data.SqlTypes;

namespace ProtobufnetNestedSurrogateIssueDemo
{
    [ProtoContract]
    public struct SqlDecimalSurrogate
    {
        public SqlDecimalSurrogate(decimal value)
        {
            IsNull = false;
            Value = value;
        }

        public SqlDecimalSurrogate(SqlDecimal value)
        {
            if (value.IsNull)
            {
                IsNull = true;
                Value = default;
                return;
            }

            IsNull = false;
            Value = value.Value;
        }

        [ProtoMember(1)]
        public decimal Value { get; set; }

        [ProtoMember(2)]
        public bool IsNull { get; set; }

        public static implicit operator SqlDecimalSurrogate(SqlDecimal value)
        {
            return new SqlDecimalSurrogate(value);
        }

        public static implicit operator SqlDecimal(SqlDecimalSurrogate value)
        {
            if (value.IsNull)
            {
                return SqlDecimal.Null;
            }

            return new SqlDecimal(value.Value);
        }
    }
}
