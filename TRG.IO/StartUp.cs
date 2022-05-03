using Microsoft.Extensions.DependencyInjection;
using TRG.IO.Services;

namespace TRG.IO
{
    internal static class StartUp
    {
        internal static (IFileService fileService, IConsoleService consoleService) GetServices(ServiceProvider provider)
        {
            var fileService = provider.GetService<IFileService>();
            var consoleService = provider.GetService<IConsoleService>();

            return (fileService, consoleService);
        }
    }
}
