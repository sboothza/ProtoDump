using protodumplib;
namespace prototest
{
	public class AddressProto : Dumpable
	{
		public string Street { get; set; }
		public string Suburb { get; set; }
		public string City { get; set; }
		public string Code { get; set; }

		public AddressProto()
		{

		}

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
	}
}