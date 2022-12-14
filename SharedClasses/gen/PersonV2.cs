// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Person_v2.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
/// <summary>Holder for reflection information generated from Person_v2.proto</summary>
public static partial class PersonV2Reflection {

  #region Descriptor
  /// <summary>File descriptor for Person_v2.proto</summary>
  public static pbr::FileDescriptor Descriptor {
    get { return descriptor; }
  }
  private static pbr::FileDescriptor descriptor;

  static PersonV2Reflection() {
    byte[] descriptorData = global::System.Convert.FromBase64String(
        string.Concat(
          "Cg9QZXJzb25fdjIucHJvdG8iSgoMQWRkcmVzc1Byb3RvEg4KBlN0cmVldBgB",
          "IAEoCRIOCgZTdWJ1cmIYAiABKAkSDAoEQ2l0eRgDIAEoCRIMCgRDb2RlGAQg",
          "ASgJIm4KDlBlcnNvblByb3RvX3YyEgwKBE5hbWUYASABKAkSDwoHU3VybmFt",
          "ZRgCIAEoCRIKCgJJZBgDIAEoBRIRCglCaXJ0aGRhdGUYBCABKAMSHgoHQWRk",
          "cmVzcxgGIAEoCzINLkFkZHJlc3NQcm90b2IGcHJvdG8z"));
    descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
        new pbr::FileDescriptor[] { },
        new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
          new pbr::GeneratedClrTypeInfo(typeof(global::AddressProto), global::AddressProto.Parser, new[]{ "Street", "Suburb", "City", "Code" }, null, null, null, null),
          new pbr::GeneratedClrTypeInfo(typeof(global::PersonProto_v2), global::PersonProto_v2.Parser, new[]{ "Name", "Surname", "Id", "Birthdate", "Address" }, null, null, null, null)
        }));
  }
  #endregion

}
#region Messages
public sealed partial class AddressProto : pb::IMessage<AddressProto>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    , pb::IBufferMessage
#endif
{
  private static readonly pb::MessageParser<AddressProto> _parser = new pb::MessageParser<AddressProto>(() => new AddressProto());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pb::MessageParser<AddressProto> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::PersonV2Reflection.Descriptor.MessageTypes[0]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public AddressProto() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public AddressProto(AddressProto other) : this() {
    street_ = other.street_;
    suburb_ = other.suburb_;
    city_ = other.city_;
    code_ = other.code_;
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public AddressProto Clone() {
    return new AddressProto(this);
  }

  /// <summary>Field number for the "Street" field.</summary>
  public const int StreetFieldNumber = 1;
  private string street_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public string Street {
    get { return street_; }
    set {
      street_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "Suburb" field.</summary>
  public const int SuburbFieldNumber = 2;
  private string suburb_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public string Suburb {
    get { return suburb_; }
    set {
      suburb_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "City" field.</summary>
  public const int CityFieldNumber = 3;
  private string city_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public string City {
    get { return city_; }
    set {
      city_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "Code" field.</summary>
  public const int CodeFieldNumber = 4;
  private string code_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public string Code {
    get { return code_; }
    set {
      code_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override bool Equals(object other) {
    return Equals(other as AddressProto);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public bool Equals(AddressProto other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (Street != other.Street) return false;
    if (Suburb != other.Suburb) return false;
    if (City != other.City) return false;
    if (Code != other.Code) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override int GetHashCode() {
    int hash = 1;
    if (Street.Length != 0) hash ^= Street.GetHashCode();
    if (Suburb.Length != 0) hash ^= Suburb.GetHashCode();
    if (City.Length != 0) hash ^= City.GetHashCode();
    if (Code.Length != 0) hash ^= Code.GetHashCode();
    if (_unknownFields != null) {
      hash ^= _unknownFields.GetHashCode();
    }
    return hash;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void WriteTo(pb::CodedOutputStream output) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    output.WriteRawMessage(this);
  #else
    if (Street.Length != 0) {
      output.WriteRawTag(10);
      output.WriteString(Street);
    }
    if (Suburb.Length != 0) {
      output.WriteRawTag(18);
      output.WriteString(Suburb);
    }
    if (City.Length != 0) {
      output.WriteRawTag(26);
      output.WriteString(City);
    }
    if (Code.Length != 0) {
      output.WriteRawTag(34);
      output.WriteString(Code);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(output);
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
    if (Street.Length != 0) {
      output.WriteRawTag(10);
      output.WriteString(Street);
    }
    if (Suburb.Length != 0) {
      output.WriteRawTag(18);
      output.WriteString(Suburb);
    }
    if (City.Length != 0) {
      output.WriteRawTag(26);
      output.WriteString(City);
    }
    if (Code.Length != 0) {
      output.WriteRawTag(34);
      output.WriteString(Code);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(ref output);
    }
  }
  #endif

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int CalculateSize() {
    int size = 0;
    if (Street.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Street);
    }
    if (Suburb.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Suburb);
    }
    if (City.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(City);
    }
    if (Code.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Code);
    }
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(AddressProto other) {
    if (other == null) {
      return;
    }
    if (other.Street.Length != 0) {
      Street = other.Street;
    }
    if (other.Suburb.Length != 0) {
      Suburb = other.Suburb;
    }
    if (other.City.Length != 0) {
      City = other.City;
    }
    if (other.Code.Length != 0) {
      Code = other.Code;
    }
    _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(pb::CodedInputStream input) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    input.ReadRawMessage(this);
  #else
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
          break;
        case 10: {
          Street = input.ReadString();
          break;
        }
        case 18: {
          Suburb = input.ReadString();
          break;
        }
        case 26: {
          City = input.ReadString();
          break;
        }
        case 34: {
          Code = input.ReadString();
          break;
        }
      }
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
          break;
        case 10: {
          Street = input.ReadString();
          break;
        }
        case 18: {
          Suburb = input.ReadString();
          break;
        }
        case 26: {
          City = input.ReadString();
          break;
        }
        case 34: {
          Code = input.ReadString();
          break;
        }
      }
    }
  }
  #endif

}

public sealed partial class PersonProto_v2 : pb::IMessage<PersonProto_v2>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    , pb::IBufferMessage
#endif
{
  private static readonly pb::MessageParser<PersonProto_v2> _parser = new pb::MessageParser<PersonProto_v2>(() => new PersonProto_v2());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pb::MessageParser<PersonProto_v2> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::PersonV2Reflection.Descriptor.MessageTypes[1]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public PersonProto_v2() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public PersonProto_v2(PersonProto_v2 other) : this() {
    name_ = other.name_;
    surname_ = other.surname_;
    id_ = other.id_;
    birthdate_ = other.birthdate_;
    address_ = other.address_ != null ? other.address_.Clone() : null;
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public PersonProto_v2 Clone() {
    return new PersonProto_v2(this);
  }

  /// <summary>Field number for the "Name" field.</summary>
  public const int NameFieldNumber = 1;
  private string name_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public string Name {
    get { return name_; }
    set {
      name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "Surname" field.</summary>
  public const int SurnameFieldNumber = 2;
  private string surname_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public string Surname {
    get { return surname_; }
    set {
      surname_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "Id" field.</summary>
  public const int IdFieldNumber = 3;
  private int id_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int Id {
    get { return id_; }
    set {
      id_ = value;
    }
  }

  /// <summary>Field number for the "Birthdate" field.</summary>
  public const int BirthdateFieldNumber = 4;
  private long birthdate_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public long Birthdate {
    get { return birthdate_; }
    set {
      birthdate_ = value;
    }
  }

  /// <summary>Field number for the "Address" field.</summary>
  public const int AddressFieldNumber = 6;
  private global::AddressProto address_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public global::AddressProto Address {
    get { return address_; }
    set {
      address_ = value;
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override bool Equals(object other) {
    return Equals(other as PersonProto_v2);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public bool Equals(PersonProto_v2 other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (Name != other.Name) return false;
    if (Surname != other.Surname) return false;
    if (Id != other.Id) return false;
    if (Birthdate != other.Birthdate) return false;
    if (!object.Equals(Address, other.Address)) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override int GetHashCode() {
    int hash = 1;
    if (Name.Length != 0) hash ^= Name.GetHashCode();
    if (Surname.Length != 0) hash ^= Surname.GetHashCode();
    if (Id != 0) hash ^= Id.GetHashCode();
    if (Birthdate != 0L) hash ^= Birthdate.GetHashCode();
    if (address_ != null) hash ^= Address.GetHashCode();
    if (_unknownFields != null) {
      hash ^= _unknownFields.GetHashCode();
    }
    return hash;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void WriteTo(pb::CodedOutputStream output) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    output.WriteRawMessage(this);
  #else
    if (Name.Length != 0) {
      output.WriteRawTag(10);
      output.WriteString(Name);
    }
    if (Surname.Length != 0) {
      output.WriteRawTag(18);
      output.WriteString(Surname);
    }
    if (Id != 0) {
      output.WriteRawTag(24);
      output.WriteInt32(Id);
    }
    if (Birthdate != 0L) {
      output.WriteRawTag(32);
      output.WriteInt64(Birthdate);
    }
    if (address_ != null) {
      output.WriteRawTag(50);
      output.WriteMessage(Address);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(output);
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
    if (Name.Length != 0) {
      output.WriteRawTag(10);
      output.WriteString(Name);
    }
    if (Surname.Length != 0) {
      output.WriteRawTag(18);
      output.WriteString(Surname);
    }
    if (Id != 0) {
      output.WriteRawTag(24);
      output.WriteInt32(Id);
    }
    if (Birthdate != 0L) {
      output.WriteRawTag(32);
      output.WriteInt64(Birthdate);
    }
    if (address_ != null) {
      output.WriteRawTag(50);
      output.WriteMessage(Address);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(ref output);
    }
  }
  #endif

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int CalculateSize() {
    int size = 0;
    if (Name.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
    }
    if (Surname.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Surname);
    }
    if (Id != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(Id);
    }
    if (Birthdate != 0L) {
      size += 1 + pb::CodedOutputStream.ComputeInt64Size(Birthdate);
    }
    if (address_ != null) {
      size += 1 + pb::CodedOutputStream.ComputeMessageSize(Address);
    }
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(PersonProto_v2 other) {
    if (other == null) {
      return;
    }
    if (other.Name.Length != 0) {
      Name = other.Name;
    }
    if (other.Surname.Length != 0) {
      Surname = other.Surname;
    }
    if (other.Id != 0) {
      Id = other.Id;
    }
    if (other.Birthdate != 0L) {
      Birthdate = other.Birthdate;
    }
    if (other.address_ != null) {
      if (address_ == null) {
        Address = new global::AddressProto();
      }
      Address.MergeFrom(other.Address);
    }
    _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(pb::CodedInputStream input) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    input.ReadRawMessage(this);
  #else
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
          break;
        case 10: {
          Name = input.ReadString();
          break;
        }
        case 18: {
          Surname = input.ReadString();
          break;
        }
        case 24: {
          Id = input.ReadInt32();
          break;
        }
        case 32: {
          Birthdate = input.ReadInt64();
          break;
        }
        case 50: {
          if (address_ == null) {
            Address = new global::AddressProto();
          }
          input.ReadMessage(Address);
          break;
        }
      }
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
      switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
          break;
        case 10: {
          Name = input.ReadString();
          break;
        }
        case 18: {
          Surname = input.ReadString();
          break;
        }
        case 24: {
          Id = input.ReadInt32();
          break;
        }
        case 32: {
          Birthdate = input.ReadInt64();
          break;
        }
        case 50: {
          if (address_ == null) {
            Address = new global::AddressProto();
          }
          input.ReadMessage(Address);
          break;
        }
      }
    }
  }
  #endif

}

#endregion


#endregion Designer generated code
