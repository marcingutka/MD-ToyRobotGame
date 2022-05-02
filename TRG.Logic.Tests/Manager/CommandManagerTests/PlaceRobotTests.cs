using NUnit.Framework;
using System.Collections.Generic;
using TRG.Logic.Manager;
using TRG.Logic.Tests.Helpers;
using TRG.Models.Commands;
using TRG.Models.Enums;
using TRG.Models.Model;

namespace TRG.Logic.Tests.Manager.CommandManagerTests
{
    public class PlaceRobotTests
    {
        private CommandManager manager;

        [SetUp]
        public void Setup()
        {
            manager = new CommandManager();
        }

        [Test]
        public void Execute_WHEN_PlaceRobot_Command_AND_There_Is_No_Robot_AND_Point_Do_Not_Have_Wall_SET_Robot_Position_To_Provided_State()
        {
            //Arrange
            var grid = new Grid(5, 5);
            List<GridPoint> gridPoints = new() { CreatorHelper.CreateGridPoint(2, 2, true) };
            Robot robot = null;
            var command = new PlaceRobot(new GridPosition { X = 1, Y = 2, Orientation = OrientationState.North });

            //Act
            manager.ExecuteCommand(ref robot, ref gridPoints, command, grid);

            //Assert
            Assert.AreEqual(1, robot.Position.X);
            Assert.AreEqual(2, robot.Position.Y);
            Assert.AreEqual(OrientationState.North, robot.Position.Orientation);
        }

        [Test]
        public void Execute_WHEN_PlaceRobot_Command_AND_There_Is_Robot_AND_Point_Do_Not_Have_Wall_SET_Robot_Position_To_Provided_State()
        {
            //Arrange
            var grid = new Grid(5, 5);
            List<GridPoint> gridPoints = new() { CreatorHelper.CreateGridPoint(2, 2, true) };
            Robot robot = CreatorHelper.CreateRobot(4, 3, OrientationState.South);
            var command = new PlaceRobot(new GridPosition { X = 1, Y = 2, Orientation = OrientationState.North });

            //Act
            manager.ExecuteCommand(ref robot, ref gridPoints, command, grid);

            //Assert
            Assert.AreEqual(1, robot.Position.X);
            Assert.AreEqual(2, robot.Position.Y);
            Assert.AreEqual(OrientationState.North, robot.Position.Orientation);
        }

        //To clarify what happens when we put PLACE_ROBOT to the point, where a wall exist

        /*[Test]
        public void Execute_WHEN_PlaceRobot_Command_AND_There_Is_No_Robot_AND_Point_Has_Wall_DO_NOT_Change_Robot_Position()
        {
            //Arrange
            var grid = new Grid(5, 5);
            List<GridPoint> gridPoints = new() { CreatorHelper.CreateGridPoint(2, 2, true) };
            Robot robot = null;
            var command = new PlaceRobot(new GridPosition { X = 2, Y = 2, Orientation = OrientationState.North });

            //Act
            manager.ExecuteCommand(ref robot, ref gridPoints, command, grid);

            //Assert
            Assert.IsNull(robot);
        }

        [Test]
        public void Execute_WHEN_PlaceRobot_Command_AND_There_Is_Robot_AND_Point_Has_Wall_DO_NOT_Change_Robot_Position()
        {
            //Arrange
            var grid = new Grid(5, 5);
            List<GridPoint> gridPoints = new() { CreatorHelper.CreateGridPoint(2, 2, true) };
            Robot robot = CreatorHelper.CreateRobot(1, 2, OrientationState.North);
            var command = new PlaceRobot(new GridPosition { X = 2, Y = 2, Orientation = OrientationState.North });

            //Act
            manager.ExecuteCommand(ref robot, ref gridPoints, command, grid);

            //Assert
            Assert.AreEqual(1, robot.Position.X);
            Assert.AreEqual(2, robot.Position.Y);
            Assert.AreEqual(OrientationState.North, robot.Position.Orientation);
        }*/


        //Following 2 tests are replacing above 2 tests -> depends on requirements
        [Test]
        public void Execute_WHEN_PlaceRobot_Command_AND_There_Is_No_Robot_AND_Point_Has_Wall_SET_Robot_Position_To_Provided_State()
        {
            //Arrange
            var grid = new Grid(5, 5);
            List<GridPoint> gridPoints = new() { CreatorHelper.CreateGridPoint(2, 2, true) };
            Robot robot = null;
            var command = new PlaceRobot(new GridPosition { X = 2, Y = 2, Orientation = OrientationState.North });

            //Act
            manager.ExecuteCommand(ref robot, ref gridPoints, command, grid);

            //Assert
            Assert.AreEqual(2, robot.Position.X);
            Assert.AreEqual(2, robot.Position.Y);
            Assert.AreEqual(OrientationState.North, robot.Position.Orientation);
        }

        [Test]
        public void Execute_WHEN_PlaceRobot_Command_AND_There_Is_Robot_AND_Point_Has_Wall_SET_Robot_Position_To_Provided_State()
        {
            //Arrange
            var grid = new Grid(5, 5);
            List<GridPoint> gridPoints = new() { CreatorHelper.CreateGridPoint(2, 2, true) };
            Robot robot = CreatorHelper.CreateRobot(1, 2, OrientationState.South);
            var command = new PlaceRobot(new GridPosition { X = 2, Y = 2, Orientation = OrientationState.North });

            //Act
            manager.ExecuteCommand(ref robot, ref gridPoints, command, grid);

            //Assert
            Assert.AreEqual(2, robot.Position.X);
            Assert.AreEqual(2, robot.Position.Y);
            Assert.AreEqual(OrientationState.North, robot.Position.Orientation);
        }
    }
}
