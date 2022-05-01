using TRG.InputHandler.Conts;
using TRG.InputHandler.Validators;
using TRG.Models.Commands;
using TRG.Models.Enums;
using TRG.Models.Model;

namespace TRG.InputHandler.Mappers
{
    public class InputMapper : IInputMapper
    {
        private IInputValidator validator;

        public InputMapper(IInputValidator validator) 
        {
            this.validator = validator;
        }

        public List<Command> Map(List<string> commands, Grid grid)
        {
            var commandList = new List<Command>();

            foreach (var command in commands)
            {
                var splitedCommand = command.Split(" ");

                var commandType = MapCommandType(splitedCommand[0]);

                if (commandType != CommandType.Movement || commandType != CommandType.Report)
                {
                    var commandParameters = splitedCommand[1].Split(",").ToList();

                    if (validator.Validate(commandType, commandParameters))
                    {
                        commandList.Add(MapCommand(commandType, commandParameters));
                    }
                }
                else
                {
                    commandList.Add(MapCommand(commandType, null));
                }
            }

            return commandList;
        }

        private static CommandType MapCommandType(string commandType)
        {
            return commandType switch
            {
                AllowedCommands.PLACE_ROBOT => CommandType.PlaceRobot,
                _ => throw new NotImplementedException()
            };
        }

        private static Command MapCommand(CommandType commandType, List<string> commandParameters)
        {
            return commandType switch
            {
                CommandType.PlaceRobot => new PlaceRobot(new GridPosition { Y = int.Parse(commandParameters[0]), X = int.Parse(commandParameters[1]), Orientation = MapFacing(commandParameters[2]) }),
                _ => throw new NotImplementedException()
            };
        }

        private static OrientationState MapFacing(string facing)
        {
            return facing switch
            {
                "NORTH" => OrientationState.North,
                "EAST" => OrientationState.East,
                "SOUTH" => OrientationState.South,
                "WEST" => OrientationState.West,
                _ => throw new NotImplementedException()
            };
        }
    }
}
