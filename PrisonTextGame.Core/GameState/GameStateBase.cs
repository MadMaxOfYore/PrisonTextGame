using PrisonTextGame.Core.Entities;
using System;
using System.Collections.Generic;

namespace PrisonTextGame.Core.GameState
{
    internal abstract class GameStateBase : IGameState
    {
        public virtual string MessageToPlayer { get; protected set; }
        public virtual string SceneName { get; protected set; }
        public virtual IEnumerable<string> DecisionCodes
        {
            get
            {
                foreach(string decisionCode in NextStateMapping.Keys)
                {
                    yield return decisionCode;
                }
            }
        }

        protected internal virtual Dictionary<string, Type> NextStateMapping { get; private set; }

        public GameStateBase()
        {
            NextStateMapping = new Dictionary<string, Type>();
        }
        
        public void HandleDecision(GameContext gameContext, string decisionCode)
        {
            if (!NextStateMapping.ContainsKey(decisionCode))
            {
                return;
            }

            var nextGameStateType = NextStateMapping[decisionCode];

            var nextGameState = (IGameState) Activator.CreateInstance(nextGameStateType);
            gameContext.UpdateGameState(nextGameState);
        }
    }
}
