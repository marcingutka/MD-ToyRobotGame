using Microsoft.Extensions.DependencyInjection;
using TRG.IO;
using TRG.IO.DI;

var services = new ServiceCollection();

DependencyInjection.CreateDependencies(services);

var provider = services.BuildServiceProvider();

var (fileHandler, inputMapper, robotManager) = StartUp.GetServices(provider);

Console.WriteLine("Hello, World!");
