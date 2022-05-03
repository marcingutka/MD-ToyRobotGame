using TRG.Models.Model;

namespace TRG.InputHandler.Validators
{
    public interface IInputPositionValidator
    {
        bool Validate(Grid grid, int row, int col);
    }
}
