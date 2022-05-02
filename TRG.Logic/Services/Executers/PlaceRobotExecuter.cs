using TRG.Models.Commands;
using TRG.Models.Model;

namespace TRG.Logic.Services.Executers
{
    internal class PlaceRobotExecuter : ICommandExecuter
    {
        public string Execute(ref Robot robot, Command command, Grid grid, List<GridPoint> gridData)
        {
            var mappedCommand = command as PlaceRobot;

            robot = new Robot { Position = mappedCommand.Position };

            return null;

        }
    }
}
