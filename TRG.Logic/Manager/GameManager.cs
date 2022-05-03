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
            this.grid = grid;
        }

        public List<string> ExecuteCommands(List<Command> commends)
        {
            throw new NotImplementedException();
        }

        public string ExecuteCommand(Command command)
        {
            if (grid is null) throw new Exception("Game Manager is not configured.");

            return commandManager.ExecuteCommand(ref robot, ref gridPoints, command, grid);
        }

        public void Clear()
        {
            gridPoints.Clear();
            robot = null;
        }

    }
}
