using NUnit.Framework;
using System.Collections.Generic;
using TRG.Logic.Manager;
using TRG.Logic.Tests.Helpers;
using TRG.Models.Commands;
using TRG.Models.Enums;
using TRG.Models.Model;

namespace TRG.Logic.Tests.Manager.CommandManagerTests
{
    public class MoveTests
    {
        private ICommandManager manager;

        [SetUp]
        public void Setup()
        {
            manager = new CommandManager();
        }

        [Test]
        public void Execute_WHEN_Move_Command_AND_There_Is_No_Robot_DO_NOT_Change_Position()
        {
            //Arrange
            var grid = new Grid(5, 5);
            List<GridPoint> gridPoints = new();
            Robot robot = null;
            var command = new Movement(MovementCommand.Forward);

            //Act
            manager.ExecuteCommand(ref robot, ref gridPoints, command, grid);

            //Assert
            Assert.IsNull(robot);
        }

        [Test]
        public void Execute_WHEN_Move_Command_AND_There_Is_Robot_With_Orientation_North_SET_Increased_Robot_Position_Y_By_1()
        {
            //Arrange
            var grid = new Grid(5, 5);
            List<GridPoint> gridPoints = new();
            Robot robot = CreatorHelper.CreateRobot(2, 2, OrientationState.North);
            var command = new Movement(MovementCommand.Forward);

            //Act
            manager.ExecuteCommand(ref robot, ref gridPoints, command, grid);

            //Assert
            Assert.AreEqual(2, robot.Position.X);
            Assert.AreEqual(3, robot.Position.Y);
            Assert.AreEqual(OrientationState.North, robot.Position.Orientation);
        }

        [Test]
        public void Execute_WHEN_Move_Command_AND_There_Is_Robot_With_Orientation_East_SET_Increased_Robot_Position_X_By_1()
        {
            //Arrange
            var grid = new Grid(5, 5);
            List<GridPoint> gridPoints = new();
            Robot robot = CreatorHelper.CreateRobot(2, 2, OrientationState.East);
            var command = new Movement(MovementCommand.Forward);

            //Act
            manager.ExecuteCommand(ref robot, ref gridPoints, command, grid);

            //Assert
            Assert.AreEqual(3, robot.Position.X);
            Assert.AreEqual(2, robot.Position.Y);
            Assert.AreEqual(OrientationState.East, robot.Position.Orientation);
        }

        [Test]
        public void Execute_WHEN_Move_Command_AND_There_Is_Robot_With_Orientation_South_SET_Decreased_Robot_Position_Y_By_1()
        {
            //Arrange
            var grid = new Grid(5, 5);
            List<GridPoint> gridPoints = new();
            Robot robot = CreatorHelper.CreateRobot(2, 2, OrientationState.South);
            var command = new Movement(MovementCommand.Forward);

            //Act
            manager.ExecuteCommand(ref robot, ref gridPoints, command, grid);

            //Assert
            Assert.AreEqual(2, robot.Position.X);
            Assert.AreEqual(1, robot.Position.Y);
            Assert.AreEqual(OrientationState.South, robot.Position.Orientation);
        }

        [Test]
        public void Execute_WHEN_Move_Command_AND_There_Is_Robot_With_Orientation_West_SET_Decreased_Robot_Position_X_By_1()
        {
            //Arrange
            var grid = new Grid(5, 5);
            List<GridPoint> gridPoints = new();
            Robot robot = CreatorHelper.CreateRobot(2, 2, OrientationState.West);
            var command = new Movement(MovementCommand.Forward);

            //Act
            manager.ExecuteCommand(ref robot, ref gridPoints, command, grid);

            //Assert
            Assert.AreEqual(1, robot.Position.X);
            Assert.AreEqual(2, robot.Position.Y);
            Assert.AreEqual(OrientationState.West, robot.Position.Orientation);
        }

