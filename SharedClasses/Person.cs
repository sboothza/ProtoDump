using protodumplib;

namespace protodump
{
	public class Person : Dumpable
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public int Id { get; set; }
		public DateTime Birthdate { get; set; }
		public string Address { get; set; }

		public override void Deserialize(DumpCodec codec,IDumpField field)
		{
			switch (field.FieldNo)
			{
				case 1:
					Name = ((DumpFieldString)field).Value;
					break;
				case 2:
					Surname = ((DumpFieldString)field).Value;
					break;
				case 3:
					Id = ((DumpFieldInt)field).Value;
					break;
				case 4:
					Birthdate = new DateTime(((DumpFieldLong)field).Value);
					break;
				case 5:
					Address = ((DumpFieldString)field).Value;
					break;
			}
		}

		public override void Serialize(DumpCodec codec)
		{
			codec.WriteString(1, Name);
			codec.WriteString(2, Surname);
			codec.WriteInt(3, Id);
			codec.WriteLong(4, Birthdate.Ticks);
			codec.WriteString(5, Address);
			codec.WriteEnd();
		}
	}
}

