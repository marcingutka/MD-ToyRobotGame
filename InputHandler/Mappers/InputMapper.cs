using TRG.InputHandler.Conts;
using TRG.InputHandler.Validators;
using TRG.Models.Commands;
using TRG.Models.Enums;
using TRG.Models.Model;

namespace TRG.InputHandler.Mappers
{
    public class InputMapper : IInputMapper
    {
        private readonly IInputPlacingValidator placingValidator;

        public InputMapper(IInputPlacingValidator placingValidator) 
        {
            this.placingValidator = placingValidator;
        }

        public List<Command> Map(List<string> commands, Grid grid)
        {
            var commandList = new List<Command>();

            foreach (var command in commands)
            {
                var splitedCommand = command.Split(" ");
                var commandName = splitedCommand[0];

                try
                {
                    var commandType = MapCommandType(commandName);

                    if (commandType == CommandType.Movement)
                    {
                        commandList.Add(MapMovementCommand(commandName));
                    }
                    else if (commandType == CommandType.PlaceRobot || commandType == CommandType.PlaceWall)
                    {
                        var commandParameters = splitedCommand[1].Split(",").ToList();

                        if (commandParameters.Count >= 2 && placingValidator.Validate(grid, int.Parse(commandParameters[0]), int.Parse(commandParameters[1])))
                        {
                            commandList.Add(MapCommand(commandType, commandParameters));
                        }
                    }
                    else
                    {
                        commandList.Add(MapCommand(commandType, null));
                    }
                }
                catch (NotSupportedException) 
                { }
            }

            return commandList;
        }

        private static CommandType MapCommandType(string commandType) => 
            commandType switch
            {
                AllowedCommands.PLACE_ROBOT => CommandType.PlaceRobot,
                AllowedCommands.PLACE_WALL => CommandType.PlaceWall,
                AllowedCommands.REPORT => CommandType.Report,
                AllowedCommands.MOVE => CommandType.Movement,
                AllowedCommands.LEFT => CommandType.Movement,
                AllowedCommands.RIGHT => CommandType.Movement,
                _ => throw new NotSupportedException()
            };

        private static Command MapMovementCommand(string moveCommand) => 
            moveCommand switch
            {
                AllowedCommands.LEFT => new Movement(MovementCommand.Left),
                AllowedCommands.RIGHT => new Movement(MovementCommand.Right),
                AllowedCommands.MOVE => new Movement(MovementCommand.Forward),
                _ => throw new NotSupportedException()
            };

        private static Command MapCommand(CommandType commandType, List<string> commandParameters) =>
            commandType switch
            {
                CommandType.PlaceRobot => new PlaceRobot(new GridPosition { Y = int.Parse(commandParameters[0]), X = int.Parse(commandParameters[1]), Orientation = MapFacing(commandParameters[2]) }),
                CommandType.PlaceWall => new PlaceWall(new Position { Y = int.Parse(commandParameters[0]), X = int.Parse(commandParameters[1]) }),
                CommandType.Report => new Report(),
                _ => throw new NotSupportedException()
            };

        private static OrientationState MapFacing(string facing) =>
            facing switch
            {
                AllowedFacings.NORTH => OrientationState.North,
                AllowedFacings.EAST => OrientationState.East,
                AllowedFacings.SOUTH => OrientationState.South,
                AllowedFacings.WEST => OrientationState.West,
                _ => throw new NotSupportedException()
            };
    }
}
