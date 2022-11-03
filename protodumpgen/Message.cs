namespace protodumpgen
{
	public class Message
	{
		public string Name { get; set; }
		public List<Field> Fields { get; set; }
		public Message()
		{
			Fields = new List<Field>();
		}
		public override string ToString()
		{
			return $"{Name}";
		}
	}

	public class Field
	{
		public string Name { get; set; }
		public string Type { get; set; }
		public int FieldNo { get; set; }

		public override string ToString()
		{
			return $"{Type}:{Name}:{FieldNo}";
		}
	}
}
