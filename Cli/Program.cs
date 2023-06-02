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
        .WithParsed<Options>(Generator.Execute)
        .WithNotParsed<Options>(Options.HandleParseError);
}
catch (Exception exception)
{
    Log.Information("Unhandled exception. <Reason:{ExceptionMessage}> <StackTrace:{ExceptionStackTrace}>", exception.Message, exception.StackTrace);
    Log.CloseAndFlush();
}