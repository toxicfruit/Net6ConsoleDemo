using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Net6ConsoleDemo;

var host = Host
    .CreateDefaultBuilder(args)
    .ConfigureLogging((context, logging) =>
    {
        logging
            .ClearProviders()
            .AddSimpleConsole(options => options.TimestampFormat = "[HH:mm:ss.fff MM/dd/yyyy] ");
    })
    .ConfigureAppConfiguration((context, configure) =>
    {
        configure.Sources.Clear();
        configure
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
            //.AddUserSecrets<Program>()
            .AddEnvironmentVariables()
            .AddCommandLine(args);
    })
    .ConfigureServices((context, services) =>
    {
        var configuration = context.Configuration;
        services
            .AddSingleton<ConsoleApplication>();
    })
    .Build();

var application = host.Services.GetRequiredService<ConsoleApplication>();
await application.RunAsync();
await Task.Delay(10);