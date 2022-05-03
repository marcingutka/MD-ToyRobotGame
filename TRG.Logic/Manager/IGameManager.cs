using TRG.Models.Commands;
using TRG.Models.Model;

namespace TRG.Logic.Manager
{
    public interface IGameManager
    {
        void ConfigureManager(Grid grid);
        List<string> ExecuteCommands(List<Command> commends);
        string ExecuteCommand(Command command);
        void Clear();
    }
}
