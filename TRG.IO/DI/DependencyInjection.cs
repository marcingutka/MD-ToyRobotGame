using Microsoft.Extensions.DependencyInjection;
using TRG.FileHandler.DI;
using TRG.InputHandler.DI;
using TRG.IO.Services;
using TRG.Logic.DI;

namespace TRG.IO.DI
{
    public class DependencyInjection
    {
        public static void CreateDependencies(IServiceCollection services)
        {
            LogicDI.ConfigureServices(services);
            FileHandlerDI.ConfigureServices(services);
            InputHandlerDI.ConfigureServices(services);

            services.AddScoped<IFileService, FileService>();
        }
    }
}
