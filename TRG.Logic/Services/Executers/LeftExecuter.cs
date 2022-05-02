using TRG.Models.Enums;
using TRG.Models.Model;

namespace TRG.Logic.Services.Executers
{
    internal class LeftExecuter
    {
        public static void Execute(ref Robot robot)
        {
            if (robot is null) return;

            robot.Position.Orientation = TurnLeft(robot.Position.Orientation);
        }

        private static OrientationState TurnLeft(OrientationState orientation)
        {
            if (orientation == OrientationState.North) return OrientationState.West;
            else
            {
                return orientation - 1;
            }
        }
    }
}
