using TRG.Models.Commands;
using TRG.Models.Model;

namespace TRG.InputHandler.Mappers
{
    public interface IInputMapper
    {
        Command Map(string command, Grid grid);
        List<Command> Map(List<string> commands, Grid grid);
    }
}
