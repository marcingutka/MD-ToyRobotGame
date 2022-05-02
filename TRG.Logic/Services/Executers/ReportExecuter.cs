using TRG.Models.Commands;
using TRG.Models.Enums;
using TRG.Models.Model;

namespace TRG.Logic.Services.Executers
{
    internal class ReportExecuter : ICommandExecuter
    {
        public string Execute(ref Robot robot, ref List<GridPoint> gridData, Command command, Grid grid)
        {
            if (robot is null) return string.Empty;

            return $"{robot.Position.Y},{robot.Position.X},{robot.Position.Orientation.ToLongString()}";
        }
    }
}
