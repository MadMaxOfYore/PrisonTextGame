using FluentAssertions;
using NUnit.Framework;
using PrisonTextGame.Core.Entities;
using PrisonTextGame.Core.GameState;

namespace PrisonTextGame.Core.Tests.GameStateTests.CellReturnVisitStateTests
{
    [TestFixture]
    public class ProcessStateTests
    {
        private GameContext gameContext;
        private IGameState state;

        [SetUp]
        public void Setup()
        {
            //Arrange
            gameContext = new GameContext();
            state = new CellReturnFromSheetsState();
        }

        [Test]
        public void ProceedToDirtySheetsOnSKeyDown()
        {
            //Act   
            state.HandleDecision(gameContext, "S");

            //Assert
            gameContext.CurrentGameState.Should().BeAssignableTo<DirtySheetsReturnVisitState>();
        }

        [Test]
        public void ProceedToMirrorInitialVisitOnMKeyDown()
        {
            //Act
            state.HandleDecision(gameContext, "M");

            //Assert
            //This forces the test to fail. I've done this to stub out the test for you to complete.
            //Make sure you remove Assert.Fail when you're done.
            Assert.Fail();
        }

        [Test]
        public void ProceedToLockInitialVisitOnLKeyDown()
        {
            //Act
            state.HandleDecision(gameContext, "L");

            //Assert
            Assert.Fail();
        }
    }
}
