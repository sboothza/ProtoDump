using Google.Protobuf;

using protodumplib;

namespace tests
{
	[TestFixture]
	public class PerformanceTests
	{
		private const int LOOPS = 1000000;

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
			byte[] data = Array.Empty<byte>();
			for (var i = 0; i < LOOPS; i++)
			{
				data = codec.Serialize(person);
			}
			var spent = DateTime.Now - start;
			Console.WriteLine($"TestSerializePerformance: {spent.TotalMilliseconds:0#} Size:{data.Length}");
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
			var data = codec.Serialize(person);
			var p = new Person_v2();
			codec.Init(data);
			codec.Deserialize(p);

			var start = DateTime.Now;
			for (var i = 0; i < LOOPS; i++)
			{
				p = new Person_v2();
				codec.Init(data);
				codec.Deserialize(p);
			}
			var spent = DateTime.Now - start;
			Console.WriteLine($"TestDeSerializePerformance: {spent.TotalMilliseconds:0#} Size:{data.Length}");
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
			byte[] data = Array.Empty<byte>();
			var start = DateTime.Now;
			for (var i = 0; i < LOOPS; i++)
			{
				stream.Seek(0, SeekOrigin.Begin);
				person.WriteTo(stream);
				data = new byte[stream.Length];
				stream.Read(data, 0, (int)stream.Length);
			}
			var spent = DateTime.Now - start;
			Console.WriteLine($"TestProtoSerializePerformance: {spent.TotalMilliseconds:0#} Size:{data.Length}");
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
			var data = new byte[stream.Length];
			stream.Seek(0, SeekOrigin.Begin);
			stream.Read(data, 0, (int)stream.Length);

			var start = DateTime.Now;
			for (var i = 0; i < LOOPS; i++)
			{
				stream.Seek(0, SeekOrigin.Begin);
				stream.Write(data, 0, data.Length);
				stream.Seek(0, SeekOrigin.Begin);
				PersonProto_v2 p = PersonProto_v2.Parser.ParseFrom(stream);
			}
			var spent = DateTime.Now - start;
			Console.WriteLine($"TestProtoDeSerializePerformance: {spent.TotalMilliseconds:0#} Size:{data.Length}");
		}
	}
}