using protodumplib;
namespace prototest
{
	public class PersonProto_v2 : Dumpable
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public int Id { get; set; }
		public long Birthdate { get; set; }
		public AddressProto Address { get; set; }

		public PersonProto_v2()
		{
			Address = new AddressProto();

		}

		public override void Deserialize(DumpCodec codec, DumpField field)
		{
			switch (field.FieldNo)
			{
				case 1:
					Name = codec.ReadString();
					break;
				case 2:
					Surname = codec.ReadString();
					break;
				case 3:
					Id = codec.ReadInt();
					break;
				case 4:
					Birthdate = codec.ReadLong();
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
			codec.WriteLong(4, Birthdate);
			codec.WriteObject(6, Address);

			codec.WriteEnd();
		}
	}
}