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

        public FileService(
            IFileHandler filehandler,
            IInputMapper mapper,
            IGameManager gameManager
            )
        {
            this.filehandler = filehandler;
            this.mapper = mapper;
            this.gameManager = gameManager;
        }

        public void HandleInput(string filePath, Grid grid)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"The file does not exist (path: {filePath})");
                return;
            }

            var readCommands = filehandler.ReadFile(filePath);

            try
            {
                var mappedCommands = mapper.Map(readCommands, grid);

                gameManager.ConfigureManager(grid);
                var results = gameManager.ExecuteCommands(mappedCommands);

                foreach (var result in results)
                {
                    if (!string.IsNullOrEmpty(result))
                    {
                        Console.WriteLine(result);
                    }
                }

                Console.ReadLine();
            }
            catch (FormatException)
            {
                Console.WriteLine("At least one of the command has incorrect format");
            }
        }
    }
}
