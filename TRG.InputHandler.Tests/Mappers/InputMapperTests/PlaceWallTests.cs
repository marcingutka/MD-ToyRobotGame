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
    public class PlaceWallTests
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
        public void Map_When_PlaceWall_Command_Is_Correct_Returns_CorrectPlaceWallCommandType()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "PLACE_WALL 2,3";

            content.Add(command);

            validator.Validate(default, default, default).ReturnsForAnyArgs(true);

            //Act
            var commandList = mapper.Map(content, grid);

            var mappedCommand = commandList[0];
            //Assert
            Assert.AreEqual(CommandType.PlaceWall, mappedCommand.CommandType);
        }

        [Test]
        public void Map_When_PlaceWall_Command_Is_Correct_Returns_CorrectPlaceWallObject()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "PLACE_WALL 2,3,NORTH";

            content.Add(command);

            validator.Validate(default, default, default).ReturnsForAnyArgs(true);

            //Act
            var commandList = mapper.Map(content, grid);

            var mappedCommand = commandList[0];
            //Assert
            Assert.IsTrue(mappedCommand is PlaceWall);
        }

        [Test]
        public void Map_When_PlaceWall_Command_Is_Correct_Returns_CorrectPlacementRow()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "PLACE_WALL 2,3";

            content.Add(command);

            validator.Validate(default, default, default).ReturnsForAnyArgs(true);

            //Act
            var commandList = mapper.Map(content, grid);

            var mappedCommand = commandList[0] as PlaceWall;
            //Assert
            Assert.AreEqual(2, mappedCommand.Position.Y);
        }

        [Test]
        public void Map_When_PlaceWall_Command_Is_Correct_Returns_CorrectPlacementColumn()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "PLACE_WALL 2,3,NORTH";

            content.Add(command);

            validator.Validate(default, default, default).ReturnsForAnyArgs(true);

            //Act
            var commandList = mapper.Map(content, grid);

            var mappedCommand = commandList[0] as PlaceWall;
            //Assert
            Assert.AreEqual(3, mappedCommand.Position.X);
        }

        [Test]
        public void Map_When_PlaceWall_Command_Has_Invalid_Row_Returns_NoCommand()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "PLACE_WALL 6,3";

            content.Add(command);

            validator.Validate(default, default, default).ReturnsForAnyArgs(false);

            //Act
            var commandList = mapper.Map(content, grid);

            //Assert
            Assert.IsTrue(commandList.Count == 0);
        }

        [Test]
        public void Map_When_PlaceWall_Command_Has_Invalid_Column_Returns_NoCommand()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "PLACE_WALL 2,6";

            content.Add(command);

            validator.Validate(default, default, default).ReturnsForAnyArgs(false);

            //Act
            var commandList = mapper.Map(content, grid);

            //Assert
            Assert.IsTrue(commandList.Count == 0);
        }

        [Test]
        public void Map_When_CommandType_Is_PlaceWall_PlacingValidator_Is_Called_Once()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "PLACE_WALL 2,3";

            content.Add(command);

            validator.Validate(default, default, default).ReturnsForAnyArgs(false);

            //Act
            mapper.Map(content, grid);

            //Assert
            Assert.DoesNotThrow(() => validator.Received(1).Validate(Arg.Any<Grid>(), Arg.Any<int>(), Arg.Any<int>()));
        }
    }
}
