using TRG.Models.Commands;
using TRG.Models.Model;

namespace TRG.Logic.Manager
{
    public class GameManager : IGameManager
    {
        private readonly ICommandManager commandManager;

        private Grid grid;
        private Robot robot;
        private List<GridPoint> gridPoints = new();

        public GameManager(ICommandManager commandManager)
        {
            this.commandManager = commandManager;
        }
        public void ConfigureManager(Grid grid)
        {
            throw new NotImplementedException();
        }

        public List<string> ExecuteCommends(List<Command> commends)
        {
            throw new NotImplementedException();
        }

        public string ExecuteCommand(Command command)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

    }
}
