using System.Text;

namespace PrisonTextGame.Core.GameState
{
    internal class DirtySheetsInitialVisitState : GameStateBase
    {
        public static string GetMessageToPlayer()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Looks like the last resident had a bit of a bladder problem. Gross...");
            sb.AppendLine("Press R to return to roaming your cell.");

            return sb.ToString();
        }

        public DirtySheetsInitialVisitState()
        {
            MessageToPlayer = GetMessageToPlayer();
            SceneName = "PrisonIntroScene";
            populateNextGameStateOptions();
        }
        
        private void populateNextGameStateOptions()
        {
            NextStateMapping.Add("R", typeof(CellReturnFromSheetsState));
        }
    }
}
