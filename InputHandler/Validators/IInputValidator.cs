using TRG.Models.Enums;

namespace TRG.InputHandler.Validators
{
    public interface IInputValidator
    {
        bool Validate(CommandType commandType, List<string> content);
    }
}
