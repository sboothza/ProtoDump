# ProtoDump
Similar to protobuf, but much simpler and faster.

Payload is 20% bigger, but it's about 2x faster, so who cares.

# Performance Tests 
*on M1 MacBook Pro*

**91 byte object graph in my lib**

**79 byte identical object graph in protobuf**

This is the graph:

```
message AddressProto {
    string Street=1;
    string Suburb=2;
    string City=3;
    string Code=4;
}

message PersonProto {
    string Name = 1;
    string Surname = 2;
    int32 Id = 3;
    int64 Birthdate = 4;
    string Address = 5;
}

message PersonProto_v2 {
    string Name = 1;
    string Surname = 2;
    int32 Id = 3;
    int64 Birthdate = 4;
    AddressProto Address = 6;
}
```

I used `PersonProto_v2` for the performance testing.

### Serialize (2.5x faster)

**ProtoDump**
`232ms`

**ProtoBuf**
`512ms`

### Deserialize (1.5x faster)

**ProtoDump**
`368ms`

**ProtoBuf**
`565ms`




