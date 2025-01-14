﻿using TRG.Models.Commands;
using TRG.Models.Model;

namespace TRG.InputHandler.Mappers
{
    public class InputMapper : IInputMapper
    {
        private readonly ICommandMapper commandMapper;

        private const string COMMAND_SEPARATOR = " ";
        private const string COMMAND_PARAMETERS_SEPARATOR = ",";

        public InputMapper(ICommandMapper commandMapper) 
        {
            this.commandMapper = commandMapper;
        }

        public List<Command> Map(List<string> commands, Grid grid)
        {
            var commandList = new List<Command>();

            foreach (var command in commands)
            {
                var mappedCommand = Map(command, grid);

                if (mappedCommand != null)
                {
                    commandList.Add(mappedCommand);
                }
            }

            return commandList;
        }

        public Command Map(string command, Grid grid)
        {
            if (string.IsNullOrEmpty(command)) return null;

            var splitedCommand = command.Trim().Split(COMMAND_SEPARATOR);
            var commandName = splitedCommand[0];
            var commandParameters = splitedCommand.Length > 1 ? splitedCommand[1].Split(COMMAND_PARAMETERS_SEPARATOR).ToList() : null;

            var mappedCommand = commandMapper.Map(commandName, commandParameters, grid);

            if (mappedCommand is not null)
            {
                return mappedCommand;
            }

            return null;
        }
    }
}
