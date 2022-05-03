using TRG.Logic.Messages;
using TRG.Models.Commands;
using TRG.Models.Model;

namespace TRG.Logic.Services.Executers
{
    internal class PlaceRobotExecuter : ICommandExecuter
    {
        public string Execute(ref Robot robot, ref List<GridPoint> gridData, Command command, Grid grid)
        {
            var mappedCommand = command as PlaceRobot;

            var isPositionOccupiedByWall = gridData.Any(x => x.Position.X == mappedCommand.Position.X && x.Position.Y == mappedCommand.Position.Y && x.IsWall);

            if (isPositionOccupiedByWall)
            {
                return Responses.COORDINATES_ARE_OCCUPIED_BY_WALL;
            }

            robot = new Robot { Position = mappedCommand.Position };

            return string.Empty;
        }
    }
}
