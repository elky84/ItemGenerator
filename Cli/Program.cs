// See https://aka.ms/new-console-template for more information

using Cli;
using CommandLine;
using Serilog;

try
{
    Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Information()
        .WriteTo.Console()
        .CreateLogger();

    Parser.Default.ParseArguments<Options>(args)
        .WithParsed<Options>(opts => Generator.Execute(opts))
        .WithNotParsed<Options>((errs) => Options.HandleParseError(errs));
}
catch (Exception exception)
{
    Log.Information($"Unhandled exception. <Reason:{exception.Message}> <StackTrace:{exception.StackTrace}>");
    Log.CloseAndFlush();
}