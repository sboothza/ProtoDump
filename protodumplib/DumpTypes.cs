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
        Object=7
    }
}

