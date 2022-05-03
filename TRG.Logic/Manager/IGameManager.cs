using TRG.Models.Commands;

namespace TRG.Logic.Manager
{
    public interface IGameManager
    {
        void AssignAllCommends(List<Command> commends);
        void AddCommand(Command command);
        void Clear();
    }
}
