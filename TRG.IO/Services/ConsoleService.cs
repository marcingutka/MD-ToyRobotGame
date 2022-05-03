using TRG.InputHandler.Mappers;
using TRG.Logic.Manager;
using TRG.Models.Model;

namespace TRG.IO.Services
{
    internal class ConsoleService : IConsoleService
    {
        private readonly IInputMapper mapper;
        private readonly IGameManager gameManager;

        public ConsoleService(
            IInputMapper mapper,
            IGameManager gameManager
            )
        {
            this.mapper = mapper;
            this.gameManager = gameManager;
        }
        public void HandleInput(string command, Grid grid)
        {

        }
    }
}
