using System;
using System.Runtime.CompilerServices;
using protodumplib;

namespace protodump
{
    public class Person : DumpObject
    {
        public string Name
        {
            get => Fields.ContainsKey(1) ? ((DumpFieldString)Fields[1]).Value : string.Empty;
            set => Fields[1] = new DumpFieldString(1, value);
        }

        public string Surname
        {
            get => Fields.ContainsKey(2) ? ((DumpFieldString)Fields[2]).Value : string.Empty;
            set => Fields[2] = new DumpFieldString(2, value);
        }
        public int Id
        {
            get => Fields.ContainsKey(3) ? ((DumpFieldInt)Fields[3]).Value : 0;
            set => Fields[3] = new DumpFieldInt(3, value);
        }
        public DateTime Birthdate
        {
            get => Fields.ContainsKey(4) ? new DateTime(((DumpFieldLong)Fields[4]).Value) : DateTime.MinValue;
            set => Fields[4] = new DumpFieldLong(4, value.Ticks);
        }
        public string Address
        {
            get => Fields.ContainsKey(5) ? ((DumpFieldString)Fields[5]).Value : string.Empty;
            set => Fields[5] = new DumpFieldString(5, value);
        }

        public Person()
        {
            //AddField(new DumpFieldString(1, String.Empty));
            //AddField(new DumpFieldString(2, String.Empty));
            //AddField(new DumpFieldInt(3, 0));
            //AddField(new DumpFieldLong(4, 0));
            //AddField(new DumpFieldString(5, String.Empty));
        }
    }


}

