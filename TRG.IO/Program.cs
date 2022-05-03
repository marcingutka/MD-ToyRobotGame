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

Console.WriteLine(grid.X);

Console.WriteLine("Hello, World!");
