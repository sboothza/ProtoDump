using System;
using Google.Protobuf;
using protodump;
using protodumplib;

namespace tests
{
    [TestFixture]
    public class PerformanceTests
    {
        [Test]
        public void TestSerializePerformance()
        {
            var person = new Person_v2
            {
                Name = "Stephen",
                Surname = "Booth",
                Id = 123,
                Birthdate = DateTime.Parse("1974/03/15"),
                Address = new Address { Street = "24 Mountain Road", Suburb = "Roundhay", City = "Somerset West", Code = "7130" }
            };

            var codec = new DumpCodec();
            var start = DateTime.Now;
            for (var i = 0; i < 1000; i++)
            {
                var data = codec.Serialize(person);
            }
            var spent = DateTime.Now - start;
            Console.WriteLine("TestSerializePerformance");
            Console.WriteLine(spent.TotalMilliseconds);
        }

        [Test]
        public void TestDeSerializePerformance()
        {
            var person = new Person_v2
            {
                Name = "Stephen",
                Surname = "Booth",
                Id = 123,
                Birthdate = DateTime.Parse("1974/03/15"),
                Address = new Address { Street = "24 Mountain Road", Suburb = "Roundhay", City = "Somerset West", Code = "7130" }
            };

            var codec = new DumpCodec();
            var start = DateTime.Now;
            for (var i = 0; i < 1000; i++)
            {
                var p = new Person_v2();
                codec.Seek(0);
                codec.ReadObject(p);
            }
            var spent = DateTime.Now - start;
            Console.WriteLine("TestDeSerializePerformance");
            Console.WriteLine(spent.TotalMilliseconds);
        }

        [Test]
        public void TestProtoSerializePerformance()
        {
            var person = new PersonProto_v2
            {
                Name = "Stephen",
                Surname = "Booth",
                Id = 123,
                Birthdate = DateTime.Parse("1974/03/15").Ticks,
                Address = new AddressProto { Street = "24 Mountain Road", Suburb = "Roundhay", City = "Somerset West", Code = "7130" }
            };

            var stream = new MemoryStream(1024);

            var start = DateTime.Now;
            for (var i = 0; i < 1000; i++)
            {
                stream.Seek(0, SeekOrigin.Begin);
                person.WriteTo(stream);
            }
            var spent = DateTime.Now - start;
            Console.WriteLine("TestProtoSerializePerformance");
            Console.WriteLine(spent.TotalMilliseconds);
        }

        [Test]
        public void TestProtoDeSerializePerformance()
        {
            var person = new PersonProto_v2
            {
                Name = "Stephen",
                Surname = "Booth",
                Id = 123,
                Birthdate = DateTime.Parse("1974/03/15").Ticks,
                Address = new AddressProto { Street = "24 Mountain Road", Suburb = "Roundhay", City = "Somerset West", Code = "7130" }
            };

            var stream = new MemoryStream(1024);
            person.WriteTo(stream);

            var start = DateTime.Now;
            for (var i = 0; i < 1000; i++)
            {
                stream.Seek(0, SeekOrigin.Begin);
                PersonProto_v2 p = PersonProto_v2.Parser.ParseFrom(stream);
            }
            var spent = DateTime.Now - start;
            Console.WriteLine("TestProtoDeSerializePerformance");
            Console.WriteLine(spent.TotalMilliseconds);
        }
    }
}

