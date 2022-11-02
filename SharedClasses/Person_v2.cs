using System;
using System.Xml.Linq;
using protodump;

namespace protodumplib
{
    public class Address : DumpObject
    {
        public string Street
        {
            get => Fields.ContainsKey(1) ? ((DumpFieldString)Fields[1]).Value : string.Empty;
            set => Fields[1] = new DumpFieldString(1, value);
        }
        public string Suburb
        {
            get => Fields.ContainsKey(2) ? ((DumpFieldString)Fields[2]).Value : string.Empty;
            set => Fields[2] = new DumpFieldString(2, value);
        }
        public string City
        {
            get => Fields.ContainsKey(3) ? ((DumpFieldString)Fields[3]).Value : string.Empty;
            set => Fields[3] = new DumpFieldString(3, value);
        }
        public string Code
        {
            get => Fields.ContainsKey(4) ? ((DumpFieldString)Fields[4]).Value : string.Empty;
            set => Fields[4] = new DumpFieldString(4, value);
        }

        public Address()
        {
            //AddField(new DumpFieldString(1, String.Empty));
            //AddField(new DumpFieldString(2, String.Empty));
            //AddField(new DumpFieldString(3, String.Empty));
            //AddField(new DumpFieldString(4, String.Empty));
        }

        public override string ToString()
        {
            return $"{Street},{Suburb},{City},{Code}";
        }
    }

    public class Person_v2 : Person
    {
        private Address _address;
        public new Address Address
        {
            get
            {
                _address ??= new Address();
                if (Fields.ContainsKey(6))
                    _address.LoadFrom(((DumpFieldObject)Fields[6]).Value);
                return _address;
            }
            set => Fields[6] = new DumpFieldObject(6, value);
        }
        public Person_v2() : base()
        {
            AddField(new DumpFieldObject(6, null));
        }
    }
}

