using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TRG.Logic.Manager;
using TRG.Logic.Tests.Helpers;
using TRG.Models.Commands;
using TRG.Models.Enums;
using TRG.Models.Model;

namespace TRG.Logic.Tests.Manager.CommandManagerTests
{
    public class PlaceWallTests
    {
        private CommandManager manager;

        [SetUp]
        public void Setup()
        {
            manager = new CommandManager();
        }

        [Test]
        public void Execute_WHEN_PlaceWall_Command_AND_There_Is_No_Robot_AND_Point_Do_Not_Have_Wall_SET_IsWall_To_True()
        {
            //Arrange
            var grid = new Grid(5, 5);
            List<GridPoint> gridPoints = new() { CreatorHelper.CreateGridPoint(2, 2, true) };
            Robot robot = null;
            var command = new PlaceWall(new Position { X = 1, Y = 2 });

            //Act
            manager.ExecuteCommand(ref robot, command, grid, gridPoints);

            //Assert
            var gridPointForNewWall = gridPoints.Single(point => point.Position.X == command.Position.X && point.Position.Y == command.Position.Y);

            Assert.IsTrue(gridPointForNewWall.IsWall);
        }

        [Test]
        public void Execute_WHEN_PlaceWall_Command_AND_There_Is_No_Robot_AND_Point_Has_Wall_CHECK_If_IsWall_Is_SET_To_True()
        {
            //Arrange
            var grid = new Grid(5, 5);
            List<GridPoint> gridPoints = new() { CreatorHelper.CreateGridPoint(2, 2, true) };
            Robot robot = null;
            var command = new PlaceWall(new Position { X = 2, Y = 2 });

            //Act
            manager.ExecuteCommand(ref robot, command, grid, gridPoints);

            //Assert
            var gridPointForNewWall = gridPoints.Single(point => point.Position.X == command.Position.X && point.Position.Y == command.Position.Y);

            Assert.IsTrue(gridPointForNewWall.IsWall);
        }

        [Test]
        public void Execute_WHEN_PlaceWall_Command_AND_There_Is_Robot_DO_NOT_SET_Wall()
        {
            //Arrange
            var grid = new Grid(5, 5);
            List<GridPoint> gridPoints = new() { CreatorHelper.CreateGridPoint(2, 2, true) };
            Robot robot = CreatorHelper.CreateRobot(4, 3, OrientationState.South);
            var command = new PlaceWall(new Position { X = 4, Y = 3 });

            //Act
            manager.ExecuteCommand(ref robot, command, grid, gridPoints);

            //Assert
            Assert.IsTrue(!gridPoints.Any(point => point.Position.X == command.Position.X && point.Position.Y == command.Position.Y));
        }
    }
}
