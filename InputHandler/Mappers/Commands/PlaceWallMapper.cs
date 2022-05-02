using TRG.Models.Commands;
using TRG.Models.Model;

namespace TRG.InputHandler.Mappers.Commands
{
    internal class PlaceWallMapper : IMapCommand
    {
        public Command Map(List<string> parameters)
        {
            return new PlaceWall(
                new Position
                {
                    Y = int.Parse(parameters[0]),
                    X = int.Parse(parameters[1])
                }
                );
        }
    }
}
