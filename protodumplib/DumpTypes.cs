using System;
namespace protodump
{
    public enum DumpType
    {
        Unknown = 0,
        Double = 1,     //64bit float
        Byte = 2,
        Int = 3,        //32bit int
        Long = 4,       //64bit int
        String = 5,     //pascal string
        Date = 6,        //64bit int of ticks - 100-nanosecond intervals that have elapsed since 12:00:00 midnight, January 1, 0001
        Object=7
    }
}

