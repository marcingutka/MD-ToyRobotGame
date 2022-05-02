using TRG.InputHandler.Validators;
using TRG.Models.Commands;
using TRG.Models.Model;

namespace TRG.InputHandler.Mappers.Commands
{
    internal class PlaceWallMapper : IMapCommand
    {
        private readonly IInputPositionValidator validator;
        private readonly Grid grid;

        public PlaceWallMapper(
            IInputPositionValidator validator,
            Grid grid
            )
        {
            this.grid = grid;
            this.validator = validator;
        }

        public Command Map(List<string> parameters)
        {
            if (parameters is null || parameters.Count != 2) return null;

            var isRowNumber = int.TryParse(parameters[0], out int row);
            var isColumnNumber = int.TryParse(parameters[1], out int column);

            if (isRowNumber && isColumnNumber && validator.Validate(grid, row, column))
            {
                return new PlaceWall(
                new Position
                {
                    Y = int.Parse(parameters[0]),
                    X = int.Parse(parameters[1])
                }
                );
            }

            return null;
        }
    }
}
