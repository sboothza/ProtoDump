using System;
using protodumplib;

namespace protodump
{
    public class Person : DumpObject
    {
        public string Name
        {
            get => Fields[1].GetValue<string>();
            set => Fields[1].SetValue<string>(value);
        }
        public string Surname
        {
            get => Fields[2].GetValue<string>();
            set => Fields[2].SetValue<string>(value);
        }
        public int Id
        {
            get => Fields[3].GetValue<int>();
            set => Fields[3].SetValue<int>(value);
        }
        public DateTime Birthdate
        {
            get => Fields[4].GetValue<DateTime>();
            set => Fields[4].SetValue<DateTime>(value);
        }
        public string Address
        {
            get => Fields[5].GetValue<string>();
            set => Fields[5].SetValue<string>(value);
        }

        public Person()
        {
            Fields[1] = new DumpField<string>(1);
            Fields[2] = new DumpField<string>(2);
            Fields[3] = new DumpField<int>(3);
            Fields[4] = new DumpField<DateTime>(4);
            Fields[5] = new DumpField<string>(5);
        }
    }
}

