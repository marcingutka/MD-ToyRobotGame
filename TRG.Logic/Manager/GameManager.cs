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

        public List<string> ExecuteCommands(List<Command> commands)
        {
            var results = new List<string>();

            foreach (var command in commands)
            {
                results.Add(ExecuteCommand(command));
            }

            return results;
        }

        public string ExecuteCommand(Command command)
        {
            if (grid is null) throw new NullReferenceException("Game Manager is not configured.");
            if (command is null) throw new NullReferenceException("No command has been provided.");

            try
            {
                return commandManager.ExecuteCommand(ref robot, ref gridPoints, command, grid);
            }
            catch (NotSupportedException)
            {
                return $"Command type: {command.CommandType} is not supported";
            }
        }

        public bool IsConfigured() =>
            grid is not null;

        public void Clear()
        {
            gridPoints.Clear();
            robot = null;
        }

    }
}
