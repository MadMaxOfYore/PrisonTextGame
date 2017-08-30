using PrisonTextGame.Core.Entities;
using System.Collections.Generic;

namespace PrisonTextGame.Core.GameState
{
    public interface IGameState
    {
        string MessageToPlayer { get; }
        string SceneName { get; }
        IEnumerable<string> DecisionCodes { get; }

        void HandleDecision(GameContext gameContext, string decisionCode);
    }
}
