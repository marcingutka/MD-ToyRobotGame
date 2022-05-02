using TRG.Models.Commands;
using TRG.Models.Enums;

namespace TRG.InputHandler.Mappers.Commands
{
    internal class RightMapper : IMapCommand
    {
        public Command Map(List<string> parameters) =>
            parameters == null ? new Movement(MovementCommand.Right) : null;
    }
}
