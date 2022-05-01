using TRG.InputHandler.Validators;
using TRG.Models.Commands;
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
            throw new NotImplementedException();
        }
    }
}
