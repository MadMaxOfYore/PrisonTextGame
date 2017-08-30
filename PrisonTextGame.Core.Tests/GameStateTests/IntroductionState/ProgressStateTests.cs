using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using PrisonTextGame.Core.Entities;
using PrisonTextGame.Core.GameState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PrisonTextGame.Core.Tests.GameStateTests.IntroductionState
{
    [TestFixture]
    public class ProgressStateTests
    {
        [Test]
        public void ShouldSetGameContextCurrentStateToCellInitialVisitStateOnSpaceBarClick()
        {
            //Arrange
            var gameContext = new GameContext();

            var introductionState = new IntroductionGameState();

            //Act
            introductionState.HandleDecision(gameContext, "Space");

            //Assert
            gameContext.CurrentGameState.Should().BeAssignableTo<CellInitialVisitState>();
        }
    }
}
