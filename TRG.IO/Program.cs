using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TRG.IO;
using TRG.IO.DI;

var configuration = new ConfigurationBuilder()
    .AddJsonFile(Path.GetFullPath(@"..\..\..\") + @"appsettings.json")
    .Build();

var services = new ServiceCollection();
DependencyInjection.CreateDependencies(services, configuration);
var provider = services.BuildServiceProvider();

var (fileService, consoleService) = StartUp.GetServices(provider);

Console.WriteLine($"Provide full path to the txt file or type command:");
var input = Console.ReadLine();

if(TextCommands.Commands.Contains(input.Split(' ')[0]))
{
    while(input.ToUpper() != "END")
    {
        consoleService.HandleInput(input);
        Console.WriteLine("Provide next command or clear data by typing 'CLEAR' command or end run by providing 'END' command:");
        input = Console.ReadLine();
    }
}
else
{
    fileService.HandleInput(input);
}