using System.Runtime.CompilerServices;
using System.Text;

using protodumplib;

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

		public DumpCodec Seek(int position)
		{
			_position = position;
			return this;
		}

		public int Position => _position;

		public byte[] GetData()
		{
			byte[] data = new byte[_position];
			Array.Copy(_data, data, _position);
			return data;
		}

		public byte[] Serialize(Dumpable obj)
		{
			Init();
			obj.Serialize(this);
			return GetData();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public DumpCodec WriteDouble(double value)
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
			return this;
		}

		public DumpCodec WriteDouble(byte fieldNo, double value) =>
			WriteByte(fieldNo).
			WriteByte((byte)DumpType.Double).
			WriteDouble(value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public DumpCodec WriteByte(byte value)
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
			return this;
		}

		public DumpCodec WriteByte(byte fieldNo, byte value)
		{
			WriteByte(fieldNo);
			WriteByte((byte)DumpType.Byte);
			WriteByte(value);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public DumpCodec WriteInt(int value)
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
			return this;
		}

		public DumpCodec WriteInt(byte fieldNo, int value)
		{
			WriteByte(fieldNo);
			WriteByte((byte)DumpType.Int);
			WriteInt(value);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public DumpCodec WriteLong(long value)
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
			return this;
		}

		public DumpCodec WriteLong(byte fieldNo, long value)
		{
			WriteByte(fieldNo);
			WriteByte((byte)DumpType.Long);
			WriteLong(value);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public DumpCodec WriteString(string value)
		{
			if (string.IsNullOrEmpty(value))
				value = string.Empty;

			var data = Encoding.ASCII.GetBytes(value);

			while (_position + data.Length + 1 > _data.Length)
				DoubleSize();

			WriteByte((byte)data.Length);
			Array.Copy(data, 0, _data, _position, data.Length);
			_position += data.Length;
			return this;
		}
		public DumpCodec WriteString(byte fieldNo, string value)
		{
			WriteByte(fieldNo);
			WriteByte((byte)DumpType.String);
			WriteString(value);
			return this;
		}

		public DumpCodec WriteObject(Dumpable obj)
		{
			obj.Serialize(this);
			return this;
		}

		public DumpCodec WriteObject(byte fieldNo, Dumpable obj)
		{
			WriteByte(fieldNo);
			WriteByte((byte)DumpType.Object);
			WriteObject(obj);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public DumpCodec WriteEnd()
		{
			WriteByte(0xff);
			return this;
		}

		private IDumpField ReadField()
		{
			var fieldNo = ReadByte();
			if (fieldNo == 0xff)
				return null;

			return (DumpType)ReadByte() switch
			{
				DumpType.Double => new DumpFieldDouble(fieldNo, ReadDouble()),
				DumpType.Byte => new DumpFieldByte(fieldNo, ReadByte()),
				DumpType.Int => new DumpFieldInt(fieldNo, ReadInt()),
				DumpType.Long => new DumpFieldLong(fieldNo, ReadLong()),
				DumpType.String => new DumpFieldString(fieldNo, ReadString()),
				DumpType.Object => new DumpFieldObject(fieldNo, ReadObject()),
				_ => null,
			};
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
			var field = ReadField();
			while (field != null)
			{
				obj.Deserialize(this, field);
				field = ReadField();
			}

			//var dumpObj = new DumpObject();
			//ReadObject(dumpObj);
			//foreach (var field in dumpObj)
			//	obj.Deserialize(this, field);
		}

		public void Deserialize(Dumpable obj, DumpObject dumpObj)
		{
			foreach (var field in dumpObj)
				obj.Deserialize(this, field);
		}
	}
}