using protodump;
using protodumplib;

namespace tests;

[TestFixture]
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestRaw()
    {
        var codec = new Codec();

        codec.WriteByte(1);
        codec.WriteDouble(2);
        codec.WriteString("this is a test");
        codec.WriteInt(456);
        codec.WriteDate(DateTime.Today);
        codec.WriteLong(-890);

        var buf = codec.GetData();

        codec = new Codec(buf);

        var v1 = codec.ReadByte();
        var v2 = codec.ReadDouble();
        var v3 = codec.ReadString();
        var v4 = codec.ReadInt();
        var v5 = codec.ReadDate();
        var v6 = codec.ReadLong();

        Assert.That(v1, Is.EqualTo(1));
        Assert.That(v2, Is.EqualTo(2));
        Assert.That(v3, Is.EqualTo("this is a test"));
        Assert.That(v4, Is.EqualTo(456));
        Assert.That(v5, Is.EqualTo(DateTime.Today));
        Assert.That(v6, Is.EqualTo(-890));
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

        var codec = new Codec();
        var data = codec.Serialize((DumpObject)person);

        codec = new Codec(data);
        var p = new Person();
        codec.ReadObject(p);
        //var p = codec.DeSerialize<Person>(data);

        Assert.That(p.Name, Is.EqualTo(person.Name));
        Assert.That(p.Surname, Is.EqualTo(person.Surname));
        Assert.That(p.Id, Is.EqualTo(person.Id));
        Assert.That(p.Birthdate, Is.EqualTo(person.Birthdate));
        Assert.That(p.Address, Is.EqualTo(person.Address));
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

        var codec = new Codec();
        var data = codec.Serialize((DumpObject)person);

        codec = new Codec(data);
        var p = new Person_v2();
        codec.ReadObject(p);
        Assert.Multiple(() =>
        {
            //var p = codec.DeSerialize<Person_v2>(data);

            Assert.That(p.Name, Is.EqualTo(person.Name));
            Assert.That(p.Surname, Is.EqualTo(person.Surname));
            Assert.That(p.Id, Is.EqualTo(person.Id));
            Assert.That(p.Birthdate, Is.EqualTo(person.Birthdate));
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
            Address = new Address { Street= "24 Mountain Road",Suburb= "Roundhay",City= "Somerset West",Code="7130" }
        };

        var codec = new Codec();
        var data = codec.Serialize(person);

        codec = new Codec(data);
        var p = new Person_v2();
        codec.ReadObject(p);
        Assert.Multiple(() =>
        {
            Assert.That(p.Name, Is.EqualTo(person.Name));
            Assert.That(p.Surname, Is.EqualTo(person.Surname));
            Assert.That(p.Id, Is.EqualTo(person.Id));
            Assert.That(p.Birthdate, Is.EqualTo(person.Birthdate));
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

        var codec = new Codec();
        var data = codec.Serialize(person);

        codec = new Codec(data);
        var p = new Person_v2();
        codec.ReadObject(p);
        Assert.Multiple(() =>
        {
            Assert.That(p.Name, Is.EqualTo(person.Name));
            Assert.That(p.Surname, Is.EqualTo(person.Surname));
            Assert.That(p.Id, Is.EqualTo(person.Id));
            Assert.That(p.Birthdate, Is.EqualTo(person.Birthdate));
            Assert.That(p.Address.Street, Is.EqualTo(person.Address.Street));
        });
    }

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

        var codec = new Codec();
        var start = DateTime.Now;
        for (var i = 0; i < 1000; i++)
        {
            var data = codec.Serialize(person);
        }
        var spent = DateTime.Now - start;
        Console.WriteLine(spent.TotalMilliseconds);
    }
}
