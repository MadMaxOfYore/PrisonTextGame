using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using PrisonTextGame.Core.Entities;
using PrisonTextGame.Core.GameState;
using System;
using System.Collections.Generic;

namespace PrisonTextGame.Core.Tests.GameStateTests.BaseBehaviorTests
{
    [TestFixture]
    public class HandleDecisionTests
    {
        [Test]
        public void HandleDecisionShouldDoNothingForUnmappedDecisionCode()
        {
            //Arrange
            var nextGameState = Substitute.For<IGameState>();

            var mapping = new Dictionary<string, Type>();
            var gameStateBase = Substitute.For<GameStateBase>();
            gameStateBase.NextStateMapping.Returns(mapping);

            var gameContext = new GameContext();

            //Act
            gameStateBase.HandleDecision(gameContext, "A");

            //Assert
            gameContext.CurrentGameState.Should().BeAssignableTo<IntroductionGameState>();
        }

        [Test]
        public void ProcessKeyDownShouldChangeStateForMappedKeyCode()
        {
            //Arrange
            const string DecisionCode = "A";
            
            var nextGameStateType = typeof(Fakes.FakeGameState);

            var mapping = new Dictionary<string, Type>();
            mapping.Add(DecisionCode, nextGameStateType);

            var gameStateBase = Substitute.For<GameStateBase>();
            gameStateBase.NextStateMapping.Returns(mapping);

            var gameContext = new GameContext();

            //Act
            gameStateBase.HandleDecision(gameContext, DecisionCode);

            //Assert
            gameContext.CurrentGameState.Should().BeAssignableTo(nextGameStateType);

        }

    }
}
