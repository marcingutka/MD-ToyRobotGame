using NUnit.Framework;
using System.Collections.Generic;
using TRG.InputHandler.Validators;
using TRG.Models.Enums;
using TRG.Models.Model;

namespace TRG.InputHandler.Tests.Validators
{
    public class InputPlacingValidatorTests
    {
        private InputPlacingValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new InputPlacingValidator();
        }

        [Test]
        public void Validate_When_PlaceRobot_Position_Is_Correct_And_Facing_Is_NORTH_Returns_True()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var commandType = CommandType.PlaceRobot;
            var commandParameters = new List<string> { "2", "3", "NORTH" };

            //Act
            var result = validator.Validate(grid, commandType, commandParameters);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Validate_When_PlaceRobot_Position_Is_Correct_And_Facing_Is_EAST_Returns_True()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var commandType = CommandType.PlaceRobot;
            var commandParameters = new List<string> { "2", "3", "EAST" };

            //Act
            var result = validator.Validate(grid, commandType, commandParameters);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Validate_When_PlaceRobot_Position_Is_Correct_And_Facing_Is_SOUTH_Returns_True()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var commandType = CommandType.PlaceRobot;
            var commandParameters = new List<string> { "2", "3", "SOUTH" };

            //Act
            var result = validator.Validate(grid, commandType, commandParameters);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Validate_When_PlaceRobot_Position_Is_Correct_And_Facing_Is_WEST_Returns_True()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var commandType = CommandType.PlaceRobot;
            var commandParameters = new List<string> { "2", "3", "WEST" };

            //Act
            var result = validator.Validate(grid, commandType, commandParameters);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Validate_When_PlaceRobot_Row_Is_Greater_Than_Grid_Y_Returns_False()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var commandType = CommandType.PlaceRobot;
            var commandParameters = new List<string> { "6", "3", "NORTH" };

            //Act
            var result = validator.Validate(grid, commandType, commandParameters);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Validate_When_PlaceRobot_Row_Is_Less_Than_1_Returns_False()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var commandType = CommandType.PlaceRobot;
            var commandParameters = new List<string> { "0", "3", "NORTH" };

            //Act
            var result = validator.Validate(grid, commandType, commandParameters);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Validate_When_PlaceRobot_Column_Is_Greater_Than_Grid_Y_Returns_False()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var commandType = CommandType.PlaceRobot;
            var commandParameters = new List<string> { "2", "6", "NORTH" };

            //Act
            var result = validator.Validate(grid, commandType, commandParameters);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Validate_When_PlaceRobot_Column_Is_Less_Than_1_Returns_False()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var commandType = CommandType.PlaceRobot;
            var commandParameters = new List<string> { "2", "0", "NORTH" };

            //Act
            var result = validator.Validate(grid, commandType, commandParameters);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Validate_When_PlaceRobot_Facing_Is_Not_Supported_Returns_False()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var commandType = CommandType.PlaceRobot;
            var commandParameters = new List<string> { "2", "3", "CENTER" };

            //Act
            var result = validator.Validate(grid, commandType, commandParameters);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
