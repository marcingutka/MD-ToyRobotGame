using TRG.Models.Enums;
using TRG.Models.Model;

namespace TRG.Logic.Services.Executers
{
    internal class MoveExecuter
    {
        public static void Execute(ref Robot robot, List<GridPoint> gridData, Grid grid)
        {
            if (robot is null) return;

            var (x, y) = MoveForward(robot.Position, grid);

            if (!CheckIfThereIsWall(x, y, gridData))
            {
                robot.Position = new GridPosition { X = x, Y = y, Orientation = robot.Position.Orientation };
            }
        }

        private static (int X, int Y) MoveForward(GridPosition position, Grid grid)
        {
            var (x, y) = position.Orientation switch
            {
                OrientationState.North => (position.X, position.Y + 1),
                OrientationState.East => (position.X + 1, position.Y),
                OrientationState.South => (position.X, position.Y - 1),
                OrientationState.West => (position.X - 1, position.Y),
                _ => (position.X, position.Y),
            };

            if (x > grid.X) x = 1;
            if (y > grid.Y) y = 1;
            if (x < 1) x = grid.X;
            if (y < 1) y = grid.Y;

            return (x, y);
        }

        private static bool CheckIfThereIsWall(int x, int y, List<GridPoint> gridData)
        {
            if (gridData is null) return true;

            return gridData.Any(point => point.Position.X == x && point.Position.Y == y && point.IsWall == true);
        }
    }
}
