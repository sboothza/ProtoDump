using CommandLine;

namespace protodumpgen
{
	internal class Program
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
				if (o.Language.ToLower() == "c#")
					CSGenerator.Generate(o.File, o.OutputFolder, o.Namespace);
				else
					throw new Exception("unsupported language");

			});

		}
	}
}