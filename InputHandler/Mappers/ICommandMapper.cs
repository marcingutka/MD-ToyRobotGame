using TRG.Models.Commands;
using TRG.Models.Model;

namespace TRG.InputHandler.Mappers
{
    public interface ICommandMapper
    {
        Command Map(string commandType, List<string> parameters, Grid grid);
    }
}
