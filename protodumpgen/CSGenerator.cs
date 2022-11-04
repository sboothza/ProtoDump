namespace protodumpgen
{
	public static class CSGenerator
	{
		private const string MESSAGETEMPLATE = "using protodumplib;\r\nnamespace %namespace%\r\n{\r\n\tpublic partial class %message% : Dumpable\r\n\t{\r\n%fielddefinitions%\r\n\t\tpublic %message%()\r\n\t\t{\r\n\t\t\t%constructors%\r\n\t\t}\r\n\r\n\t\tpublic override void Deserialize(DumpCodec codec, DumpField field)\r\n\t\t{\r\n\t\t\tswitch (field.FieldNo)\r\n\t\t\t{\r\n%fielddeserialize%\r\n\t\t\t\tdefault:\r\n\t\t\t\t\tcodec.SkipField(field.FieldType);\r\n\t\t\t\t\tbreak;\r\n\t\t\t}\r\n\t\t}\r\n\r\n\t\tpublic override void Serialize(DumpCodec codec)\r\n\t\t{\r\n%fieldserialize%\r\n\t\t\tcodec.WriteEnd();\r\n\t\t}\r\n\t}\r\n}";
		private const string FIELDDEFINITIONTEMPLATE = "\t\tpublic %type% %name% { get; set; }\r\n";
		private const string FIELDDESERIALIZETEMPLATE = "\t\t\t\tcase %fieldno%:\r\n\t\t\t\t\t%name% = codec.%reader%();\r\n\t\t\t\t\tbreak;\r\n";
		private const string OBJECTDESERIALIZETEMPLATE = "\t\t\t\tcase %fieldno%:\r\n\t\t\t\t\tcodec.Deserialize(%name%);\r\n\t\t\t\t\tbreak;\r\n";
		private const string FIELDSERIALIZETEMPLATE = "\t\t\tcodec.%writer%(%fieldno%, %name%);\r\n";
		private const string OBJECTSERIALIZETEMPLATE = "\t\t\tcodec.WriteObject(%fieldno%, %name%);\r\n";
		private const string FIELDCONSTRUCTORTEMPLATE = "%name% = new %type%();\r\n";

		public static void Generate(string protoFilename, string outputFolder, string nameSpace)
		{
			var messages = new List<Message>();
			ParseProto(protoFilename, messages);
			foreach (var message in messages)
			{
				BuildFile(outputFolder, nameSpace, message, messages);
			}
		}

		private static void BuildFile(string outputFolder, string nameSpace, Message message, List<Message> messages)
		{
			if (!Directory.Exists(outputFolder))
				Directory.CreateDirectory(outputFolder);

			var fieldDefinitions = string.Empty;
			var fieldSerializers = string.Empty;
			var fieldDeserializers = string.Empty;
			var constructors = string.Empty;

			foreach (var field in message.Fields)
			{
				fieldDefinitions += FIELDDEFINITIONTEMPLATE
					.Replace("%type%", field.Type.GetCSType(messages))
					.Replace("%name%", field.Name);

				if (field.Type.IsCustomType(messages))
				{
					fieldSerializers += OBJECTSERIALIZETEMPLATE
						.Replace("%name%", field.Name)
						.Replace("%fieldno%", field.FieldNo.ToString());

					fieldDeserializers += OBJECTDESERIALIZETEMPLATE
						.Replace("%name%", field.Name)
						.Replace("%fieldno%", field.FieldNo.ToString());

					constructors += FIELDCONSTRUCTORTEMPLATE
						.Replace("%name%", field.Name)
						.Replace("%type%", field.Type);
				}
				else
				{
					fieldSerializers += FIELDSERIALIZETEMPLATE
						.Replace("%writer%", field.Type.GetCSWriter(messages))
						.Replace("%name%", field.Name)
						.Replace("%fieldno%", field.FieldNo.ToString());

					fieldDeserializers += FIELDDESERIALIZETEMPLATE
						.Replace("%reader%", field.Type.GetCSReader(messages))
						.Replace("%name%", field.Name)
						.Replace("%fieldno%", field.FieldNo.ToString());
				}
			}

			var msg = MESSAGETEMPLATE
				.Replace("%namespace%", nameSpace)
				.Replace("%message%", message.Name)
				.Replace("%fielddefinitions%", fieldDefinitions)
				.Replace("%constructors%", constructors)
				.Replace("%fielddeserialize%", fieldDeserializers)
				.Replace("%fieldserialize%", fieldSerializers);

			using (var writer = new StreamWriter(Path.Combine(outputFolder, message.Name + ".cs")))
			{
				writer.Write(msg);
			}
		}

		private static void ParseProto(string protoFilename, List<Message> messages)
		{
			using (var reader = new StreamReader(protoFilename))
			{
				while (true)
				{
					var line = reader.ReadLine();
					if (line is null)
						break;

					line = line.Trim();
					if (string.IsNullOrEmpty(line))
						continue;

					var words = line.Split();
					switch (words[0])
					{
						case "message":
							var msg = ParseMessage(reader, messages);
							msg.Name = words[1];
							messages.Add(msg);
							break;
					}
				}
			}
		}

		private static Message ParseMessage(StreamReader reader, List<Message> messages)
		{
			var msg = new Message();
			bool done = false;
			while (!done)
			{
				var line = reader.ReadLine();
				if (line is null)
					break;

				line = line.Trim();
				if (string.IsNullOrEmpty(line))
					continue;

				var words = line.Split(new[] { ' ', '=', ';' }, StringSplitOptions.RemoveEmptyEntries);
				string type = nameof(ProtoType.UNKNOWN);
				string name = string.Empty;
				int fieldNo = 0;
				switch (words[0])
				{
					case "optional":
						type = words[1].GetTypeFromString(messages);
						name = words[2];
						fieldNo = int.Parse(words[3]);
						break;

					case "}":
						done = true;
						break;

					default:
						type = words[0].GetTypeFromString(messages);
						name = words[1];
						fieldNo = int.Parse(words[2]);
						break;
				}
				if (type != nameof(ProtoType.UNKNOWN))
					msg.Fields.Add(new Field
					{
						Type = type,
						Name = name,
						FieldNo = fieldNo
					});
			}
			return msg;
		}
	}
}
