using TRG.InputHandler.Conts;
using TRG.InputHandler.Mappers.Commands;
using TRG.InputHandler.Validators;
using TRG.Models.Commands;
using TRG.Models.Model;

namespace TRG.InputHandler.Mappers
{
    public class CommandMapper : ICommandMapper
    {
        private readonly IInputPlacingValidator placingValidator;

        public CommandMapper(IInputPlacingValidator placingValidator)
        {
            this.placingValidator = placingValidator;
        }

        public Command Map(string commandType, List<string> parameters, Grid grid)
        {
            Command command = null;
            try
            {
                IMapCommand mapper = commandType switch
                {
                    AllowedCommands.PLACE_ROBOT => new PlaceRobotMapper(placingValidator, grid),
                    AllowedCommands.PLACE_WALL => new PlaceWallMapper(),
                    _ => throw new NotSupportedException()
                };

                command = mapper.Map(parameters);
            }
            catch (NotSupportedException)
            { }

            return command;
        }
    }
}
