using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using protodumplib;
using System.Xml.Linq;
using Microsoft.VisualBasic.FileIO;
using System.Reflection;
using System.Drawing;

namespace protodump
{
    public class DumpCodec
    {
        private const int INIT_SIZE = 128;
        private byte[] _data;
        private int _position = 0;

        private void Init(int size = INIT_SIZE)
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
            Console.WriteLine("doubling");
            byte[] newData = new byte[_data.Length * 2];
            Array.Copy(_data, newData, _data.Length);
            _data = newData;
        }

        public DumpCodec(int size = INIT_SIZE)
        {
            Init(size);
        }

        public DumpCodec(byte[] data) => Init(data);

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

        public byte[] Serialize(Dumpable obj)
        {
            Init();
            var dumpObject = new DumpObject();
            obj.Serialize(dumpObject);
            dumpObject.Serialize(this);
            return GetData();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteDouble(double value)
        {
            const int size = 8;
            while (_position + size > _data.Length)
                DoubleSize();

            unsafe
            {
                fixed (byte* ptr = &(_data[_position]))
                {
                    Unsafe.Write(ptr, value);
                }
                _position += size;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteByte(byte value)
        {
            const int size = 1;
            while (_position + size > _data.Length)
                DoubleSize();

            unsafe
            {
                fixed (byte* ptr = &(_data[_position]))
                {
                    Unsafe.Write(ptr, value);
                }
                _position += size;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteInt(int value)
        {
            const int size = 4;
            while (_position + size > _data.Length)
                DoubleSize();

            unsafe
            {
                fixed (byte* ptr = &(_data[_position]))
                {
                    Unsafe.Write(ptr, value);
                }
                _position += size;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteLong(long value)
        {
            const int size = 8;
            while (_position + size > _data.Length)
                DoubleSize();

            unsafe
            {
                fixed (byte* ptr = &(_data[_position]))
                {
                    Unsafe.Write(ptr, value);
                }
                _position += size;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteString(string value)
        {
            if (string.IsNullOrEmpty(value))
                value = string.Empty;

            var data = Encoding.ASCII.GetBytes(value);

            while (_position + data.Length + 1 > _data.Length)
                DoubleSize();

            WriteByte((byte)data.Length);
            Array.Copy(data, 0, _data, _position, data.Length);
            _position += data.Length;
        }

        public void WriteObject(DumpObject obj) => obj.Serialize(this);

        public void WriteField(IDumpField field)
        {
            WriteByte(field.FieldNo);
            WriteByte((byte)field.FieldType);
            switch (field.FieldType)
            {
                case DumpType.Double: WriteDouble(((DumpFieldDouble)field).Value); break;
                case DumpType.Byte: WriteByte(((DumpFieldByte)field).Value); break;
                case DumpType.Int: WriteInt(((DumpFieldInt)field).Value); break;
                case DumpType.Long: WriteLong(((DumpFieldLong)field).Value); break;
                case DumpType.String: WriteString(((DumpFieldString)field).Value); break;
                case DumpType.Object: WriteObject(((DumpFieldObject)field).Value); break;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void WriteEnd()
        {
            WriteByte(0xff);
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
                case DumpType.Double: field = new DumpFieldDouble(fieldNo, ReadDouble()); break;
                case DumpType.Byte: field = new DumpFieldByte(fieldNo, ReadByte()); break;
                case DumpType.Int: field = new DumpFieldInt(fieldNo, ReadInt()); break;
                case DumpType.Long: field = new DumpFieldLong(fieldNo, ReadLong()); break;
                case DumpType.String: field = new DumpFieldString(fieldNo, ReadString()); break;
                case DumpType.Object: field = new DumpFieldObject(fieldNo, ReadObject()); break;
            }
            return field;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double ReadDouble()
        {
            const int size = 8;
            if (_position + size > _data.Length)
                throw new OverflowException("Not enough data left to read");

            unsafe
            {
                double value;
                fixed (byte* ptr = &(_data[_position]))
                {
                    value = Unsafe.Read<double>(ptr);
                }
                _position += size;
                return value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte ReadByte()
        {
            const int size = 1;
            if (_position + size > _data.Length)
                throw new OverflowException("Not enough data left to read");

            unsafe
            {
                byte value;
                fixed (byte* ptr = &(_data[_position]))
                {
                    value = Unsafe.Read<byte>(ptr);
                }
                _position += size;
                return value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int ReadInt()
        {
            const int size = 4;
            if (_position + size > _data.Length)
                throw new OverflowException("Not enough data left to read");

            unsafe
            {
                int value;
                fixed (byte* ptr = &(_data[_position]))
                {
                    value = Unsafe.Read<int>(ptr);
                }
                _position += size;
                return value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long ReadLong()
        {
            const int size = 8;
            if (_position + size > _data.Length)
                throw new OverflowException("Not enough data left to read");

            unsafe
            {
                long value;
                fixed (byte* ptr = &(_data[_position]))
                {
                    value = Unsafe.Read<long>(ptr);
                }
                _position += size;
                return value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ReadString()
        {
            var len = ReadByte();
            var data = new byte[len];
            if (_position + len > _data.Length)
                throw new OverflowException("Not enough data to read");

            Array.Copy(_data, _position, data, 0, len);
            _position += len;
            return Encoding.ASCII.GetString(data);
        }

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

        public void Deserialize(Dumpable obj)
        {
            var dumpObj = new DumpObject();
            ReadObject(dumpObj);
            obj.Deserialize(dumpObj);
        }
    }
}

