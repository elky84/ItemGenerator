using CommandLine;

namespace Cli
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public partial class Options
    {
        [Option('n', "count", Required = false, HelpText = "execute count")]
        public int Count { get; set; } = 1;

        [Option('l', "level", Required = false, HelpText = "monster level")]
        public int Level { get; set; }


        public static void HandleParseError(IEnumerable<Error> errs)
        {
            foreach (var err in errs)
            {
                Console.WriteLine(err.ToString());
            }
        }
    }
}