using TRG.Models.Commands;
using TRG.Models.Model;

namespace TRG.Logic.Manager
{
    public interface IGameManager
    {
        void ConfigureManager(Grid grid);
        void AssignAllCommends(List<Command> commends);
        void AddCommand(Command command);
        void Clear();
    }
}
