using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TRG.IO;
using TRG.IO.DI;

var configuration = new ConfigurationBuilder()
    .AddJsonFile(Path.GetFullPath(@"..\..\..\") + @"appsettings.json")
    .Build();

var services = new ServiceCollection();
DependencyInjection.CreateDependencies(services);
var provider = services.BuildServiceProvider();

var fileService = StartUp.GetServices(provider);
var grid = StartUp.GetGrid(configuration);

Console.WriteLine($"Provide full path to the txt file or type command:");
var input = Console.ReadLine();

if(TextCommands.Commands.Contains(input.Split(' ')[0]))
{
    throw new NotImplementedException();
}
else
{
    fileService.HandleInput(input, grid);
}