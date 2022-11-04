# ProtoDump
Similar to protobuf, but much simpler and faster.

Payload is 20% bigger, but it's about 2x faster, so who cares.

# Performance Tests 
*on M1 MacBook Pro*

*Looping 1 million times*

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


## Conclusion

This thing isn't well optimized.
In fact there are some weird parts that I want to make go away.
Just a few tweaks should make this crazy fast.

Next project - wrap this in a function that I can DLLExport for use everywhere.
Maybe rewrite in C - or Rust

##### Edit:
I changed the PersonProto_v2 to contain a list, so it's not the same as for the original test.  
I did optimize 1 or 2 things - it originally used generics, but I found it was noticably quicker to do it the hard way.  
So that is an interesting observation for future use - generics have a performance penalty.  
I also added an inline directive to the low-level functions.  This gave about a 10% performance boost.