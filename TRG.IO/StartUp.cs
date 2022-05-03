using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TRG.FileHandler.FileHandler;
using TRG.InputHandler.Mappers;
using TRG.Logic.Manager;
using TRG.Models.Model;

namespace TRG.IO
{
    internal static class StartUp
    {
        private const string GridSection = "Grid";
        internal static (IFileHandler FileHandler, IInputMapper InputMapper, IGameManager RobotManager) GetServices(ServiceProvider provider)
        {
            var fileHandler = provider.GetService<IFileHandler>();
            var inputMapper = provider.GetService<IInputMapper>();
            var manager = provider.GetService<IGameManager>();

            return (fileHandler, inputMapper, manager);
        }

        internal static Grid GetGrid(IConfiguration config) =>
            new Grid(int.Parse(config.GetSection(GridSection).GetSection("X").Value), int.Parse(config.GetSection(GridSection).GetSection("Y").Value));
    }
}
