using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using PrisonTextGame.Core.Entities;
using PrisonTextGame.Core.GameState;

namespace PrisonTextGame.Core.Tests.GameContextTests
{
    [TestFixture]
    public class ApplyStateTests
    {
        [Test]
        public void CtorShouldInitializeToIntroductionState()
        {
            //Act
            var gameContext = new GameContext();

            //Assert
            gameContext.CurrentGameState.Should().BeAssignableTo<IntroductionGameState>();
            gameContext.MessageToPlayer.Should().Be(IntroductionGameState.GetMessageToPlayer());
            gameContext.CurrentScene.Should().Be("PrisonIntroScene");
        }

        [Test]
        public void UpdateShouldSetState()
        {
            //Arrange
            var changedState = Substitute.For<IGameState>();
            var gameContext = new GameContext();

            //Act
            gameContext.UpdateGameState(changedState);

            //Assert
            gameContext.CurrentGameState.Should().Be(changedState);
        }
    }
}
