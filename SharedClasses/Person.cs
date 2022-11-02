using System;
using System.Runtime.CompilerServices;
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

        public override void Deserialize(DumpObject obj)
        {
            Name = obj.Fields.ContainsKey(1) ? ((DumpFieldString)obj.Fields[1]).Value : string.Empty;
            Surname = obj.Fields.ContainsKey(2) ? ((DumpFieldString)obj.Fields[2]).Value : string.Empty;
            Id = obj.Fields.ContainsKey(3) ? ((DumpFieldInt)obj.Fields[3]).Value : 0;
            Birthdate = obj.Fields.ContainsKey(4) ? new DateTime(((DumpFieldLong)obj.Fields[4]).Value) : DateTime.MinValue;
            Address = obj.Fields.ContainsKey(5) ? ((DumpFieldString)obj.Fields[5]).Value : string.Empty;
        }

        public override void Serialize(DumpObject obj)
        {
            obj.Fields[1] = new DumpFieldString(1, Name);
            obj.Fields[2] = new DumpFieldString(2, Surname);
            obj.Fields[3] = new DumpFieldInt(3, Id);
            obj.Fields[4] = new DumpFieldLong(4, Birthdate.Ticks);
            obj.Fields[5] = new DumpFieldString(5, Address);
        }
    }
}

