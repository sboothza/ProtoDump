using protodump;

namespace protodumplib
{
	public struct DumpField
	{
		public byte FieldNo { get; set; }
		public DumpType FieldType { get; set; }

		public override string ToString()
		{
			return $"{FieldNo}:{FieldType}";
		}
	}
}
