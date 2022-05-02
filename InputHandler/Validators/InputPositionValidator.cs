using TRG.Models.Enums;
using TRG.Models.Model;

namespace TRG.InputHandler.Validators
{
    public class InputPositionValidator : IInputPositionValidator
    {
        public bool Validate(Grid grid, int row, int col)
        {
            if (grid is null) return false;

            return row > 0 && col > 0 && row <= grid.Y && col <= grid.X;
        }
    }
}
