using System.Text;

namespace PrisonTextGame.Core.GameState
{
    internal class DirtySheetsReturnVisitState : DirtySheetsInitialVisitState
    {
        public static new string GetMessageToPlayer()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Oh look...");
            sb.AppendLine("Nevermind... The odorous splotches of yellow look exactly like they did before.");
            sb.AppendLine("Go figure!");
            sb.AppendLine();
            sb.AppendLine("Press R to return to roaming your cell.");

            return sb.ToString();
        }

        public DirtySheetsReturnVisitState()
        {
            MessageToPlayer = GetMessageToPlayer();
        }
    }
}
