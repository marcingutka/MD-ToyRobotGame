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

var (fileService, consoleService) = StartUp.GetServices(provider);
var grid = StartUp.GetGrid(configuration);

Console.WriteLine($"Provide full path to the txt file or type command:");
var input = Console.ReadLine();

if(TextCommands.Commands.Contains(input.Split(' ')[0]))
{
    while(input.ToUpper() != "CLEAR" && input.ToUpper() != "END")
    {
        consoleService.HandleInput(input, grid);
        Console.WriteLine("Provide next command or clear data by typing 'CLEAR' command or end run by providing 'END' command:");
        input = Console.ReadLine();
    }
}
else
{
    fileService.HandleInput(input, grid);
}