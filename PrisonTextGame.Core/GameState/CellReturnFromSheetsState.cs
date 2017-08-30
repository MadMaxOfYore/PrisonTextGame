using System.Text;
namespace PrisonTextGame.Core.GameState
{
    internal class CellReturnFromSheetsState : GameStateBase
    {
        private static string GetMessageToPlayer()
        {
            var sb = new StringBuilder();

            sb.AppendLine("You return to deliriously gazing about the room. Nothing has changed except the faint odor of tinkle lingers in the air.");
            sb.AppendLine("Press S to view the sheets, M to view Mirror and L to view Lock");

            return sb.ToString();
        }

        public CellReturnFromSheetsState()
        {
            MessageToPlayer = GetMessageToPlayer();
            SceneName = "PrisonIntroScene";
            populateNextGameStateOptions();
        }

        private void populateNextGameStateOptions()
        {
            NextStateMapping.Add("S", typeof(DirtySheetsReturnVisitState));
            //TODO: Write the state objects for the Mirror and Cell Lock scenes and map them to the appropriate key here.
        }
    }
}
