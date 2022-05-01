using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TRG.InputHandler.Mappers;
using TRG.Models.Commands;
using TRG.Models.Enums;
using TRG.Models.Model;

namespace TRG.InputHandler.Tests.Mappers
{
    public class InputMapperTests
    {
        private InputMapper mapper;

        [SetUp]
        public void Setup()
        {
            mapper = new InputMapper();
        }

        [Test]
        public void Map_When_PlaceRobot_Command_Is_Correct_Returns_CorrectPlaceRobotCommandType()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "PLACE_ROBOT 2,3,NORTH";

            content.Add(command);

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

            //Act
            var commandList = mapper.Map(content, grid);

            var mappedCommand = commandList[0] as PlaceRobot;
            //Assert
            Assert.AreEqual(3, mappedCommand.Position.X);
        }

        [Test]
        public void Map_When_PlaceRobot_Command_Is_Correct_Returns_CorrectPlacementOrientation()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "PLACE_ROBOT 2,3,NORTH";

            content.Add(command);

            //Act
            var commandList = mapper.Map(content, grid);

            var mappedCommand = commandList[0] as PlaceRobot;
            //Assert
            Assert.AreEqual(OrientationState.North, mappedCommand.Position.Orientation);
        }

        [Test]
        public void Map_When_PlaceRobot_Command_Has_Invalid_Row_Returns_NoCommand()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "PLACE_ROBOT 6,3,NORTH";

            content.Add(command);

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

            //Act
            var commandList = mapper.Map(content, grid);

            //Assert
            Assert.IsTrue(commandList.Count == 0);
        }
    }
}
