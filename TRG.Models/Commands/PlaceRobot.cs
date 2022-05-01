using TRG.Models.Enums;
using TRG.Models.Model;

namespace TRG.Models.Commands
{
    public record PlaceRobot(GridPosition Position) : Command(CommandType.PlaceRobot);
}
