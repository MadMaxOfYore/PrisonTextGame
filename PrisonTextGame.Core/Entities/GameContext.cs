using PrisonTextGame.Core.GameState;
using System.Collections.Generic;

namespace PrisonTextGame.Core.Entities
{
    public class GameContext
    {
        public GameContext()
        {
            CurrentGameState = new IntroductionGameState();
        }
        
        public string CurrentScene
        {
            get
            {
                return CurrentGameState.SceneName;
            }
        }

        public string MessageToPlayer
        {
            get
            {
                return CurrentGameState.MessageToPlayer;
            }
        }

        public IEnumerable<string> CurrentDecisionCodes
        {
            get
            {
                return CurrentGameState.DecisionCodes;
            }
        }

        internal void UpdateGameState(IGameState nextGameState)
        {
            CurrentGameState = nextGameState;
        }

        public void ProcessDecision(string decisionCode)
        {
            CurrentGameState.HandleDecision(this, decisionCode);
        }

        internal IGameState CurrentGameState { get; private set; }        
    }
}
