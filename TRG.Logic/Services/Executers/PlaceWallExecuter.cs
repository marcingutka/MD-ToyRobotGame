using TRG.Models.Commands;
using TRG.Models.Model;

namespace TRG.Logic.Services.Executers
{
    internal class PlaceWallExecuter : ICommandExecuter
    {
        public string Execute(ref Robot robot, ref List<GridPoint> gridData, Command command, Grid grid)
        {
            var mappedCommand = command as PlaceWall;

            if (gridData is null)
            {
                gridData = new List<GridPoint> { new GridPoint { Position = mappedCommand.Position, IsWall = true } };
            }
            else
            {
                var positionX = mappedCommand.Position.X;
                var positionY = mappedCommand.Position.Y;

                var isRobot = robot is not null && robot.Position.X == positionX && robot.Position.Y == positionY;
                var isWall = gridData.Any(point => point.Position.X == positionX && point.Position.Y == positionY);

                if (!(isRobot || isWall))
                {
                    gridData.Add(new GridPoint { Position = mappedCommand.Position, IsWall = true });
                }
            }

            return null;
        }
    }
}
