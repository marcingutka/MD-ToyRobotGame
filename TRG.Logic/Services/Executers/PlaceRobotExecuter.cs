using TRG.Models.Commands;
using TRG.Models.Model;

namespace TRG.Logic.Services.Executers
{
    internal class PlaceRobotExecuter : ICommandExecuter
    {
        public string Execute(ref Robot robot, ref List<GridPoint> gridData, Command command, Grid grid)
        {
            var mappedCommand = command as PlaceRobot;

            robot = new Robot { Position = mappedCommand.Position };

            return null;

        }
    }
}
