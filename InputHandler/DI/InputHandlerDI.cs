using Microsoft.Extensions.DependencyInjection;
using TRG.InputHandler.Mappers;
using TRG.InputHandler.Validators;

namespace TRG.InputHandler.DI
{
    public class InputHandlerDI
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IInputMapper, InputMapper>();
            services.AddSingleton<IInputPlacingValidator, InputPlacingValidator>();
            services.AddSingleton<ICommandMapper, CommandMapper>();
        }
    }
}
