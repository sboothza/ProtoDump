using System;
using System.Xml.Linq;
using protodump;

namespace protodumplib
{
    public class Address : DumpObject
    {
        public string Street
        {
            get => Fields[1].GetValue<string>();
            set => Fields[1].SetValue<string>(value);
        }
        public string Suburb
        {
            get => Fields[2].GetValue<string>();
            set => Fields[2].SetValue<string>(value);
        }
        public string City
        {
            get => Fields[3].GetValue<string>();
            set => Fields[3].SetValue<string>(value);
        }
        public string Code
        {
            get => Fields[4].GetValue<string>();
            set => Fields[4].SetValue<string>(value);
        }

        public Address()
        {
            Fields[1] = new DumpField<string>(1);
            Fields[2] = new DumpField<string>(2);
            Fields[3] = new DumpField<string>(3);
            Fields[4] = new DumpField<string>(4);
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
                _address.LoadFrom(Fields[6].GetObject());
                return _address;
            }
            set
            {
                Fields[6].SetObject(value);
            }
        }
        public Person_v2() : base()
        {
            Fields[6] = new DumpField<DumpObject>(6);
        }
    }
}

