using FluentAssertions;
using NUnit.Framework;
using PrisonTextGame.Core.Entities;
using PrisonTextGame.Core.GameState;

namespace PrisonTextGame.Core.Tests.GameStateTests.CellInitialVisitStateTests
{
    [TestFixture]
    public class ProgressStateTests
    {
        private GameContext gameContext;
        private IGameState state;

        [SetUp]
        public void Setup()
        {
            //Arrange
            gameContext = new GameContext();
            state = new CellInitialVisitState();
        }

        [Test]
        public void ProceedToDirtySheets()
        {
            //Act   
            state.HandleDecision(gameContext, "S");

            //Assert
            gameContext.CurrentGameState.Should().BeAssignableTo<DirtySheetsInitialVisitState>();
        }

        [Test]
        public void ProceedToMirrorInitialVisit()
        {
            //Act
            state.HandleDecision(gameContext, "M");

            //Assert
            Assert.Fail();
        }

        [Test]
        public void ProceedToLockInitialVisit()
        {
            //Act
            state.HandleDecision(gameContext, "L");

            //Assert
            Assert.Fail();
        }
    }
}
