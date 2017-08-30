using System.Text;

namespace PrisonTextGame.Core.GameState
{
    internal class IntroductionGameState : GameStateBase
    {
        //This method is a static member of the IntroductionGameState class because we want access to it in our testing framework.
        //Ideally, static text like this would be stored in a resources file and accessed via a provider so that it can be swapped 
        //out based on localization requirements.
        //Ex: Display this chunck of text for English speaking players vs this chunk for Spanish speaking players. 
        //
        //This is just a cheap way of demonstrating a more important point I wanted to make - design code to be testable from the ground up.
        //In the future, we can kill this static member and replace it by injecting a resources provider into this state object. The state
        //object could then reach into the provider to retrieve the appropriage verbiage. Our external testing framework would also be able to use
        //the same provider to assert that the state is displaying the expected message for the given locale.
        public static string GetMessageToPlayer()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Wake up worm!");
            sb.AppendLine();

            //TODO: The text with instructions to the user should be generated within the presentation layer.
            //      This should not exist in any of our state objects. Instead, the UI should read through the decision codes and have mapping
            //      mechanism that translates our decsion codes into key mappings for the given environment (PC, XBox, PS4, etc...)
            //      
            //      I have not done so for a couple of reasons. The first is time - I don't have it =)
            //      The other is that I would like for you to try and figure that part out if to can.
            sb.Append("Press Space to continue.");

            return sb.ToString();
        }

        //Your object should be in a competely valid state immediately after construction. Don't design objects that have a "load" or "init"
        //method that has to be called by a consumer after a "new" declaration. Doing so is like establishing a secret handshake that everyone 
        //that wants to use your object must know just to take advantage of some core business functionlaity. 
        //
        //Secret handshakes are for douchbags...
        public IntroductionGameState()
        {
            MessageToPlayer = GetMessageToPlayer();
            SceneName = "PrisonIntroScene";
            populateNextGameStateOptions();
        }

        private void populateNextGameStateOptions()
        {
            //I am only using "keyboard" key names for simplicity of this demonstration. In reality, the "Space" keyword should be something like
            //"CELL_INITIAL." I should then have a mapping of some kind that translates "CELL_INITIAL" to the Space Bar on a PC or the touch pad on a PS4 controller.
            //
            //The ideal option would be to establish an Options API (Option 1, Option 2, etc..) 
            //A state object would map it's "next states" to these options, while the presentation layer (Unity) would map environment appropriate keys to the same options.
            //Ex: IntroductionState maps "CellInitial" to "Option 1." In Unity, the PC key to choose any Option 1 (regardless of GameState) is the Space Bar whereas
            //the PS4 key for Option 1 could be Touch Pad. The difference is that "Space Bar" could never be used to select Option 2 on any other state.
            NextStateMapping.Add("Space", typeof(CellInitialVisitState));
        } 
    }
}
