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

    public abstract class DumpField
    {
        public byte FieldNo { get; set; }
        public DumpType FieldType { get; set; }

        public DumpField(byte fieldNo)
        {            
            FieldNo = fieldNo;            
        }

        public abstract string GetAsString();        
        public override string ToString() => $"{FieldNo}:{FieldType}:{GetAsString()}";
    }


    public class DumpFieldDouble : DumpField
    {
        public DumpFieldDouble(byte fieldNo) : base(fieldNo)
        {
            FieldType = DumpType.Double;
        }

        public double Value { get; set; }
        public override string GetAsString() => Value.ToString();
    }

    public class DumpFieldByte : DumpField
    {
        public DumpFieldByte(byte fieldNo) : base(fieldNo)
        {
            FieldType = DumpType.Byte;
        }

        public byte Value { get; set; }
        public override string GetAsString() => Value.ToString();
    }

    public class DumpFieldInt : DumpField
    {
        public DumpFieldInt(byte fieldNo) : base(fieldNo)
        {
            FieldType = DumpType.Int;
        }

        public int Value { get; set; }
        public override string GetAsString() => Value.ToString();
    }

    public class DumpFieldLong : DumpField
    {
        public DumpFieldLong(byte fieldNo) : base(fieldNo)
        {
            FieldType = DumpType.Long;
        }

        public long Value { get; set; }
        public override string GetAsString() => Value.ToString();
    }

    public class DumpFieldString : DumpField
    {
        public DumpFieldString(byte fieldNo) : base(fieldNo)
        {
            FieldType = DumpType.String;
        }

        public string Value { get; set; }
        public override string GetAsString() => Value;
    }

    public class DumpFieldObject : DumpField
    {
        public DumpFieldObject(byte fieldNo) : base(fieldNo)
        {
            FieldType = DumpType.Object;
        }

        public DumpObject Value { get; set; }
        public override string GetAsString() => Value.ToString();
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

        public void Serialize(DumpCodec codec)
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

