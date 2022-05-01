using TRG.Models.Enums;
using TRG.Models.Model;

namespace TRG.InputHandler.Validators
{
    public interface IInputValidator
    {
        bool Validate(Grid grid, CommandType commandType, List<string> content);
    }
}
