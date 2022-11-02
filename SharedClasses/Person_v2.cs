using System;
using System.Xml.Linq;
using protodump;

namespace protodumplib
{
    public class Address : DumpObject
    {
        public string Street
        {
            get => ((DumpFieldString)Fields[1]).Value;
            set => ((DumpFieldString)Fields[1]).Value = value;
        }
        public string Suburb
        {
            get => ((DumpFieldString)Fields[2]).Value;
            set => ((DumpFieldString)Fields[2]).Value = value;
        }
        public string City
        {
            get => ((DumpFieldString)Fields[3]).Value;
            set => ((DumpFieldString)Fields[3]).Value = value;
        }
        public string Code
        {
            get => ((DumpFieldString)Fields[4]).Value;
            set => ((DumpFieldString)Fields[4]).Value = value;
        }

        public Address()
        {
            AddField(new DumpFieldString(1, String.Empty));
            AddField(new DumpFieldString(2, String.Empty));
            AddField(new DumpFieldString(3, String.Empty));
            AddField(new DumpFieldString(4, String.Empty));
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
                _address.LoadFrom(((DumpFieldObject)Fields[6]).Value);
                return _address;
            }
            set
            {
                ((DumpFieldObject)Fields[6]).Value = value;
            }
        }
        public Person_v2() : base()
        {
            AddField(new DumpFieldObject(6, null));
        }
    }
}

