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

var input = string.Empty;

while (input.ToUpper() != TextCommands.END)
{
    Console.WriteLine("1. Upload file");
    Console.WriteLine("2. Type commands manually");
    Console.WriteLine("0. Stop application");
    Console.WriteLine();

    Console.WriteLine("Choose the action (type number): ");
    input = Console.ReadLine();

    Console.Clear();

    if (input == TextCommands.UPLOAD_FILE)
    {
        Console.WriteLine("Provide full file path: ");
        input = Console.ReadLine();
        input = input.Replace(".txt", string.Empty) + ".txt";

        fileService.HandleInput(input);

        input = Console.ReadLine();
        fileService.ClearData();
    }
    else if (input == TextCommands.TYPE_MANUALLY)
    {
        Console.WriteLine("Type command or type 'BACK' to come back to home screen");
        input = Console.ReadLine();
        while (input.ToUpper() != TextCommands.BACK)
        {
            consoleService.HandleInput(input.ToUpper());

            input = Console.ReadLine();
        }
        consoleService.ClearData();
    }
    Console.Clear();
}