using Microsoft.Extensions.Options;
using TRG.FileHandler.FileHandler;
using TRG.InputHandler.Mappers;
using TRG.Logic.Manager;
using TRG.Models.Model;

namespace TRG.IO.Services
{
    internal class FileService : IFileService
    {
        private readonly IFileHandler filehandler;
        private readonly IInputMapper mapper;
        private readonly IGameManager gameManager;
        private Grid gameGrid;

        public FileService(
            IFileHandler filehandler,
            IInputMapper mapper,
            IGameManager gameManager,
            IOptions<GridConfig> gridConfig
            )
        {
            this.filehandler = filehandler;
            this.mapper = mapper;
            this.gameManager = gameManager;

            gameGrid = new Grid(gridConfig.Value.X, gridConfig.Value.Y);
        }

        public void HandleInput(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"The file does not exist (path: {filePath})");
                Console.WriteLine($"You will be moved to home screen");
                Console.ReadLine();
                return;
            }

            var readCommands = filehandler.ReadFile(filePath);

            try
            {
                var mappedCommands = mapper.Map(readCommands, gameGrid);

                gameManager.ConfigureManager(gameGrid);
                var results = gameManager.ExecuteCommands(mappedCommands);

                foreach (var result in results)
                {
                    if (!string.IsNullOrEmpty(result))
                    {
                        Console.WriteLine(result);
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("At least one of the command has incorrect format");
            }
        }
    }
}
