using System.Collections;

using protodump;

namespace protodumplib
{


	public class DumpObject : IEnumerable<IDumpField>
	{
		private readonly Dictionary<int, IDumpField> _fields;
		public Dictionary<int, IDumpField> Fields => _fields;
		public DumpObject()
		{
			_fields = new Dictionary<int, IDumpField>();
		}

		public void AddField(IDumpField field) => _fields[field.FieldNo] = field;

		public IEnumerator<IDumpField> GetEnumerator() => _fields.Values.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => _fields.Values.GetEnumerator();

		//public void Serialize(DumpCodec codec)
		//{
		//	foreach (var field in this)
		//		codec.WriteField(field);

		//	codec.WriteEnd();
		//}

		//public void LoadFrom(DumpObject obj)
		//{
		//	if (obj is null)
		//		return;
		//	foreach (var fieldObj in obj.Fields)
		//		_fields[fieldObj.Key] = fieldObj.Value;
		//}

		//public void LoadTo(DumpObject obj)
		//{
		//	if (obj is null)
		//		return;
		//	foreach (var fieldObj in obj.Fields)
		//		_fields[fieldObj.Key] = fieldObj.Value;
		//}
	}
}

