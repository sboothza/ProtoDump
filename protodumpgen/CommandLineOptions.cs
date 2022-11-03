using CommandLine;

namespace protodumpgen
{
	[Verb("ProtoDumpGen", HelpText = "Generates stub code for ProtoDump.  Uses .proto files.")]
	public class CommandLineOptions
	{
		[Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
		public bool Verbose { get; set; }
		[Option('?', "help", Required = false, HelpText = "Display help.")]
		public bool Help { get; set; }
		[Option('f', "file", Required = true, HelpText = "Input .proto file.")]
		public string File { get; set; }
		[Option('o', "output-folder", Required = true, HelpText = "Output generation folder.")]
		public string OutputFolder { get; set; }
		[Option('n', "namespace", Required = true, HelpText = "Namespace.")]
		public string Namespace { get; set; }
		[Option('l', "language", Required = true, HelpText = "Output language (currently only C#).")]
		public string Language { get; set; }
	}
}
