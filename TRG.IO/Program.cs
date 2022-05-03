using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TRG.IO;
using TRG.IO.DI;

var configuration = new ConfigurationBuilder()
    .AddJsonFile(@"F:\MottMacDonald\TRG.IO\appsettings.json")
    .Build();

var services = new ServiceCollection();

DependencyInjection.CreateDependencies(services);

var provider = services.BuildServiceProvider();

var (fileHandler, inputMapper, robotManager) = StartUp.GetServices(provider);
var grid = StartUp.GetGrid(configuration);

var readCommands = fileHandler.ReadFile(@"F:\example1.txt");
var mappedCommands = inputMapper.Map(readCommands, grid);

robotManager.ConfigureManager(grid);
var results = robotManager.ExecuteCommands(mappedCommands);

foreach (var result in results)
{
    if (!string.IsNullOrEmpty(result))
    {
        Console.WriteLine(result);
    }
}