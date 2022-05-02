using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using TRG.InputHandler.Mappers;
using TRG.Models.Commands;
using TRG.Models.Enums;
using TRG.Models.Model;

namespace TRG.InputHandler.Tests.Mappers.InputMapperTests
{
    public class PlaceWallTests
    {
        private const string COMMAND_TYPE = "PLACE_WALL";

        private ICommandMapper commandMapper;
        private InputMapper mapper;

        [SetUp]
        public void Setup()
        {
            commandMapper = Substitute.For<ICommandMapper>();
            mapper = new InputMapper(commandMapper);
        }

        [Test]
        public void Map_When_PlaceWall_Command_Is_Correct_Returns_CorrectPlaceWallCommandType()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "PLACE_WALL 2,3";

            content.Add(command);

            commandMapper.Map(Arg.Is<string>(x => x == COMMAND_TYPE), Arg.Is<List<string>>(x => x[0] == "2" && x[1] == "3" ), Arg.Any<Grid>()).Returns(new PlaceWall(new Position { Y = 2, X = 3 }));

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

            var command = "PLACE_WALL 2,3";

            content.Add(command);

            commandMapper.Map(Arg.Is<string>(x => x == COMMAND_TYPE), Arg.Is<List<string>>(x => x[0] == "2" && x[1] == "3"), Arg.Any<Grid>()).Returns(new PlaceWall(new Position { Y = 2, X = 3 }));

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

            commandMapper.Map(Arg.Is<string>(x => x == COMMAND_TYPE), Arg.Is<List<string>>(x => x[0] == "2" && x[1] == "3"), Arg.Any<Grid>()).Returns(new PlaceWall(new Position { Y = 2, X = 3 }));

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

            var command = "PLACE_WALL 2,3";

            content.Add(command);

            commandMapper.Map(Arg.Is<string>(x => x == COMMAND_TYPE), Arg.Is<List<string>>(x => x[0] == "2" && x[1] == "3"), Arg.Any<Grid>()).Returns(new PlaceWall(new Position { Y = 2, X = 3 }));

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

            commandMapper.Map(Arg.Is<string>(x => x == COMMAND_TYPE), Arg.Is<List<string>>(x => x[0] == "6" && x[1] == "3"), Arg.Any<Grid>()).Returns((PlaceWall)null);

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

            commandMapper.Map(Arg.Is<string>(x => x == COMMAND_TYPE), Arg.Is<List<string>>(x => x[0] == "2" && x[1] == "6"), Arg.Any<Grid>()).Returns((PlaceWall)null);

            //Act
            var commandList = mapper.Map(content, grid);

            //Assert
            Assert.IsTrue(commandList.Count == 0);
        }
    }
}
