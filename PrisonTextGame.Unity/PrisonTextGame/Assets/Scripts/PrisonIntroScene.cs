using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    public class PrisonIntroScene : MonoBehaviour
    {
        private GameManager gameManagerScript { get { return GameManager.Instance; } }

        public Text messageToUserTextPlaceholder;
        
        public void Update()
        {
            messageToUserTextPlaceholder.text = gameManagerScript.MessageToPlayer;
        }
    }
}
