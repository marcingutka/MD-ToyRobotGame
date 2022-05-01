using NUnit.Framework;
using System.Collections.Generic;
using TRG.InputHandler.Validators;
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
        public void Validate_When_Position_Is_Correct_And_Facing_Is_NORTH_Returns_True()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var commandParameters = new List<string> { "2", "3", "NORTH" };

            //Act
            var result = validator.Validate(grid, int.Parse(commandParameters[0]), int.Parse(commandParameters[1]));

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Validate_When_Row_Is_Greater_Than_Grid_Y_Returns_False()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var commandParameters = new List<string> { "6", "3", "NORTH" };

            //Act
            var result = validator.Validate(grid, int.Parse(commandParameters[0]), int.Parse(commandParameters[1]));

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Validate_When_Row_Is_Less_Than_1_Returns_False()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var commandParameters = new List<string> { "0", "3", "NORTH" };

            //Act
            var result = validator.Validate(grid, int.Parse(commandParameters[0]), int.Parse(commandParameters[1]));

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Validate_When_Column_Is_Greater_Than_Grid_Y_Returns_False()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var commandParameters = new List<string> { "2", "6", "NORTH" };

            //Act
            var result = validator.Validate(grid, int.Parse(commandParameters[0]), int.Parse(commandParameters[1]));

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Validate_When_Column_Is_Less_Than_1_Returns_False()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var commandParameters = new List<string> { "2", "0", "NORTH" };

            //Act
            var result = validator.Validate(grid, int.Parse(commandParameters[0]), int.Parse(commandParameters[1]));

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Validate_When_Grid_Is_Null_Returns_False()
        {
            //Arrange
            Grid grid = null;
            var commandParameters = new List<string> { "2", "0", "NORTH" };

            //Act
            var result = validator.Validate(grid, int.Parse(commandParameters[0]), int.Parse(commandParameters[1]));

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsNumber_When_Value_Is_Number_Returns_True()
        {
            //Arrange
            var value = "3";

            //Act
            var result = validator.IsNumber(value);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsNumber_When_Value_Is_Not_Number_Returns_False()
        {
            //Arrange
            var value = "TESTSTRING";

            //Act
            var result = validator.IsNumber(value);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
