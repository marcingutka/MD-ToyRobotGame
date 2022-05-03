using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using TRG.Logic.Manager;
using TRG.Logic.Messages;
using TRG.Logic.Tests.Helpers;
using TRG.Models.Commands;
using TRG.Models.Model;

namespace TRG.Logic.Tests.Manager
{
    public class GameManagerTests
    {
        private ICommandManager commandManager;
        private IGameManager manager;

        [SetUp]
        public void Setup()
        {
            commandManager = Substitute.For<ICommandManager>();
            manager = new GameManager(commandManager);
        }

        [Test]
        public void ExecuteCommand_WHEN_Command_Is_Report_And_Robot_Exist_Returns_Robot_Position()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var placeRobotCommand = CreatorHelper.CreatePlaceRobotCommand(1, 1, Models.Enums.OrientationState.North);
            var command = new Report();

            manager.ConfigureManager(grid);

            commandManager.ExecuteCommand(ref Arg.Any<Robot>(), ref Arg.Any<List<GridPoint>>(), Arg.Is<Command>(x => x is PlaceRobot), grid)
                .Returns(x =>
                { 
                    x[0] = CreatorHelper.CreateRobot(1, 1, Models.Enums.OrientationState.North);
                    return string.Empty;
                });

            commandManager.ExecuteCommand(ref Arg.Is<Robot>(x => x.Position.X == 1 && x.Position.Y == 1 && x.Position.Orientation == Models.Enums.OrientationState.North), ref Arg.Any<List<GridPoint>>(), Arg.Is<Command>(x => x is Report), grid)
                .Returns("1,1,NORTH");

            //Act
            manager.ExecuteCommand(placeRobotCommand);
            var result = manager.ExecuteCommand(command);

            //Assert
            Assert.AreEqual("1,1,NORTH", result);
        }

        [Test]
        public void ExecuteCommand_WHEN_Command_Is_Report_And_Robot_DO_NOT_Exist_Returns_Empty_String()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var command = new Report();

            manager.ConfigureManager(grid);

            commandManager.ExecuteCommand(ref Arg.Is<Robot>(x => x == null), ref Arg.Any<List<GridPoint>>(), Arg.Is<Command>(x => x is Report), grid).Returns(string.Empty);

            //Act
            var result = manager.ExecuteCommand(command);

            //Assert
            Assert.IsTrue(string.IsNullOrEmpty(result));
        }

        [Test]
        public void ExecuteCommand_WHEN_Command_Is_Place_Robot_And_Coordindates_Are_Occupied_By_Wall_Returns_Message()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var placeWallCommand = CreatorHelper.CreatePlaceWallCommand(1, 1);
            var placeRobotCommand = CreatorHelper.CreatePlaceRobotCommand(1, 1, Models.Enums.OrientationState.North);

            manager.ConfigureManager(grid);

            commandManager.ExecuteCommand(ref Arg.Any<Robot>(), ref Arg.Any<List<GridPoint>>(), Arg.Is<Command>(x => x is PlaceRobot), grid)
                .Returns(x =>
                {
                    x[1] = new List<GridPoint> { CreatorHelper.CreateGridPoint(1, 1, true) };
                    return string.Empty;
                });

            commandManager.ExecuteCommand(ref Arg.Any<Robot>(), ref Arg.Is<List<GridPoint>>(x => x.Contains(CreatorHelper.CreateGridPoint(1, 1, true))), Arg.Is<Command>(x => x is PlaceWall), grid)
                .Returns(Responses.COORDINATES_ARE_OCCUPIED_BY_WALL);

            //Act
            manager.ExecuteCommand(placeWallCommand);
            var result = manager.ExecuteCommand(placeRobotCommand);

            //Assert
            Assert.AreEqual(Responses.COORDINATES_ARE_OCCUPIED_BY_WALL, result);
        }
    }
}
