using protodump;

namespace protodumplib
{
	public class Address : Dumpable
	{
		public string Street { get; set; }
		public string Suburb { get; set; }
		public string City { get; set; }
		public string Code { get; set; }

		public override void Deserialize(DumpCodec codec, DumpField field)
		{
			switch (field.FieldNo)
			{
				case 1:
					Street = codec.ReadString();
					break;
				case 2:
					Suburb = codec.ReadString();
					break;
				case 3:
					City = codec.ReadString();
					break;
				case 4:
					Code = codec.ReadString();
					break;
				default:
					codec.SkipField(field.FieldType);
					break;
			}
		}

		public override void Serialize(DumpCodec codec)
		{
			codec.WriteString(1, Street);
			codec.WriteString(2, Suburb);
			codec.WriteString(3, City);
			codec.WriteString(4, Code);
			codec.WriteEnd();
		}

		public override string ToString()
		{
			return $"{Street},{Suburb},{City},{Code}";
		}
	}

	public class Person_v2 : Person
	{
		public new Address Address { get; set; }

		public Person_v2()
		{
			Address = new Address();
		}

		public override void Deserialize(DumpCodec codec, DumpField field)
		{
			switch (field.FieldNo)
			{
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
					base.Deserialize(codec, field);
					break;
				case 6:
					codec.Deserialize(Address);
					break;
				default:
					codec.SkipField(field.FieldType);
					break;
			}
		}

		public override void Serialize(DumpCodec codec)
		{
			codec.WriteString(1, Name);
			codec.WriteString(2, Surname);
			codec.WriteInt(3, Id);
			codec.WriteLong(4, Birthdate.Ticks);
			codec.WriteObject(6, Address);
			codec.WriteEnd();
		}
	}
}
