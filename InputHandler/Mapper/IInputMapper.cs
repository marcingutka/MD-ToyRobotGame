using TRG.Models.Commands;

namespace TRG.InputHandler.Mapper
{
    public interface IInputMapper
    {
        IEnumerable<Command> Map(List<string> commands);
    }
}
