using TRG.Models.Enums;
using TRG.Models.Model;

namespace TRG.Logic.Services.Executers
{
    internal class RightExecuter
    {
        public static void Execute(ref Robot robot)
        {
            if (robot is null) return;

            robot.Position.Orientation = TurnRight(robot.Position.Orientation);
        }

        private static OrientationState TurnRight(OrientationState orientation)
        {
            if (orientation == OrientationState.West) return OrientationState.North;
            else
            {
                return orientation + 1;
            }
        }
    }
}
