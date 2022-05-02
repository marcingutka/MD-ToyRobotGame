using TRG.Models.Commands;
using TRG.Models.Model;

namespace TRG.Logic.Services.Executers
{
    internal interface ICommandExecuter
    {
        string Execute(ref Robot robot, Command command, Grid grid, List<GridPoint> gridData);
    }
}
