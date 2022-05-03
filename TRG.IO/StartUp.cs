using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TRG.FileHandler.FileHandler;
using TRG.InputHandler.Mappers;
using TRG.IO.Services;
using TRG.Logic.Manager;
using TRG.Models.Model;

namespace TRG.IO
{
    internal static class StartUp
    {
        private const string GridSection = "Grid";

        internal static IFileService GetServices(ServiceProvider provider)
        {
            var fileService = provider.GetService<IFileService>();

            return fileService;
        }

        internal static Grid GetGrid(IConfiguration config) =>
            new(int.Parse(config.GetSection(GridSection).GetSection("X").Value), int.Parse(config.GetSection(GridSection).GetSection("Y").Value));
    }
}
