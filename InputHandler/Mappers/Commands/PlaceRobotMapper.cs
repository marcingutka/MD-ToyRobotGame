using TRG.InputHandler.Conts;
using TRG.InputHandler.Validators;
using TRG.Models.Commands;
using TRG.Models.Enums;
using TRG.Models.Model;

namespace TRG.InputHandler.Mappers.Commands
{
    internal class PlaceRobotMapper : IMapCommand
    {
        private readonly IInputPlacingValidator validator;
        private readonly Grid grid;

        public PlaceRobotMapper(
            IInputPlacingValidator validator,
            Grid grid
            )
        {
            this.grid = grid;
            this.validator = validator;
        }
        public Command Map(List<string> parameters)
        {
            if (parameters is null || parameters.Count != 3) return null;

            var isRowNumber = int.TryParse(parameters[0], out int row);
            var isColumnNumber = int.TryParse(parameters[1], out int column);

            if (isRowNumber && isColumnNumber && validator.Validate(grid, row, column))
            {
                return new PlaceRobot(
                    new GridPosition
                    {
                        Y = int.Parse(parameters[0]),
                        X = int.Parse(parameters[1]),
                        Orientation = MapFacing(parameters[2])
                    }
                    );
            }

            return null;
        }

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
