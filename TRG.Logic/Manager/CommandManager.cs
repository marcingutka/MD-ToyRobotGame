using TRG.Logic.Services.Executers;
using TRG.Models.Commands;
using TRG.Models.Enums;
using TRG.Models.Model;

namespace TRG.Logic.Manager
{
    public class CommandManager : ICommandManager
    {
        public string ExecuteCommand(ref Robot robot, ref List<GridPoint> gridData, Command command, Grid grid)
        {
            ICommandExecuter executer = command.CommandType switch
            {
                CommandType.PlaceRobot => new PlaceRobotExecuter(),
                CommandType.PlaceWall => new PlaceWallExecuter(),
                CommandType.Report => new ReportExecuter(),
                _ => throw new NotSupportedException(),
            };

            return executer.Execute(ref robot, ref gridData, command, grid);
        }
    }
}
