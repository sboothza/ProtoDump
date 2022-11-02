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
            AddField(new DumpField<string>(1));
            AddField(new DumpField<string>(2));
            AddField(new DumpField<int>(3));
            AddField(new DumpField<DateTime>(4));
            AddField(new DumpField<string>(5));
        }
    }

  
}

