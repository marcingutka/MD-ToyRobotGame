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
            if (string.IsNullOrEmpty(command))
            {
                return;
            }

            if (command == "CLEAR")
            {
                gameManager.Clear();
                return;
            }

            try
            {
                var mappedCommand = mapper.Map(command, grid);

                if (!gameManager.IsConfigured())
                {
                    gameManager.ConfigureManager(grid);
                }

                var result = gameManager.ExecuteCommand(mappedCommand);

                if (!string.IsNullOrEmpty(result))
                {
                    Console.WriteLine(result);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Provided command has incorrect format");
            }
        }
    }
}
