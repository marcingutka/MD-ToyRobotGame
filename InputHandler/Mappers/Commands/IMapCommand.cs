using TRG.Models.Commands;

namespace TRG.InputHandler.Mappers.Commands
{
    internal interface IMapCommand
    {
        Command Map(List<string> parameters);
    }
}
