using CommandLine;

namespace protodumpgen
{
	internal static class Program
	{
		static void Main(string[] args)
		{
			var parser = new Parser(settings =>
			{
				settings.IgnoreUnknownArguments = true;
				settings.HelpWriter = Console.Out;
			});

			parser.ParseArguments<CommandLineOptions>(args)
			.WithParsed(o =>
			{
				Console.WriteLine($"Generating for {o.File} to {o.OutputFolder}");
				if (string.Equals(o.Language, "c#", StringComparison.OrdinalIgnoreCase))
					CSGenerator.Generate(o.File, o.OutputFolder, o.Namespace);
				else
					throw new Exception("unsupported language");
			});
		}
	}
}