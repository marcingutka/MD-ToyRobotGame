﻿using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using TRG.InputHandler.Mappers;
using TRG.InputHandler.Validators;
using TRG.Models.Commands;
using TRG.Models.Enums;
using TRG.Models.Model;

namespace TRG.InputHandler.Tests.Mappers
{
    public class InputMapperTests
    {
        private IInputValidator validator;
        private InputMapper mapper;

        [SetUp]
        public void Setup()
        {
            validator = Substitute.For<IInputValidator>();
            mapper = new InputMapper(validator);
        }

        [Test]
        public void Map_When_PlaceRobot_Command_Is_Correct_Returns_CorrectPlaceRobotCommandType()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "PLACE_ROBOT 2,3,NORTH";

            content.Add(command);

            validator.Validate(default).ReturnsForAnyArgs(true);

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

            validator.Validate(default).ReturnsForAnyArgs(true);

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

            validator.Validate(default).ReturnsForAnyArgs(true);

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

            validator.Validate(default).ReturnsForAnyArgs(true);

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

            validator.Validate(default).ReturnsForAnyArgs(true);

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

            validator.Validate(default).ReturnsForAnyArgs(true);

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

            validator.Validate(default).ReturnsForAnyArgs(true);

            //Act
            var commandList = mapper.Map(content, grid);

            var mappedCommand = commandList[0] as PlaceRobot;
            //Assert
            Assert.AreEqual(OrientationState.South, mappedCommand.Position.Orientation);
        }

        [Test]
        public void Map_When_PlaceRobot_Command_Is_Correct_And_Facing_Is_Westh_Returns_WestPlacementOrientation()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "PLACE_ROBOT 2,3,WEST";

            content.Add(command);

            validator.Validate(default).ReturnsForAnyArgs(true);

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

            validator.Validate(default).ReturnsForAnyArgs(false);

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

            validator.Validate(default).ReturnsForAnyArgs(false);

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

            validator.Validate(default).ReturnsForAnyArgs(false);

            //Act
            var commandList = mapper.Map(content, grid);

            //Assert
            Assert.IsTrue(commandList.Count == 0);
        }
    }
}
