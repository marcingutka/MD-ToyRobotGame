using Microsoft.Extensions.DependencyInjection;
using TRG.Logic.Manager;

namespace TRG.Logic.DI
{
    public class LogicDI
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IGameManager, GameManager>();
            services.AddScoped<ICommandManager, CommandManager>();
        }
    }
}
