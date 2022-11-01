using System;
using System.Collections;
using protodump;

namespace protodumplib
{
    public struct TokenOf<X> : IComparable
    {
        public int CompareTo(object obj)
        {
            if (obj is TokenOf<X>)
                return 0;
            return 1;
        }
    }

    public interface IDumpField
    {
        public byte FieldNo { get; set; }
        public DumpType FieldType { get; set; }
        public T GetValue<T>();
        public DumpObject GetObject();
        public void SetValue<T>(T value);
        public void SetObject(DumpObject obj);
    }

    public class DumpField<T> : IDumpField
    {
        public DumpField(byte fieldNo)
        {
            Value = default(T);
            FieldNo = fieldNo;
            switch (default(TokenOf<T>))
            {
                case TokenOf<double>: FieldType = DumpType.Double; break;
                case TokenOf<byte>: FieldType = DumpType.Byte; break;
                case TokenOf<int>: FieldType = DumpType.Int; break;
                case TokenOf<long>: FieldType = DumpType.Long; break;
                case TokenOf<string>: FieldType = DumpType.String; break;
                case TokenOf<DateTime>: FieldType = DumpType.Date; break;
                case TokenOf<DumpObject>: FieldType = DumpType.Object; break;
                default: throw new InvalidCastException("Type unsupported");
            }
        }

        public byte FieldNo { get; set; }
        public DumpType FieldType { get; set; }
        public T Value { get; set; }

        public T1 GetValue<T1>() => (T1)Convert.ChangeType(Value, typeof(T1));

        public DumpObject GetObject()
        {
            if (Value is DumpObject)
                return (DumpObject)(object)Value;
            return null;
        }

        public void SetValue<T1>(T1 value) => Value = (T)Convert.ChangeType(value, typeof(T));

        public void SetObject(DumpObject obj) => Value = (T)(object)obj;

        public override string ToString() => $"{FieldNo}:{FieldType}:{GetValue<string>()}";
    }

    public class DumpObject : IEnumerable<IDumpField>
    {
        private readonly Dictionary<int, IDumpField> _fields;
        public Dictionary<int, IDumpField> Fields => _fields;
        public DumpObject()
        {
            _fields = new Dictionary<int, IDumpField>();
        }

        public void AddField(IDumpField field) => _fields[field.FieldNo] = field;

        public IEnumerator<IDumpField> GetEnumerator() => _fields.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _fields.Values.GetEnumerator();

        public void Serialize(Codec codec)
        {
            foreach (var field in this)
                codec.WriteField(field);
            
            codec.WriteEnd();
        }

        public void LoadFrom(DumpObject obj)
        {
            foreach (var fieldObj in obj.Fields)
                _fields[fieldObj.Key] = fieldObj.Value;
        }
    }
}

