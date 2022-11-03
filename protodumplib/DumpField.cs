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
}

