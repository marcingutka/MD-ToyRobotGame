using TRG.Models.Enums;

namespace TRG.Models.Commands
{
    public record Movement(MovementCommand MovementCommand) : Command(CommandType.Movement);
}
