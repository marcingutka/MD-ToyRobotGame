using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TRG.IO.Services;
using TRG.Models.Model;

namespace TRG.IO
{
    internal static class StartUp
    {
        private const string GridSection = "Grid";

        internal static (IFileService fileService, IConsoleService consoleService) GetServices(ServiceProvider provider)
        {
            var fileService = provider.GetService<IFileService>();
            var consoleService = provider.GetService<IConsoleService>();

            return (fileService, consoleService);
        }

        internal static Grid GetGrid(IConfiguration config) =>
            new(int.Parse(config.GetSection(GridSection).GetSection("X").Value), int.Parse(config.GetSection(GridSection).GetSection("Y").Value));
    }
}
