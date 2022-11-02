using System;
using System.Net;
using protodump;


namespace protodumplib
{
    public class Address : Dumpable
    {
        public string Street { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string Code { get; set; }

        public override void Deserialize(DumpObject obj)
        {
            Street = obj.Fields.ContainsKey(1) ? ((DumpFieldString)obj.Fields[1]).Value : string.Empty;
            Suburb = obj.Fields.ContainsKey(2) ? ((DumpFieldString)obj.Fields[2]).Value : string.Empty;
            City = obj.Fields.ContainsKey(3) ? ((DumpFieldString)obj.Fields[3]).Value : string.Empty;
            Code = obj.Fields.ContainsKey(4) ? ((DumpFieldString)obj.Fields[4]).Value : string.Empty;
        }

        public override void Serialize(DumpObject obj)
        {
            obj.Fields[1] = new DumpFieldString(1, Street);
            obj.Fields[2] = new DumpFieldString(2, Suburb);
            obj.Fields[3] = new DumpFieldString(3, City);
            obj.Fields[4] = new DumpFieldString(4, Code);
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

        public override void Deserialize(DumpObject obj)
        {
            base.Deserialize(obj);
            if (obj.Fields.ContainsKey(6))
            {
                var addr = ((DumpFieldObject)obj.Fields[6]).Value;
                Address.Deserialize(addr);
            }     
        }

        public override void Serialize(DumpObject obj)
        {
            base.Serialize(obj);
            var address = new DumpObject();
            Address.Serialize(address);
            obj.Fields[6] = new DumpFieldObject(6, address);
        }
    }
}

