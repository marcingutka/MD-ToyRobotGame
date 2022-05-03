using TRG.Models.Commands;
using TRG.Models.Model;

namespace TRG.Logic.Manager
{
    public interface IGameManager
    {
        void ConfigureManager(Grid grid);
        List<string> ExecuteCommends(List<Command> commends);
        string ExecuteCommand(Command command);
        void Clear();
    }
}
