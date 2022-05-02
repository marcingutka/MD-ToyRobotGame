using TRG.Logic.Services.Executers;
using TRG.Models.Commands;
using TRG.Models.Enums;
using TRG.Models.Model;

namespace TRG.Logic.Manager
{
    public class CommandManager : ICommandManager
    {
        public string ExecuteCommand(ref Robot robot, Command command, Grid grid, List<GridPoint> gridData)
        {
            ICommandExecuter executer = command.CommandType switch
            {
                CommandType.PlaceRobot => new PlaceRobotExecuter(),
                _ => throw new NotSupportedException(),
            };

            return executer.Execute(ref robot, command, grid, gridData);
        }
    }
}
