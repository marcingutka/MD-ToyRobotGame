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
    public class PlaceWallTests
    {
        private const string COMMAND_TYPE = "PLACE_WALL";

        private CommandMapper commandMapper;
        private IInputPositionValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = Substitute.For<IInputPositionValidator>();
            this.commandMapper = new CommandMapper(validator);
        }

        [Test]
        public void Map_When_PlaceWall_Command_Is_Correct_Returns_CorrectPlaceWallCommandType()
        {
            //Arrange
            var commandType = COMMAND_TYPE;
            List<string> commandParameters = new() { "2", "3" };
            var grid = new Grid(5, 5);

            validator.Validate(default, default, default).ReturnsForAnyArgs(true);

            //Act
            var result = commandMapper.Map(commandType, commandParameters, grid);

            //Assert
            Assert.AreEqual(CommandType.PlaceWall, result.CommandType);
        }

        [Test]
        public void Map_When_PlaceWall_Command_Is_Correct_Returns_CorrectPlaceWallObject()
        {
            //Arrange
            var commandType = COMMAND_TYPE;
            List<string> commandParameters = new() { "2", "3" };
            var grid = new Grid(5, 5);

            validator.Validate(default, default, default).ReturnsForAnyArgs(true);

            //Act
            var result = commandMapper.Map(commandType, commandParameters, grid);

            //Assert
            Assert.IsTrue(result is PlaceWall);
        }

        [Test]
        public void Map_When_PlaceWall_Command_Is_Correct_Returns_CorrectPlacementRow()
        {
            //Arrange
            var commandType = COMMAND_TYPE;
            List<string> commandParameters = new() { "2", "3" };
            var grid = new Grid(5, 5);

            validator.Validate(default, default, default).ReturnsForAnyArgs(true);

            //Act
            var result = commandMapper.Map(commandType, commandParameters, grid) as PlaceWall;

            //Assert
            Assert.AreEqual(2, result.Position.Y);
        }

        [Test]
        public void Map_When_PlaceWall_Command_Is_Correct_Returns_CorrectPlacementColumn()
        {
            //Arrange
            var commandType = COMMAND_TYPE;
            List<string> commandParameters = new() { "2", "3" };
            var grid = new Grid(5, 5);

            validator.Validate(default, default, default).ReturnsForAnyArgs(true);

            //Act
            var result = commandMapper.Map(commandType, commandParameters, grid) as PlaceWall;

            //Assert
            Assert.AreEqual(3, result.Position.X);
        }

        [Test]
        public void Map_When_PlaceWall_Command_Has_Invalid_Row_Returns_Null()
        {
            //Arrange
            var commandType = COMMAND_TYPE;
            List<string> commandParameters = new() { "6", "3" };
            var grid = new Grid(5, 5);

            validator.Validate(default, default, default).ReturnsForAnyArgs(false);

            //Act
            var result = commandMapper.Map(commandType, commandParameters, grid);

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Map_When_PlaceWall_Command_Has_Invalid_Column_Returns_Null()
        {
            //Arrange
            var commandType = COMMAND_TYPE;
            List<string> commandParameters = new() { "2", "6" };
            var grid = new Grid(5, 5);

            validator.Validate(default, default, default).ReturnsForAnyArgs(false);

            //Act
            var result = commandMapper.Map(commandType, commandParameters, grid);

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Map_When_PlaceWall_Has_No_Command_Returns_Null()
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
        public void Map_When_PlaceWall_Has_One_Command_Returns_Null()
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
        public void Map_When_PlaceWall_Has_More_Than_2_Commands_Returns_Null()
        {
            //Arrange
            var commandType = COMMAND_TYPE;
            List<string> commandParameters = new() { "2", "3", "4" }; ;
            var grid = new Grid(5, 5);

            validator.Validate(default, default, default).ReturnsForAnyArgs(true);

            //Act
            var result = commandMapper.Map(commandType, commandParameters, grid);

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Map_When_PlaceWall_Has_Invalid_Formatted_Commands_Returns_Null()
        {
            //Arrange
            var commandType = COMMAND_TYPE;
            List<string> commandParameters = new() { "TEST", "3" }; ;
            var grid = new Grid(5, 5);

            validator.Validate(default, default, default).ReturnsForAnyArgs(true);

            //Act
            var result = commandMapper.Map(commandType, commandParameters, grid);

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Map_When_CommandType_Is_PlaceWall_PlacingValidator_Is_Called_Once()
        {
            //Arrange
            var commandType = COMMAND_TYPE;
            List<string> commandParameters = new() { "2", "3" };
            var grid = new Grid(5, 5);

            validator.Validate(default, default, default).ReturnsForAnyArgs(true);

            //Act
            commandMapper.Map(commandType, commandParameters, grid);

            //Assert
            Assert.DoesNotThrow(() => validator.Received(1).Validate(Arg.Any<Grid>(), Arg.Any<int>(), Arg.Any<int>()));
        }
    }
}
