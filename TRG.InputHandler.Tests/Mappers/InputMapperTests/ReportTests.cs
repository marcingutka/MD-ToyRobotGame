﻿using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using TRG.InputHandler.Mappers;
using TRG.Models.Commands;
using TRG.Models.Enums;
using TRG.Models.Model;

namespace TRG.InputHandler.Tests.Mappers.InputMapperTests
{
    public class ReportTests
    {
        private ICommandMapper commandMapper;
        private InputMapper mapper;

        [SetUp]
        public void Setup()
        {
            commandMapper = Substitute.For<ICommandMapper>();
            mapper = new InputMapper(commandMapper);
        }

        [Test]
        public void Map_When_Report_Command_Is_Correct_Returns_CorrectReportCommandType()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "REPORT";

            content.Add(command);

            commandMapper.Map(Arg.Is<string>(x => x == "REPORT"), Arg.Is<List<string>>(x => x == null), Arg.Any<Grid>()).Returns(new Report());

            //Act
            var commandList = mapper.Map(content, grid);

            var mappedCommand = commandList[0];
            //Assert
            Assert.AreEqual(CommandType.Report, mappedCommand.CommandType);
        }

        [Test]
        public void Map_When_Report_Command_Is_Correct_Returns_CorrectReportObject()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "REPORT";

            content.Add(command);

            commandMapper.Map(Arg.Is<string>(x => x == "REPORT"), Arg.Is<List<string>>(x => x == null), Arg.Any<Grid>()).Returns(new Report());

            //Act
            var commandList = mapper.Map(content, grid);

            var mappedCommand = commandList[0];
            //Assert
            Assert.IsTrue(mappedCommand is Report);
        }

        [Test]
        public void Map_When_Report_Command_Has_Parameters_Returns_Null()
        {
            //Arrange
            var grid = new Grid(5, 5);
            var content = new List<string>();

            var command = "REPORT";

            content.Add(command);

            commandMapper.Map(Arg.Is<string>(x => x == "REPORT"), Arg.Is<List<string>>(x => x.Count > 0), Arg.Any<Grid>()).Returns((Report)null);

            //Act
            var commandList = mapper.Map(content, grid);

            //Assert
            Assert.IsTrue(commandList.Count == 0);
        }
    }
}
