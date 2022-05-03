using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TRG.FileHandler.DI;
using TRG.InputHandler.DI;
using TRG.IO.Services;
using TRG.Logic.DI;

namespace TRG.IO.DI
{
    public class DependencyInjection
    {
        private const string GridSection = "Grid";

        public static void CreateDependencies(IServiceCollection services, IConfiguration config)
        {
            services.AddOptions();

            LogicDI.ConfigureServices(services);
            FileHandlerDI.ConfigureServices(services);
            InputHandlerDI.ConfigureServices(services);

            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IConsoleService, ConsoleService>();
            services.Configure<GridConfig>(c => c.X = int.Parse(config.GetSection(GridSection).GetSection("X").Value));
            services.Configure<GridConfig>(c => c.Y = int.Parse(config.GetSection(GridSection).GetSection("Y").Value));
        }
    }
}
