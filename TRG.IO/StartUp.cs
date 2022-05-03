using Microsoft.Extensions.DependencyInjection;
using TRG.FileHandler.FileHandler;
using TRG.InputHandler.Mappers;
using TRG.Logic.Manager;

namespace TRG.IO
{
    internal static class StartUp
    {
        internal static (IFileHandler FileHandler, IInputMapper InputMapper, IGameManager RobotManager) GetServices(ServiceProvider provider)
        {
            var fileHandler = provider.GetService<IFileHandler>();
            var inputMapper = provider.GetService<IInputMapper>();
            var manager = provider.GetService<IGameManager>();

            return (fileHandler, inputMapper, manager);
        }
    }
}
