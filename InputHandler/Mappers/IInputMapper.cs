using TRG.Models.Commands;

namespace TRG.InputHandler.Mappers
{
    public interface IInputMapper
    {
        List<Command> Map(List<string> commands);
    }
}
