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
    public class PlaceRobotTests
    {
        private const string COMMAND_TYPE = "PLACE_ROBOT";

        private CommandMapper commandMapper;
        private IInputPlacingValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = Substitute.For<IInputPlacingValidator>();
            this.commandMapper = new CommandMapper(validator);
        }

        [Test]
        public void Map_When_PlaceRobot_Command_Is_Correct_Returns_CorrectPlaceRobotCommandType()
        {
            //Arrange
            var commandType = COMMAND_TYPE;
            List<string> commandParameters = new() { "2", "3", "NORTH" };
            var grid = new Grid(5, 5);

            validator.Validate(default, default, default).ReturnsForAnyArgs(true);

            //Act
            var result = commandMapper.Map(commandType, commandParameters, grid);

            //Assert
            Assert.AreEqual(CommandType.PlaceRobot, result.CommandType);
        }

        [Test]
        public void Map_When_PlaceRobot_Command_Is_Correct_Returns_CorrectPlaceRobotObject()
        {
            //Arrange
            var commandType = COMMAND_TYPE;
            List<string> commandParameters = new() { "2", "3", "NORTH" };
            var grid = new Grid(5, 5);

            validator.Validate(default, default, default).ReturnsForAnyArgs(true);

            //Act
            var result = commandMapper.Map(commandType, commandParameters, grid);

            //Assert
            Assert.IsTrue(result is PlaceRobot);
        }

        [Test]
        public void Map_When_PlaceRobot_Command_Is_Correct_Returns_CorrectPlacementRow()
        {
            //Arrange
            var commandType = COMMAND_TYPE;
            List<string> commandParameters = new() { "2", "3", "NORTH" };
            var grid = new Grid(5, 5);

            validator.Validate(default, default, default).ReturnsForAnyArgs(true);

            //Act
            var result = commandMapper.Map(commandType, commandParameters, grid) as PlaceRobot;

            //Assert
            Assert.AreEqual(2, result.Position.Y);
        }

        [Test]
        public void Map_When_PlaceRobot_Command_Is_Correct_Returns_CorrectPlacementColumn()
        {
            //Arrange
            var commandType = COMMAND_TYPE;
            List<string> commandParameters = new() { "2", "3", "NORTH" };
            var grid = new Grid(5, 5);

            validator.Validate(default, default, default).ReturnsForAnyArgs(true);

            //Act
            var result = commandMapper.Map(commandType, commandParameters, grid) as PlaceRobot;

            //Assert
            Assert.AreEqual(3, result.Position.X);
        }

        [Test]
        public void Map_When_PlaceRobot_Command_Is_Correct_And_Facing_Is_North_Returns_NorthPlacementOrientation()
        {
            //Arrange
            var commandType = COMMAND_TYPE;
            List<string> commandParameters = new() { "2", "3", "NORTH" };
            var grid = new Grid(5, 5);

            validator.Validate(default, default, default).ReturnsForAnyArgs(true);

            //Act
            var result = commandMapper.Map(commandType, commandParameters, grid) as PlaceRobot;

            //Assert
            Assert.AreEqual(OrientationState.North, result.Position.Orientation);
        }

        [Test]
        public void Map_When_PlaceRobot_Command_Is_Correct_And_Facing_Is_East_Returns_EastPlacementOrientation()
        {
            //Arrange
            var commandType = COMMAND_TYPE;
            List<string> commandParameters = new() { "2", "3", "EAST" };
            var grid = new Grid(5, 5);

            validator.Validate(default, default, default).ReturnsForAnyArgs(true);

            //Act
            var result = commandMapper.Map(commandType, commandParameters, grid) as PlaceRobot;

            //Assert
            Assert.AreEqual(OrientationState.East, result.Position.Orientation);
        }

        [Test]
        public void Map_When_PlaceRobot_Command_Is_Correct_And_Facing_Is_South_Returns_SouthPlacementOrientation()
        {
            //Arrange
            var commandType = COMMAND_TYPE;
            List<string> commandParameters = new() { "2", "3", "SOUTH" };
            var grid = new Grid(5, 5);

            validator.Validate(default, default, default).ReturnsForAnyArgs(true);

            //Act
            var result = commandMapper.Map(commandType, commandParameters, grid) as PlaceRobot;

            //Assert
            Assert.AreEqual(OrientationState.South, result.Position.Orientation);
        }

        [Test]
        public void Map_When_PlaceRobot_Command_Is_Correct_And_Facing_Is_West_Returns_WestPlacementOrientation()
        {
            //Arrange
            var commandType = COMMAND_TYPE;
            List<string> commandParameters = new() { "2", "3", "WEST" };
            var grid = new Grid(5, 5);

            validator.Validate(default, default, default).ReturnsForAnyArgs(true);

            //Act
            var result = commandMapper.Map(commandType, commandParameters, grid) as PlaceRobot;

            //Assert
            Assert.AreEqual(OrientationState.West, result.Position.Orientation); ;
        }

        [Test]
        public void Map_When_PlaceRobot_Command_Has_Invalid_Row_Returns_Null()
        {
            //Arrange
            var commandType = COMMAND_TYPE;
            List<string> commandParameters = new() { "6", "3", "NORTH" };
            var grid = new Grid(5, 5);

            validator.Validate(default, default, default).ReturnsForAnyArgs(false);

            //Act
            var result = commandMapper.Map(commandType, commandParameters, grid) as PlaceRobot;

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Map_When_PlaceRobot_Command_Has_Invalid_Column_Returns_Null()
        {
            //Arrange
            var commandType = COMMAND_TYPE;
            List<string> commandParameters = new() { "2", "6", "NORTH" };
            var grid = new Grid(5, 5);

            validator.Validate(default, default, default).ReturnsForAnyArgs(false);

            //Act
            var result = commandMapper.Map(commandType, commandParameters, grid) as PlaceRobot;

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Map_When_PlaceRobot_Command_Has_Invalid_Facing_Returns_Null()
        {
            //Arrange
            var commandType = COMMAND_TYPE;
            List<string> commandParameters = new() { "2", "6", "CENTER" };
            var grid = new Grid(5, 5);

            validator.Validate(default, default, default).ReturnsForAnyArgs(true);

            //Act
            var result = commandMapper.Map(commandType, commandParameters, grid);

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Map_When_PlaceRobot_Has_No_Command_Returns_Null()
        {
            //Arrange
            var commandType = COMMAND_TYPE;
            List<string> commandParameters = null;
            var grid = new Grid(5, 5);

            validator.Validate(default, default, default).ReturnsForAnyArgs(true);

            //Act
            var result = commandMapper.Map(commandType, commandParameters, grid);

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Map_When_PlaceRobot_Has_Less_Than_3_Commands_Returns_Null()
        {
            //Arrange
            var commandType = COMMAND_TYPE;
            List<string> commandParameters = new() { "2" }; ;
            var grid = new Grid(5, 5);

            validator.Validate(default, default, default).ReturnsForAnyArgs(true);

            //Act
            var result = commandMapper.Map(commandType, commandParameters, grid);

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Map_When_PlaceRobot_Has_More_Than_3_Commands_Returns_Null()
        {
            //Arrange
            var commandType = COMMAND_TYPE;
            List<string> commandParameters = new() { "2", "3", "NORTH", "4" }; ;
            var grid = new Grid(5, 5);

            validator.Validate(default, default, default).ReturnsForAnyArgs(true);

            //Act
            var result = commandMapper.Map(commandType, commandParameters, grid);

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Map_When_PlaceRobot_Has_Invalid_Formatted_Position_Returns_Null()
        {
            //Arrange
            var commandType = COMMAND_TYPE;
            List<string> commandParameters = new() { "TEST", "3", "NORTH" }; ;
            var grid = new Grid(5, 5);

            validator.Validate(default, default, default).ReturnsForAnyArgs(true);

            //Act
            var result = commandMapper.Map(commandType, commandParameters, grid);

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Map_When_CommandType_Is_PlaceRobot_PlacingValidator_Is_Called_Once()
        {
            //Arrange
            var commandType = COMMAND_TYPE;
            List<string> commandParameters = new() { "2", "3", "NORTH" };
            var grid = new Grid(5, 5);

            validator.Validate(default, default, default).ReturnsForAnyArgs(true);

            //Act
            commandMapper.Map(commandType, commandParameters, grid);

            //Assert
            Assert.DoesNotThrow(() => validator.Received(1).Validate(Arg.Any<Grid>(), Arg.Any<int>(), Arg.Any<int>()));
        }
    }
}
