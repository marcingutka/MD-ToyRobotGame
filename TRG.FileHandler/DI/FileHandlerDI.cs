using Microsoft.Extensions.DependencyInjection;
using TRG.FileHandler.FileHandler;

namespace TRG.FileHandler.DI
{
    public class FileHandlerDI
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IFileHandler, TxtFileHandler>();
        }
    }
}
