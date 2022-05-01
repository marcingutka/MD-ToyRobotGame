using TRG.Models.Enums;
using TRG.Models.Model;

namespace TRG.Models.Commands
{
    public record PlaceWall(Position Position) : Command(CommandType.PlaceWall);
}
