using TRG.Models.Commands;
using TRG.Models.Enums;

namespace TRG.InputHandler.Mappers.Commands
{
    internal class MoveMapper : IMapCommand
    {
        public Command Map(List<string> parameters) =>
            parameters == null ? new Movement(MovementCommand.Forward) : null;
    }
}
