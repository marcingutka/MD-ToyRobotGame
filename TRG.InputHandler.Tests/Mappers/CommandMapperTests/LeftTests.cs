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
    public class LeftTests
    {
        private IInputPlacingValidator validator;
        private CommandMapper commandMapper;

        [SetUp]
        public void Setup()
        {
            validator = Substitute.For<IInputPlacingValidator>();
            this.commandMapper = new CommandMapper(validator);
        }

        [Test]
        public void Map_When_Left_Command_Is_Correct_Returns_MovementObject()
        {
            //Arrange
            var commandType = "LEFT";
            List<string> commandParameters = null;
            var grid = new Grid(5, 5);

            //Act
            var result = this.commandMapper.Map(commandType, commandParameters, grid);

            //Assert
            Assert.IsTrue(result is Movement);
        }

        [Test]
        public void Map_When_Left_Command_Is_Correct_Returns_MovementObject_With_Movement_Command_Left()
        {
            //Arrange
            var commandType = "LEFT";
            List<string> commandParameters = null;
            var grid = new Grid(5, 5);

            //Act
            var result = this.commandMapper.Map(commandType, commandParameters, grid) as Movement;

            //Assert
            Assert.AreEqual(MovementCommand.Left, result.MovementCommand);
        }

        [Test]
        public void Map_When_Left_Command_Has_Parameters_Returns_Null()
        {
            //Arrange
            var commandType = "LEFT";
            List<string> commandParameters = new List<string> { "2" };
            var grid = new Grid(5, 5);

            //Act
            var result = this.commandMapper.Map(commandType, commandParameters, grid) as Movement;

            //Assert
            Assert.IsNull(result);
        }
    }
}
