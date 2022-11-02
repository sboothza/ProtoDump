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

        /* private void Write<T>(T value)
         {
             var size = Marshal.SizeOf(typeof(T));
             while (_position + size > _data.Length)
                 DoubleSize();

             unsafe
             {
                 fixed (byte* ptr = &(_data[_position]))
                 {
                     Unsafe.Write<T>(ptr, value);
                 }
                 _position += size;
             }
         }*/

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

        public void WriteDate(DateTime value) => WriteLong(value.Ticks);

        public void WriteObject(DumpObject obj) => obj.Serialize(this);

        public void WriteField(IDumpField field)
        {
            WriteByte(field.FieldNo);
            WriteByte((byte)field.FieldType);
            switch (field.FieldType)
            {
                case DumpType.Double: WriteDouble(field.GetValue<double>()); break;
                case DumpType.Byte: WriteByte(field.GetValue<byte>()); break;
                case DumpType.Int: WriteInt(field.GetValue<int>()); break;
                case DumpType.Long: WriteLong(field.GetValue<long>()); break;
                case DumpType.String: WriteString(field.GetValue<string>()); break;
                case DumpType.Object: WriteObject(field.GetObject()); break;
            }
        }

        public void WriteEnd()
        {
            WriteByte(0xff);
        }

        //private T Read<T>()
        //{
        //    var size = Marshal.SizeOf(typeof(T));
        //    if (_position + size > _data.Length)
        //        throw new OverflowException("Not enough data left to read");

        //    unsafe
        //    {
        //        T value;
        //        fixed (byte* ptr = &(_data[_position]))
        //        {
        //            value = Unsafe.Read<T>(ptr);
        //        }
        //        _position += size;
        //        return value;
        //    }
        //}

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
                case DumpType.Object: field = new DumpField<DumpObject>(fieldNo) { Value = ReadObject() }; break;
            }
            return field;
        }

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

        public DateTime ReadDate() => new DateTime(ReadLong());

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

