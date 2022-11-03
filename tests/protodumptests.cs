using Google.Protobuf;

using protodump;

using protodumplib;

namespace tests;

[TestFixture]
public class Tests
{
	[Test]
	public void TestRaw()
	{
		var codec = new DumpCodec();

		codec.WriteByte(1);
		codec.WriteDouble(2);
		codec.WriteString("this is a test");
		codec.WriteInt(456);
		codec.WriteLong(-890);

		var buf = codec.GetData();

		codec = new DumpCodec(buf);

		var v1 = codec.ReadByte();
		var v2 = codec.ReadDouble();
		var v3 = codec.ReadString();
		var v4 = codec.ReadInt();
		var v5 = codec.ReadLong();
		Assert.Multiple(() =>
		{
			Assert.That(v1, Is.EqualTo(1));
			Assert.That(v2, Is.EqualTo(2));
			Assert.That(v3, Is.EqualTo("this is a test"));
			Assert.That(v4, Is.EqualTo(456));
			Assert.That(v5, Is.EqualTo(-890));
		});
	}

	[Test]
	public void TestSerializeDeSerialize()
	{
		var person = new Person
		{
			Name = "Stephen",
			Surname = "Booth",
			Id = 123,
			Birthdate = DateTime.Parse("1974/03/15"),
			Address = "24 Mountain Road, Roundhay, Somerset West"
		};

		var codec = new DumpCodec();
		var data = codec.Serialize(person);

		codec = new DumpCodec(data);
		var p = new Person();
		codec.Deserialize(p);
		Assert.Multiple(() =>
		{
			Assert.That(p.Name, Is.EqualTo("Stephen"));
			Assert.That(p.Surname, Is.EqualTo("Booth"));
			Assert.That(p.Id, Is.EqualTo(123));
			Assert.That(p.Birthdate, Is.EqualTo(DateTime.Parse("1974/03/15")));
			Assert.That(p.Address, Is.EqualTo("24 Mountain Road, Roundhay, Somerset West"));
		});
	}

	[Test]
	public void TestSerializeParentDeSerializeChild()
	{
		var person = new Person
		{
			Name = "Stephen",
			Surname = "Booth",
			Id = 123,
			Birthdate = DateTime.Parse("1974/03/15"),
			Address = "24 Mountain Road, Roundhay, Somerset West"
		};

		var codec = new DumpCodec();
		var data = codec.Serialize(person);

		codec = new DumpCodec(data);
		var p = new Person_v2();
		codec.Deserialize(p);
		Console.WriteLine(p.Address.Street);
		Assert.Multiple(() =>
		{
			Assert.That(p.Name, Is.EqualTo("Stephen"));
			Assert.That(p.Surname, Is.EqualTo("Booth"));
			Assert.That(p.Id, Is.EqualTo(123));
			Assert.That(p.Birthdate, Is.EqualTo(DateTime.Parse("1974/03/15")));
		});
	}

	[Test]
	public void TestSerializeChildDeSerializeParent()
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