        [Test]
        public void Execute_WHEN_Move_Command_AND_There_Is_Robot_With_Orientation_North_AND_Robot_Is_Located_In_The_Grid_Edge_SET_Robot_Position_Y_To_1()
        {
            //Arrange
            var grid = new Grid(5, 5);
            List<GridPoint> gridPoints = new();
            Robot robot = CreatorHelper.CreateRobot(2, 5, OrientationState.North);
            var command = new Movement(MovementCommand.Forward);

            //Act
            manager.ExecuteCommand(ref robot, ref gridPoints, command, grid);

            //Assert
            Assert.AreEqual(2, robot.Position.X);
            Assert.AreEqual(1, robot.Position.Y);
            Assert.AreEqual(OrientationState.North, robot.Position.Orientation);
        }

        [Test]
        public void Execute_WHEN_Move_Command_AND_There_Is_Robot_With_Orientation_East_AND_Robot_Is_Located_In_The_Grid_Edge_SET_Robot_Position_X_To_1()
        {
            //Arrange
            var grid = new Grid(5, 5);
            List<GridPoint> gridPoints = new();
            Robot robot = CreatorHelper.CreateRobot(5, 2, OrientationState.East);
            var command = new Movement(MovementCommand.Forward);

            //Act
            manager.ExecuteCommand(ref robot, ref gridPoints, command, grid);

            //Assert
            Assert.AreEqual(1, robot.Position.X);
            Assert.AreEqual(2, robot.Position.Y);
            Assert.AreEqual(OrientationState.East, robot.Position.Orientation);
        }

        [Test]
        public void Execute_WHEN_Move_Command_AND_There_Is_Robot_With_Orientation_South_AND_Robot_Is_Located_In_The_Grid_Edge_SET_Robot_Position_Y_To_GridSize()
        {
            //Arrange
            var grid = new Grid(5, 5);
            List<GridPoint> gridPoints = new();
            Robot robot = CreatorHelper.CreateRobot(2, 1, OrientationState.South);
            var command = new Movement(MovementCommand.Forward);

            //Act
            manager.ExecuteCommand(ref robot, ref gridPoints, command, grid);

            //Assert
            Assert.AreEqual(2, robot.Position.X);
            Assert.AreEqual(grid.Y, robot.Position.Y);
            Assert.AreEqual(OrientationState.South, robot.Position.Orientation);
        }

        [Test]
        public void Execute_WHEN_Move_Command_AND_There_Is_Robot_With_Orientation_West_AND_Robot_Is_Located_In_The_Grid_Edge_SET_Robot_Position_X_To_GridSize()
        {
            //Arrange
            var grid = new Grid(5, 5);
            List<GridPoint> gridPoints = new();
            Robot robot = CreatorHelper.CreateRobot(1, 2, OrientationState.West);
            var command = new Movement(MovementCommand.Forward);

            //Act
            manager.ExecuteCommand(ref robot, ref gridPoints, command, grid);

            //Assert
            Assert.AreEqual(grid.X, robot.Position.X);
            Assert.AreEqual(2, robot.Position.Y);
            Assert.AreEqual(OrientationState.West, robot.Position.Orientation);
        }

        [Test]
        public void Execute_WHEN_Move_Command_AND_There_Is_Robot_With_Orientation_North_AND_Wall_Is_In_Front_Of_The_Robot_DO_NOT_SET_Robot_Position()
        {
            //Arrange
            var grid = new Grid(5, 5);
            List<GridPoint> gridPoints = new() { CreatorHelper.CreateGridPoint(2, 2, true) };
            Robot robot = CreatorHelper.CreateRobot(2, 1, OrientationState.North);
            var command = new Movement(MovementCommand.Forward);

            //Act
            manager.ExecuteCommand(ref robot, ref gridPoints, command, grid);

            //Assert
            Assert.AreEqual(2, robot.Position.X);
            Assert.AreEqual(1, robot.Position.Y);
            Assert.AreEqual(OrientationState.North, robot.Position.Orientation);
        }
    }
}
