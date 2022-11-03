using protodump;

namespace protodumplib
{
	public abstract class Dumpable
	{
		public abstract void Serialize(DumpCodec codec);
		public abstract void Deserialize(DumpCodec codec, DumpField field);
	}
}