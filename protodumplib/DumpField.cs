using System;
using System.Collections;
using protodump;

namespace protodumplib
{
    public interface IDumpField
    {
        byte FieldNo { get; set; }
        DumpType FieldType { get; set; }
    }


    public struct DumpFieldDouble : IDumpField
    {
        public byte FieldNo { get; set; }
        public DumpType FieldType { get; set; }
        public double Value { get; set; }
        public DumpFieldDouble(byte fieldNo, double value) 
        {
            FieldNo = fieldNo;
            FieldType = DumpType.Double;
            Value = value;
        }

        public override string ToString() => $"{FieldNo}:{FieldType}:{Value}";
    }

    public struct DumpFieldByte : IDumpField
    {
        public byte FieldNo { get; set; }
        public DumpType FieldType { get; set; }
        public byte Value { get; set; }
        public DumpFieldByte(byte fieldNo, byte value)
        {
            FieldNo = fieldNo;
            FieldType = DumpType.Byte;
            Value = value;
        }

        public override string ToString() => $"{FieldNo}:{FieldType}:{Value}";
    }

    public struct DumpFieldInt : IDumpField
    {
        public byte FieldNo { get; set; }
        public DumpType FieldType { get; set; }
        public int Value { get; set; }
        public DumpFieldInt(byte fieldNo, int value)
        {
            FieldNo = fieldNo;
            FieldType = DumpType.Int;
            Value = value;
        }

        public override string ToString() => $"{FieldNo}:{FieldType}:{Value}";
    }

    public struct DumpFieldLong : IDumpField
    {
        public byte FieldNo { get; set; }
        public DumpType FieldType { get; set; }
        public long Value { get; set; }
        public DumpFieldLong(byte fieldNo, long value)
        {
            FieldNo = fieldNo;
            FieldType = DumpType.Long;
            Value = value;
        }

        public override string ToString() => $"{FieldNo}:{FieldType}:{Value}";
    }

    public struct DumpFieldString : IDumpField
    {
        public byte FieldNo { get; set; }
        public DumpType FieldType { get; set; }
        public string Value { get; set; }
        public DumpFieldString(byte fieldNo, string value)
        {
            FieldNo = fieldNo;
            FieldType = DumpType.String;
            Value = value;
        }

        public override string ToString() => $"{FieldNo}:{FieldType}:{Value}";
    }

    public struct DumpFieldObject : IDumpField
    {
        public byte FieldNo { get; set; }
        public DumpType FieldType { get; set; }
        public DumpObject Value { get; set; }
        public DumpFieldObject(byte fieldNo, DumpObject value)
        {
            FieldNo = fieldNo;
            FieldType = DumpType.Object;
            Value = value;
        }

        public override string ToString() => $"{FieldNo}:{FieldType}:{Value}";
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
            if (obj is null)
                return;
            foreach (var fieldObj in obj.Fields)
                _fields[fieldObj.Key] = fieldObj.Value;
        }

        public void LoadTo(DumpObject obj)
        {
            if (obj is null)
                return;
            foreach (var fieldObj in obj.Fields)
                _fields[fieldObj.Key] = fieldObj.Value;
        }
    }

    public abstract class Dumpable
    {
        public abstract void Serialize(DumpObject obj);
        public abstract void Deserialize(DumpObject obj);
    }
}

