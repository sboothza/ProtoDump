// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Person.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
/// <summary>Holder for reflection information generated from Person.proto</summary>
public static partial class PersonReflection {

  #region Descriptor
  /// <summary>File descriptor for Person.proto</summary>
  public static pbr::FileDescriptor Descriptor {
    get { return descriptor; }
  }
  private static pbr::FileDescriptor descriptor;

  static PersonReflection() {
    byte[] descriptorData = global::System.Convert.FromBase64String(
        string.Concat(
          "CgxQZXJzb24ucHJvdG8iXAoLUGVyc29uUHJvdG8SDAoETmFtZRgBIAEoCRIP",
          "CgdTdXJuYW1lGAIgASgJEgoKAklkGAMgASgFEhEKCUJpcnRoZGF0ZRgEIAEo",
          "AxIPCgdBZGRyZXNzGAUgASgJYgZwcm90bzM="));
    descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
        new pbr::FileDescriptor[] { },
        new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
          new pbr::GeneratedClrTypeInfo(typeof(global::PersonProto), global::PersonProto.Parser, new[]{ "Name", "Surname", "Id", "Birthdate", "Address" }, null, null, null, null)
        }));
  }
  #endregion

}
#region Messages
public sealed partial class PersonProto : pb::IMessage<PersonProto>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    , pb::IBufferMessage
#endif
{
  private static readonly pb::MessageParser<PersonProto> _parser = new pb::MessageParser<PersonProto>(() => new PersonProto());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pb::MessageParser<PersonProto> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::PersonReflection.Descriptor.MessageTypes[0]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public PersonProto() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public PersonProto(PersonProto other) : this() {
    name_ = other.name_;
    surname_ = other.surname_;
    id_ = other.id_;
    birthdate_ = other.birthdate_;
    address_ = other.address_;
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public PersonProto Clone() {
    return new PersonProto(this);
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
  public const int AddressFieldNumber = 5;
  private string address_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public string Address {
    get { return address_; }
    set {
      address_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override bool Equals(object other) {
    return Equals(other as PersonProto);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public bool Equals(PersonProto other) {
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
    if (Address != other.Address) return false;
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
    if (Address.Length != 0) hash ^= Address.GetHashCode();
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
    if (Address.Length != 0) {
      output.WriteRawTag(42);
      output.WriteString(Address);
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
    if (Address.Length != 0) {
      output.WriteRawTag(42);
      output.WriteString(Address);
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
    if (Address.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Address);
    }
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(PersonProto other) {
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
    if (other.Address.Length != 0) {
      Address = other.Address;
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
        case 42: {
          Address = input.ReadString();
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
        case 42: {
          Address = input.ReadString();
          break;
        }
      }
    }
  }
  #endif

}

#endregion


#endregion Designer generated code