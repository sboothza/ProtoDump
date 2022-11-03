namespace protodumplib
{
	public enum DumpType
	{
		Unknown = 0,
		Double = 1,     //64bit float
		Byte = 2,
		Int = 3,        //32bit int
		UInt = 4,        //32bit uint
		Long = 5,       //64bit int
		ULong = 6,       //64bit uint
		String = 7,     //pascal string        
		Object = 8,     //nested object
		List = 9        //list of type
	}

	public struct TokenOf<X> : IComparable
	{
		public int CompareTo(object obj)
		{
			if (obj is TokenOf<X>)
				return 0;
			return 1;
		}
	}
}
