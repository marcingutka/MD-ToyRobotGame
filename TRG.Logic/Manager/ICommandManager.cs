using TRG.Models.Commands;
using TRG.Models.Model;

namespace TRG.Logic.Manager
{
    public interface ICommandManager
    {
        string ExecuteCommand(Grid grid, List<GridPoint> gridData, Robot robot, Command command);
    }
}
