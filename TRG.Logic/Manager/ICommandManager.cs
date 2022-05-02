using TRG.Models.Commands;
using TRG.Models.Model;

namespace TRG.Logic.Manager
{
    public interface ICommandManager
    {
        void ExecuteCommands(Grid grid, IEnumerable<Command> commands);
    }
}
