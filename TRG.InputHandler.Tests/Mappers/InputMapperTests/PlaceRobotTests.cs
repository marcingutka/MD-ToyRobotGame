using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using TRG.InputHandler.Mappers;
using TRG.Models.Commands;
using TRG.Models.Enums;
using TRG.Models.Model;

namespace TRG.InputHandler.Tests.Mappers.InputMapperTests
{
    public class PlaceRobotTests
    {
        private const string COMMAND_TYPE = "PLACE_ROBOT";

        private ICommandMapper commandMapper;
        private InputMapper mapper;

        [SetUp]
        public void Setup()
        {
            commandMapper = Substitute.For<ICommandMapper>();
            mapper = new InputMapper(commandMapper);
        }

        [Test]
        public void Map_When_PlaceRobot_Command_Is_Correct_Returns_CorrectPlaceRobotCommandType()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "PLACE_ROBOT 2,3,NORTH";

            content.Add(command);

            commandMapper.Map(Arg.Is<string>(x => x == COMMAND_TYPE), Arg.Is<List<string>>(x => x[0] == "2" && x[1] == "3" && x[2] == "NORTH"), Arg.Any<Grid>()).Returns(new PlaceRobot(new GridPosition { Y = 2, X = 3, Orientation = OrientationState.North }));

            //Act
            var commandList = mapper.Map(content, grid);

            var mappedCommand = commandList[0];
            //Assert
            Assert.AreEqual(CommandType.PlaceRobot, mappedCommand.CommandType);
        }

        [Test]
        public void Map_When_PlaceRobot_Command_Is_Correct_Returns_CorrectPlaceRobotObject()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "PLACE_ROBOT 2,3,NORTH";

            content.Add(command);

            commandMapper.Map(Arg.Is<string>(x => x == COMMAND_TYPE), Arg.Is<List<string>>(x => x[0] == "2" && x[1] == "3" && x[2] == "NORTH"), Arg.Any<Grid>()).Returns(new PlaceRobot(new GridPosition { Y = 2, X = 3, Orientation = OrientationState.North }));

            //Act
            var commandList = mapper.Map(content, grid);

