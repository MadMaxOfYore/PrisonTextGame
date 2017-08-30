using PrisonTextGame.Core.GameState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrisonTextGame.Core.Entities;
using UnityEngine;

namespace PrisonTextGame.Core.Tests.Fakes
{
    public class FakeGameState : IGameState
    {
        public string SceneName { get; private set; }

        public IEnumerable<string> DecisionCodes
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string MessageToPlayer { get; private set; }

        public void HandleDecision(GameContext gameContext, string decisionCode)
        {
        }
    }
}
