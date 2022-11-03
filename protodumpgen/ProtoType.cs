namespace protodumpgen
{
	public enum ProtoType
	{
		UNKNOWN,
		DOUBLE,
		FLOAT,
		INT32,
		INT64,
		UINT32,
		UINT64,
		SINT32,
		SINT64,
		FIXED32,
		FIXED64,
		SFIXED32,
		SFIXED64,
		BOOL,
		STRING,
		BYTES
	}

	public static class TypeHelper
	{
		public static bool IsCustomType(this string typeName, List<Message> messages)
		{
			if (Enum.TryParse<ProtoType>(typeName, true, out var type))
				return false;
			if (messages.Any(m => string.Equals(m.Name, typeName, StringComparison.OrdinalIgnoreCase)))
				return true;
			throw new InvalidCastException($"type {typeName} not found");
		}
		public static string GetTypeFromString(this string typeName, List<Message> messages)
		{
			if (Enum.TryParse<ProtoType>(typeName, true, out var type))
				return type.ToString();
			if (messages.Any(m => string.Equals(m.Name, typeName, StringComparison.OrdinalIgnoreCase)))
				return typeName;
			throw new InvalidCastException($"type {typeName} not found");
		}

		public static string GetCSType(this string type, List<Message> messages)
		{
			switch (type)
			{
				case nameof(ProtoType.DOUBLE):
				case nameof(ProtoType.FLOAT):
					return "double";
				case nameof(ProtoType.INT32):
				case nameof(ProtoType.SINT32):
					return "int";
				case nameof(ProtoType.INT64):
				case nameof(ProtoType.SINT64):
					return "long";
				case nameof(ProtoType.UINT32):
					return "uint";
				case nameof(ProtoType.UINT64):
					return "ulong";
				case nameof(ProtoType.FIXED32):
				case nameof(ProtoType.FIXED64):
				case nameof(ProtoType.SFIXED32):
				case nameof(ProtoType.SFIXED64):
				case nameof(ProtoType.BYTES):
					throw new InvalidCastException($"unsupported type {type}");
				case nameof(ProtoType.BOOL):
					return "byte";
				case nameof(ProtoType.STRING):
					return "string";
				default:
					if (messages.Any(m => string.Equals(m.Name, type, StringComparison.OrdinalIgnoreCase)))
						return type;
					throw new InvalidCastException($"unknown type {type}");
			}
		}
		public static string GetCSReader(this string type, List<Message> messages)
		{
			switch (type)
			{
				case nameof(ProtoType.DOUBLE):
				case nameof(ProtoType.FLOAT):
					return "ReadDouble";
				case nameof(ProtoType.INT32):
				case nameof(ProtoType.SINT32):
					return "ReadInt";
				case nameof(ProtoType.INT64):
				case nameof(ProtoType.SINT64):
					return "ReadLong";
				case nameof(ProtoType.UINT32):
					return "ReadUInt";
				case nameof(ProtoType.UINT64):
					return "ReadULong";
				case nameof(ProtoType.FIXED32):
				case nameof(ProtoType.FIXED64):
				case nameof(ProtoType.SFIXED32):
				case nameof(ProtoType.SFIXED64):
				case nameof(ProtoType.BYTES):
					throw new InvalidCastException($"unsupported type {type}");
				case nameof(ProtoType.BOOL):
					return "ReadByte";
				case nameof(ProtoType.STRING):
					return "ReadString";

				default:
					if (messages.Any(m => string.Equals(m.Name, type, StringComparison.OrdinalIgnoreCase)))
						return type;
					throw new InvalidCastException($"unknown type {type}");
			}
		}

		public static string GetCSWriter(this string type, List<Message> messages)
		{
			switch (type)
			{
				case nameof(ProtoType.DOUBLE):
				case nameof(ProtoType.FLOAT):
					return "WriteDouble";
				case nameof(ProtoType.INT32):
				case nameof(ProtoType.SINT32):
					return "WriteInt";
				case nameof(ProtoType.INT64):
				case nameof(ProtoType.SINT64):
					return "WriteLong";
				case nameof(ProtoType.UINT32):
					return "WriteUInt";
				case nameof(ProtoType.UINT64):
					return "WriteULong";
				case nameof(ProtoType.FIXED32):
				case nameof(ProtoType.FIXED64):
				case nameof(ProtoType.SFIXED32):
				case nameof(ProtoType.SFIXED64):
				case nameof(ProtoType.BYTES):
					throw new InvalidCastException($"unsupported type {type}");
				case nameof(ProtoType.BOOL):
					return "WriteByte";
				case nameof(ProtoType.STRING):
					return "WriteString";

				default:
					if (messages.Any(m => string.Equals(m.Name, type, StringComparison.OrdinalIgnoreCase)))
						return type;
					throw new InvalidCastException($"unknown type {type}");
			}
		}
	}
}