            var mappedCommand = commandList[0];
            //Assert
            Assert.IsTrue(mappedCommand is PlaceRobot);
        }

        [Test]
        public void Map_When_PlaceRobot_Command_Is_Correct_Returns_CorrectPlacementRow()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "PLACE_ROBOT 2,3,NORTH";

            content.Add(command);

            commandMapper.Map(Arg.Is<string>(x => x == COMMAND_TYPE), Arg.Is<List<string>>(x => x[0] == "2" && x[1] == "3" && x[2] == "NORTH"), Arg.Any<Grid>()).Returns(new PlaceRobot(new GridPosition { Y = 2, X = 3, Orientation = OrientationState.North }));

            //Act
            var commandList = mapper.Map(content, grid);

            var mappedCommand = commandList[0] as PlaceRobot;
            //Assert
            Assert.AreEqual(2, mappedCommand.Position.Y);
        }

        [Test]
        public void Map_When_PlaceRobot_Command_Is_Correct_Returns_CorrectPlacementColumn()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "PLACE_ROBOT 2,3,NORTH";

            content.Add(command);

            commandMapper.Map(Arg.Is<string>(x => x == COMMAND_TYPE), Arg.Is<List<string>>(x => x[0] == "2" && x[1] == "3" && x[2] == "NORTH"), Arg.Any<Grid>()).Returns(new PlaceRobot(new GridPosition { Y = 2, X = 3, Orientation = OrientationState.North }));

            //Act
            var commandList = mapper.Map(content, grid);

            var mappedCommand = commandList[0] as PlaceRobot;
            //Assert
            Assert.AreEqual(3, mappedCommand.Position.X);
        }

        [Test]
        public void Map_When_PlaceRobot_Command_Is_Correct_And_Facing_Is_North_Returns_NorthPlacementOrientation()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "PLACE_ROBOT 2,3,NORTH";

            content.Add(command);

            commandMapper.Map(Arg.Is<string>(x => x == COMMAND_TYPE), Arg.Is<List<string>>(x => x[0] == "2" && x[1] == "3" && x[2] == "NORTH"), Arg.Any<Grid>()).Returns(new PlaceRobot(new GridPosition { Y = 2, X = 3, Orientation = OrientationState.North }));

            //Act
            var commandList = mapper.Map(content, grid);

            var mappedCommand = commandList[0] as PlaceRobot;
            //Assert
            Assert.AreEqual(OrientationState.North, mappedCommand.Position.Orientation);
        }

        [Test]
        public void Map_When_PlaceRobot_Command_Is_Correct_And_Facing_Is_East_Returns_EastPlacementOrientation()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "PLACE_ROBOT 2,3,EAST";

            content.Add(command);

            commandMapper.Map(Arg.Is<string>(x => x == COMMAND_TYPE), Arg.Is<List<string>>(x => x[0] == "2" && x[1] == "3" && x[2] == "EAST"), Arg.Any<Grid>()).Returns(new PlaceRobot(new GridPosition { Y = 2, X = 3, Orientation = OrientationState.East }));

            //Act
            var commandList = mapper.Map(content, grid);

            var mappedCommand = commandList[0] as PlaceRobot;
            //Assert
            Assert.AreEqual(OrientationState.East, mappedCommand.Position.Orientation);
        }

        [Test]
        public void Map_When_PlaceRobot_Command_Is_Correct_And_Facing_Is_South_Returns_SouthPlacementOrientation()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "PLACE_ROBOT 2,3,SOUTH";

            content.Add(command);

            commandMapper.Map(Arg.Is<string>(x => x == COMMAND_TYPE), Arg.Is<List<string>>(x => x[0] == "2" && x[1] == "3" && x[2] == "SOUTH"), Arg.Any<Grid>()).Returns(new PlaceRobot(new GridPosition { Y = 2, X = 3, Orientation = OrientationState.South }));

            //Act
            var commandList = mapper.Map(content, grid);

            var mappedCommand = commandList[0] as PlaceRobot;
            //Assert
            Assert.AreEqual(OrientationState.South, mappedCommand.Position.Orientation);
        }

        [Test]
        public void Map_When_PlaceRobot_Command_Is_Correct_And_Facing_Is_West_Returns_WestPlacementOrientation()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "PLACE_ROBOT 2,3,WEST";

            content.Add(command);

            commandMapper.Map(Arg.Is<string>(x => x == COMMAND_TYPE), Arg.Is<List<string>>(x => x[0] == "2" && x[1] == "3" && x[2] == "WEST"), Arg.Any<Grid>()).Returns(new PlaceRobot(new GridPosition { Y = 2, X = 3, Orientation = OrientationState.West }));

            //Act
            var commandList = mapper.Map(content, grid);

            var mappedCommand = commandList[0] as PlaceRobot;
            //Assert
            Assert.AreEqual(OrientationState.West, mappedCommand.Position.Orientation);
        }

        [Test]
        public void Map_When_PlaceRobot_Command_Has_Invalid_Row_Returns_NoCommand()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "PLACE_ROBOT 6,3,NORTH";

            content.Add(command);

            commandMapper.Map(Arg.Is<string>(x => x == COMMAND_TYPE), Arg.Is<List<string>>(x => x[0] == "6" && x[1] == "3" && x[2] == "NORTH"), Arg.Any<Grid>()).Returns((PlaceRobot)null);

            //Act
            var commandList = mapper.Map(content, grid);

            //Assert
            Assert.IsTrue(commandList.Count == 0);
        }

        [Test]
        public void Map_When_PlaceRobot_Command_Has_Invalid_Column_Returns_NoCommand()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "PLACE_ROBOT 2,6,NORTH";

            content.Add(command);

            commandMapper.Map(Arg.Is<string>(x => x == COMMAND_TYPE), Arg.Is<List<string>>(x => x[0] == "2" && x[1] == "6" && x[2] == "NORTH"), Arg.Any<Grid>()).Returns((PlaceRobot)null);

            //Act
            var commandList = mapper.Map(content, grid);

            //Assert
            Assert.IsTrue(commandList.Count == 0);
        }

        [Test]
        public void Map_When_PlaceRobot_Command_Has_Invalid_Facing_Returns_NoCommand()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "PLACE_ROBOT 2,3,CENTER";

            content.Add(command);

            commandMapper.Map(Arg.Is<string>(x => x == COMMAND_TYPE), Arg.Is<List<string>>(x => x[0] == "2" && x[1] == "3" && x[2] == "CENTER"), Arg.Any<Grid>()).Returns((PlaceRobot)null);

            //Act
            var commandList = mapper.Map(content, grid);

            //Assert
            Assert.IsTrue(commandList.Count == 0);
        }
    }
}
