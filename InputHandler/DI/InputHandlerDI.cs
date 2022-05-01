using Microsoft.Extensions.DependencyInjection;
using TRG.InputHandler.Mappers;

namespace TRG.InputHandler.DI
{
    public class InputHandlerDI
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IInputMapper, InputMapper>();
        }
    }
}
