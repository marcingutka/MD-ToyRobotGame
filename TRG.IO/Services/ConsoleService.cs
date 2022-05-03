﻿using Microsoft.Extensions.Options;
using TRG.InputHandler.Mappers;
using TRG.Logic.Manager;
using TRG.Models.Model;

namespace TRG.IO.Services
{
    internal class ConsoleService : IConsoleService
    {
        private readonly IInputMapper mapper;
        private readonly IGameManager gameManager;
        private Grid gameGrid;

        public ConsoleService(
            IInputMapper mapper,
            IGameManager gameManager,
            IOptions<GridConfig> gridConfig
            )
        {
            this.mapper = mapper;
            this.gameManager = gameManager;
            gameGrid = new Grid(gridConfig.Value.X, gridConfig.Value.Y);
        }

        public void HandleInput(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                return;
            }

            if (command == TextCommands.CLEAR)
            {
                gameManager.Clear();
                return;
            }

            try
            {
                var mappedCommand = mapper.Map(command, gameGrid);

                if (!gameManager.IsConfigured())
                {
                    gameManager.ConfigureManager(gameGrid);
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
