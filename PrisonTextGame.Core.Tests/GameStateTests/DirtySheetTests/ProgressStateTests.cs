using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using PrisonTextGame.Core.Entities;
using PrisonTextGame.Core.GameState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrisonTextGame.Core.Tests.GameStateTests.DirtySheetTests
{
    [TestFixture]
    public class ProgressStateTests
    {
        [Test]
        public void InitialVisitShouldProceedToCellReturnVisitState()
        {
            //Arrange
            var gameContext = new GameContext();

            var dirtySheetsState = new DirtySheetsInitialVisitState();

            //Act
            dirtySheetsState.HandleDecision(gameContext, "R");

            //Assert
            gameContext.CurrentGameState.Should().BeAssignableTo<CellReturnFromSheetsState>();
        }

        [Test]
        public void ReturnVisitShouldProceedToCellReturnVisitState()
        {
            //Arrange
            var gameContext = new GameContext();

            var dirtySheetsState = new DirtySheetsReturnVisitState();

            //Act
            dirtySheetsState.HandleDecision(gameContext, "R");

            //Assert
            gameContext.CurrentGameState.Should().BeAssignableTo<CellReturnFromSheetsState>();
        }
    }
}
