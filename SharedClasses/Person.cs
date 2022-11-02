using System;
using protodumplib;

namespace protodump
{
    public class Person : DumpObject
    {
        public string Name
        {
            get => ((DumpFieldString)Fields[1]).Value;
            set => ((DumpFieldString)Fields[1]).Value = value;
        }

        public string Surname
        {
            get => ((DumpFieldString)Fields[2]).Value;
            set => ((DumpFieldString)Fields[2]).Value = value;
        }
        public int Id
        {
            get => ((DumpFieldInt)Fields[3]).Value;
            set => ((DumpFieldInt)Fields[3]).Value = value;
        }
        public DateTime Birthdate
        {
            get => new DateTime(((DumpFieldLong)Fields[4]).Value);
            set => ((DumpFieldLong)Fields[4]).Value = value.Ticks;
        }
        public string Address
        {
            get => ((DumpFieldString)Fields[5]).Value;
            set => ((DumpFieldString)Fields[5]).Value = value;
        }

        public Person()
        {
            AddField(new DumpFieldString(1, String.Empty));
            AddField(new DumpFieldString(2, String.Empty));
            AddField(new DumpFieldInt(3, 0));
            AddField(new DumpFieldLong(4, 0));
            AddField(new DumpFieldString(5, String.Empty));
        }
    }


}

