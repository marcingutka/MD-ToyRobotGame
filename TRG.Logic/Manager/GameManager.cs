using TRG.Models.Commands;

namespace TRG.Logic.Manager
{
    public class GameManager : IGameManager
    {
        private readonly ICommandManager commandManager;

        public GameManager(ICommandManager commandManager)
        {
            this.commandManager = commandManager;
        }

        public void AssignAllCommends(List<Command> commends)
        {
            throw new NotImplementedException();
        }

        public void AddCommand(Command command)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

    }
}
