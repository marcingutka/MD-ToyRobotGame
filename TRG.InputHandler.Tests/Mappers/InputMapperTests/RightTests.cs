using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using TRG.InputHandler.Mappers;
using TRG.InputHandler.Validators;
using TRG.Models.Commands;
using TRG.Models.Enums;
using TRG.Models.Model;

namespace TRG.InputHandler.Tests.Mappers.InputMapperTests
{
    public class RightTests
    {
        private IInputPlacingValidator validator;
        private InputMapper mapper;

        [SetUp]
        public void Setup()
        {
            validator = Substitute.For<IInputPlacingValidator>();
            mapper = new InputMapper(validator);
        }

        [Test]
        public void Map_When_Right_Command_Is_Correct_Returns_MovementCommandType()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "RIGHT";

            content.Add(command);

            //Act
            var commandList = mapper.Map(content, grid);

            var mappedCommand = commandList[0];
            //Assert
            Assert.AreEqual(CommandType.Movement, mappedCommand.CommandType);
        }

        [Test]
        public void Map_When_Right_Command_Is_Correct_Returns_MovementObject()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "RIGHT";

            content.Add(command);

            //Act
            var commandList = mapper.Map(content, grid);

            var mappedCommand = commandList[0];
            //Assert
            Assert.IsTrue(mappedCommand is Movement);
        }

        [Test]
        public void Map_When_Right_Command_Is_Correct_Returns_MovementObject_With_MovementCommand_Equal_Right()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "RIGHT";

            content.Add(command);

            //Act
            var commandList = mapper.Map(content, grid);

            var mappedCommand = commandList[0] as Movement;
            //Assert
            Assert.AreEqual(MovementCommand.Right, mappedCommand.MovementCommand);
        }

        [Test]
        public void Map_When_Command_Is_Right_PlacingValidator_Is_Not_Called()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "RIGHT";

            content.Add(command);

            //Act
            mapper.Map(content, grid);

            //Assert
            Assert.DoesNotThrow(() => validator.DidNotReceive().Validate(Arg.Any<Grid>(), Arg.Any<int>(), Arg.Any<int>()));
        }
    }
}
