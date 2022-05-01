using TRG.Models.Commands;
using TRG.Models.Model;

namespace TRG.InputHandler.Mappers
{
    public interface IInputMapper
    {
        List<Command> Map(List<string> commands, Grid grid);
    }
}
