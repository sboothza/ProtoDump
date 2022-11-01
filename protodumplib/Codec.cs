using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using protodumplib;
using System.Xml.Linq;
using Microsoft.VisualBasic.FileIO;
using System.Reflection;

namespace protodump
{
    public class Codec
    {
        private byte[] _data;
        private int _position = 0;

        private void Init(int size = 1024)
        {
            _data = new byte[size];
            _position = 0;
        }

        public void Init(byte[] data)
        {
            _data = new byte[data.Length];
            Array.Copy(data, _data, data.Length);
            _position = 0;
        }

        private void DoubleSize()
        {
            byte[] newData = new byte[_data.Length * 2];
            Array.Copy(_data, newData, _data.Length);
            _data = newData;
        }

        public Codec(int size = 1024)
        {
            Init(size);
        }

        public Codec(byte[] data) => Init(data);

        public void Seek(int position) => _position = position;

        public int Position => _position;

        public byte[] GetData()
        {
            byte[] data = new byte[_position];
            Array.Copy(_data, data, _position);
            return data;
        }

        public byte[] Serialize(DumpObject obj)
        {
            Init();
            obj.Serialize(this);
            return GetData();
        }

        private void Write<T>(T value)
        {
            unsafe
            {
                fixed (byte* ptr = &(_data[_position]))
                {
                    Unsafe.Write<T>(ptr, value);
                }
                _position += Marshal.SizeOf(typeof(T));
            }
        }

        public void WriteDouble(double value) => Write<double>(value);

        public void WriteByte(byte value) => Write<byte>(value);

        public void WriteInt(int value) => Write<int>(value);

        public void WriteLong(long value) => Write<long>(value);

        public void WriteString(string value)
        {
            if (string.IsNullOrEmpty(value))
                value = string.Empty;
            var data = Encoding.ASCII.GetBytes(value);
            Write<byte>((byte)data.Length);
            Array.Copy(data, 0, _data, _position, data.Length);
            _position += data.Length;
        }

        public void WriteDate(DateTime value) => Write<long>(value.Ticks);

        public void WriteObject(DumpObject obj) => obj.Serialize(this);

        public void WriteField(IDumpField field)
        {
            Write<byte>(field.FieldNo);
            Write<byte>((byte)field.FieldType);
            switch (field.FieldType)
            {
                case DumpType.Double: WriteDouble(field.GetValue<double>()); break;
                case DumpType.Byte: WriteByte(field.GetValue<byte>()); break;
                case DumpType.Int: WriteInt(field.GetValue<int>()); break;
                case DumpType.Long: WriteLong(field.GetValue<long>()); break;
                case DumpType.Date: WriteDate(field.GetValue<DateTime>()); break;
                case DumpType.String: WriteString(field.GetValue<string>()); break;
                case DumpType.Object: WriteObject(field.GetObject()); break;
            }
        }

        public void WriteEnd()
        {
            Write<byte>(0xff);
        }

        private T Read<T>()
        {
            unsafe
            {
                T value;
                fixed (byte* ptr = &(_data[_position]))
                {
                    value = Unsafe.Read<T>(ptr);
                }
                _position += Marshal.SizeOf(typeof(T));
                return value;
            }
        }

        private IDumpField ReadField()
        {
            var fieldNo = ReadByte();
            if (fieldNo == 0xff)
                return null;

            var fieldType = (DumpType)ReadByte();
            IDumpField field = null;
            switch (fieldType)
            {
                case DumpType.Double: field = new DumpField<double>(fieldNo) { Value = ReadDouble() }; break;
                case DumpType.Byte: field = new DumpField<byte>(fieldNo) { Value = ReadByte() }; break;
                case DumpType.Int: field = new DumpField<int>(fieldNo) { Value = ReadInt() }; break;
                case DumpType.Long: field = new DumpField<long>(fieldNo) { Value = ReadLong() }; break;
                case DumpType.String: field = new DumpField<string>(fieldNo) { Value = ReadString() }; break;
                case DumpType.Date: field = new DumpField<DateTime>(fieldNo) { Value = ReadDate() }; break;
                case DumpType.Object: field = new DumpField<DumpObject>(fieldNo) { Value = ReadObject() }; break;
            }
            return field;
        }

        public double ReadDouble() => Read<double>();

        public byte ReadByte() => Read<byte>();

        public int ReadInt() => Read<int>();

        public long ReadLong() => Read<long>();

        public string ReadString()
        {
            var len = Read<byte>();
            var data = new byte[len];
            Array.Copy(_data, _position, data, 0, len);
            _position += len;
            return Encoding.ASCII.GetString(data);
        }

        public DateTime ReadDate() => new DateTime(Read<long>());

        public DumpObject ReadObject()
        {
            var obj = new DumpObject();
            ReadObject(obj);
            return obj;
        }

        public void ReadObject(DumpObject obj)
        {
            var field = ReadField();
            while (field != null)
            {
                obj.AddField(field);
                field = ReadField();
            }
        }
    }
}

