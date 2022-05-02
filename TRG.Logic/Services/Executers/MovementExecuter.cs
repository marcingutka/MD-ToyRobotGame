using TRG.Models.Commands;
using TRG.Models.Enums;
using TRG.Models.Model;

namespace TRG.Logic.Services.Executers
{
    internal class MovementExecuter : ICommandExecuter
    {
        public string Execute(ref Robot robot, ref List<GridPoint> gridData, Command command, Grid grid)
        {
            var mappedCommand = command as Movement;

            switch (mappedCommand.MovementCommand)
            {
                case MovementCommand.Left:
                    LeftExecuter.Execute(ref robot);
                    break;

                case MovementCommand.Right:
                    RightExecuter.Execute(ref robot);
                    break;

                case MovementCommand.Forward:
                    MovetExecuter.Execute(ref robot, gridData, grid);
                    break;

                default:
                    throw new NotSupportedException();
            }

            return string.Empty;
        }
    }
}
