using TRG.Models.Commands;
using TRG.Models.Model;

namespace TRG.Logic.Services.Executers
{
    internal interface ICommandExecuter
    {
        string Execute(ref Robot robot, ref List<GridPoint> gridData, Command command, Grid grid);
    }
}
