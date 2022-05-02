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
            }

            return string.Empty;
        }
    }
}
