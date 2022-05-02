using TRG.Models.Commands;
using TRG.Models.Model;

namespace TRG.Logic.Manager
{
    public interface ICommandManager
    {
        string ExecuteCommand(ref Robot robot, Command command, Grid grid, List<GridPoint> gridData);
    }
}
