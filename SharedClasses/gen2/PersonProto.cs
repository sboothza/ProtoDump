using protodumplib;
namespace prototest
{
	public class PersonProto : Dumpable
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public int Id { get; set; }
		public long Birthdate { get; set; }
		public string Address { get; set; }

		public PersonProto()
		{

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
				case 5:
					Address = codec.ReadString();
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
			codec.WriteString(5, Address);

			codec.WriteEnd();
		}
	}
}