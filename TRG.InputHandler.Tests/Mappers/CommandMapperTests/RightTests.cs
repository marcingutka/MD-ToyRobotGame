using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using TRG.InputHandler.Mappers;
using TRG.InputHandler.Validators;
using TRG.Models.Commands;
using TRG.Models.Enums;
using TRG.Models.Model;

namespace TRG.InputHandler.Tests.Mappers.CommandMapperTests
{
    public class RightTests
    {
        private const string COMMAND_TYPE = "RIGHT";

        private IInputPositionValidator validator;
        private CommandMapper commandMapper;

        [SetUp]
        public void Setup()
        {
            validator = Substitute.For<IInputPositionValidator>();
            this.commandMapper = new CommandMapper(validator);
        }

        [Test]
        public void Map_When_Right_Command_Is_Correct_Returns_MovementObject()
        {
            //Arrange
            var commandType = COMMAND_TYPE;
            List<string> commandParameters = null;
            var grid = new Grid(5, 5);

            //Act
            var result = this.commandMapper.Map(commandType, commandParameters, grid);

            //Assert
            Assert.IsTrue(result is Movement);
        }

        [Test]
        public void Map_When_Right_Command_Is_Correct_Returns_MovementObject_With_Movement_Command_Right()
        {
            //Arrange
            var commandType = COMMAND_TYPE;
            List<string> commandParameters = null;
            var grid = new Grid(5, 5);

            //Act
            var result = this.commandMapper.Map(commandType, commandParameters, grid) as Movement;

            //Assert
            Assert.AreEqual(MovementCommand.Right, result.MovementCommand);
        }

        [Test]
        public void Map_When_Right_Command_Has_Parameters_Returns_Null()
        {
            //Arrange
            var commandType = COMMAND_TYPE;
            List<string> commandParameters = new() { "2" };
            var grid = new Grid(5, 5);

            //Act
            var result = this.commandMapper.Map(commandType, commandParameters, grid) as Movement;

            //Assert
            Assert.IsNull(result);
        }
    }
}
