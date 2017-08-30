using System.Text;

namespace PrisonTextGame.Core.GameState
{
    internal class CellInitialVisitState : GameStateBase
    {
        public static string GetMessageToPlayer()
        {
            var sb = new StringBuilder();

            sb.Append("You are awoken by a loud voice in what you assume is a prison cell. ");
            sb.Append("There is no light aside from the glow coming from the small window in the door. ");
            sb.AppendLine("You notice some dirty sheets on the bed, a mirror on the wall, and the sound of the door being locked from the outside.");
            sb.AppendLine();
            sb.Append("Press S to view the sheets, M to view Mirror and L to view Lock");

            return sb.ToString();
        }

        public CellInitialVisitState()
        {
            MessageToPlayer = GetMessageToPlayer();
            SceneName = "PrisonIntroScene";
            populateNextGameStateOptions();
        }

        private void populateNextGameStateOptions()
        {
            NextStateMapping.Add("S", typeof(DirtySheetsInitialVisitState));
            //TODO: Write the state objects for the Mirror and Cell Lock scenes and map them to the appropriate key here.

        }
    }
}