		codec = new DumpCodec(data);
		var p = new Person();
		codec.Deserialize(p);
		Assert.Multiple(() =>
		{
			Assert.That(p.Name, Is.EqualTo("Stephen"));
			Assert.That(p.Surname, Is.EqualTo("Booth"));
			Assert.That(p.Id, Is.EqualTo(123));
			Assert.That(p.Birthdate, Is.EqualTo(DateTime.Parse("1974/03/15")));
		});
	}

	[Test]
	public void TestSerializeChildDeSerializeChild()
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

		codec = new DumpCodec(data);
		var p = new Person_v2();
		codec.Deserialize(p);
		Console.WriteLine($"Size: {data.Length}");
		Assert.Multiple(() =>
		{
			Assert.That(p.Name, Is.EqualTo("Stephen"));
			Assert.That(p.Surname, Is.EqualTo("Booth"));
			Assert.That(p.Id, Is.EqualTo(123));
			Assert.That(p.Birthdate, Is.EqualTo(DateTime.Parse("1974/03/15")));
			Assert.That(p.Address.Street, Is.EqualTo("24 Mountain Road"));
		});
	}

	[Test]
	public void TestList()
	{
		var person = new Person_v2
		{
			Name = "Stephen",
			Surname = "Booth",
			Id = 123,
			Birthdate = DateTime.Parse("1974/03/15"),
			Address = new Address { Street = "24 Mountain Road", Suburb = "Roundhay", City = "Somerset West", Code = "7130" },
			Phone = new List<string> { "123", "456", "789" },
			Addresses = new List<Address> {
				new Address {
					Street = "24 Mountain Road",
					Suburb = "Roundhay", City = "Somerset West", Code = "7130" }, new Address { Street = "25 Mountain Road", Suburb = "Roundhay", City = "Somerset West", Code = "7130" }, new Address { Street = "26 Mountain Road", Suburb = "Roundhay", City = "Somerset West", Code = "7130" } },
		};

		var codec = new DumpCodec();
		var data = codec.Serialize(person);

		codec = new DumpCodec(data);
		var p = new Person_v2();
		codec.Deserialize(p);
		Console.WriteLine($"Size: {data.Length}");
		Assert.Multiple(() =>
		{
			Assert.That(p.Name, Is.EqualTo("Stephen"));
			Assert.That(p.Surname, Is.EqualTo("Booth"));
			Assert.That(p.Id, Is.EqualTo(123));
			Assert.That(p.Birthdate, Is.EqualTo(DateTime.Parse("1974/03/15")));
			Assert.That(p.Address.Street, Is.EqualTo("24 Mountain Road"));
			Assert.That(p.Phone[1], Is.EqualTo("456"));
			Assert.That(p.Addresses[1].Street, Is.EqualTo("25 Mountain Road"));
		});
	}

	[Test]
	public void TestProto()
	{
		var person = new PersonProto
		{
			Name = "Stephen",
			Surname = "Booth",
			Id = 123,
			Birthdate = DateTime.Parse("1974/03/15").Ticks,
			Address = "24 Mountain Road, Roundhay, Somerset West"
		};

		var stream = new MemoryStream(1024);
		person.WriteTo(stream);
		stream.Seek(0, SeekOrigin.Begin);

		PersonProto p = PersonProto.Parser.ParseFrom(stream);
		Assert.Multiple(() =>
		{
			Assert.That(p.Name, Is.EqualTo("Stephen"));
			Assert.That(p.Surname, Is.EqualTo("Booth"));
			Assert.That(p.Id, Is.EqualTo(123));
			Assert.That(p.Birthdate, Is.EqualTo(DateTime.Parse("1974/03/15").Ticks));
			Assert.That(p.Address, Is.EqualTo("24 Mountain Road, Roundhay, Somerset West"));
		});
	}

	[Test]
	public void TestProtoSerializeChildDeSerializeChild()
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
		stream.Seek(0, SeekOrigin.Begin);

		PersonProto_v2 p = PersonProto_v2.Parser.ParseFrom(stream);
		Assert.Multiple(() =>
		{
			Assert.That(p.Name, Is.EqualTo("Stephen"));
			Assert.That(p.Surname, Is.EqualTo("Booth"));
			Assert.That(p.Id, Is.EqualTo(123));
			Assert.That(p.Birthdate, Is.EqualTo(DateTime.Parse("1974/03/15").Ticks));
			Assert.That(p.Address.Street, Is.EqualTo("24 Mountain Road"));
		});
	}

	[Test]
	public void TestGenerated()
	{
		var person = new prototest.PersonProto
		{
			Name = "Stephen",
			Surname = "Booth",
			Id = 123,
			Birthdate = DateTime.Parse("1974/03/15").Ticks,
			Address = "24 Mountain Road, Roundhay, Somerset West"
		};

		var codec = new DumpCodec();
		var data = codec.Serialize(person);

		codec = new DumpCodec(data);
		var p = new prototest.PersonProto();
		codec.Deserialize(p);
		Console.WriteLine($"Size: {data.Length}");
		Assert.Multiple(() =>
		{
			Assert.That(p.Name, Is.EqualTo("Stephen"));
			Assert.That(p.Surname, Is.EqualTo("Booth"));
			Assert.That(p.Id, Is.EqualTo(123));
			Assert.That(p.Birthdate, Is.EqualTo(DateTime.Parse("1974/03/15").Ticks));
			Assert.That(p.Address, Is.EqualTo("24 Mountain Road, Roundhay, Somerset West"));
		});
	}

	[Test]
	public void TestGenerated_v2()
	{
		var person = new prototest.PersonProto_v2
		{
			Name = "Stephen",
			Surname = "Booth",
			Id = 123,
			Birthdate = DateTime.Parse("1974/03/15").Ticks,
			Address = new prototest.AddressProto { Street = "24 Mountain Road", Suburb = "Roundhay", City = "Somerset West", Code = "7130" }
		};

		var codec = new DumpCodec();
		var data = codec.Serialize(person);

		codec = new DumpCodec(data);
		var p = new prototest.PersonProto_v2();
		codec.Deserialize(p);
		Console.WriteLine($"Size: {data.Length}");
		Assert.Multiple(() =>
		{
			Assert.That(p.Name, Is.EqualTo("Stephen"));
			Assert.That(p.Surname, Is.EqualTo("Booth"));
			Assert.That(p.Id, Is.EqualTo(123));
			Assert.That(p.Birthdate, Is.EqualTo(DateTime.Parse("1974/03/15").Ticks));
			Assert.That(p.Address.Street, Is.EqualTo("24 Mountain Road"));
		});
	}
}
