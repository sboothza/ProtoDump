using protodump;



namespace protodumplib
{
	public class Address : Dumpable
	{
		public string Street { get; set; }
		public string Suburb { get; set; }
		public string City { get; set; }
		public string Code { get; set; }

		public override void Deserialize(DumpCodec codec, IDumpField field)
		{
			switch (field.FieldNo)
			{
				case 1:
					Street = ((DumpFieldString)field).Value;
					break;
				case 2:
					Suburb = ((DumpFieldString)field).Value;
					break;
				case 3:
					City = ((DumpFieldString)field).Value;
					break;
				case 4:
					Code = ((DumpFieldString)field).Value;
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

		public override void Deserialize(DumpCodec codec, IDumpField field)
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
					var addr = ((DumpFieldObject)field).Value;
					codec.Deserialize(Address, addr);
					break;
			}
		}

		public override void Serialize(DumpCodec codec)
		{
			codec.WriteString(1, Name);
			codec.WriteString(2, Surname);
			codec.WriteInt(3, Id);
			codec.WriteLong(4, Birthdate.Ticks);
			//codec.WriteString(5, Address.ToString());
			codec.WriteObject(6, Address);
			codec.WriteEnd();
		}
	}
}

