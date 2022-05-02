using TRG.Models.Model;

namespace TRG.InputHandler.Validators
{
    public interface IInputPlacingValidator
    {
        bool Validate(Grid grid, int row, int col);
    }
}
