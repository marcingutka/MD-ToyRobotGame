using TRG.Models.Commands;

namespace TRG.InputHandler.Mappers
{
    public interface IInputMapper
    {
        IEnumerable<Command> Map(List<string> commands);
    }
}
