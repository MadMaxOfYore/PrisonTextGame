using UnityEngine;
using PrisonTextGame.Core.Entities;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    internal static GameManager Instance { get; set; }

    private List<KeyCode> actionKeys;
    private GameContext Context { get; set; }
    
    internal string MessageToPlayer { get; private set; }

    //This is a simple method of synchronizing access to shared resources in a multithreaded environment. 
    //If we have detected a valid key press and are changing game state, then there is a chance that the next frame could trigger an update before our state change is complete.
    //If that happens, then we will be looping through the ActiveKeys collection while also changing the referece to the collection - big no, no.
    //By using a spinlock in the getter/setter as I've done here, we ensure that the reference to the collection is kept clean and we do not get dirty reads.
    //Additionally, we lock on the same blocker object during frame update to ensure that the collection is not replaced while we are iterating over it.
    private object actionKeysAccessBlocker = new object();
    private List<KeyCode> ActionKeys
    {
        get
        {
            lock (actionKeysAccessBlocker)
            {
                return actionKeys;
            }
        }
        set
        {
            lock (actionKeysAccessBlocker)
            {
                actionKeys = value;
            }
        }
    }

    void Awake ()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameObject);
        
        Context = new GameContext();
        UpdateUI();
    }
	
	void Update ()
    {
        lock (actionKeysAccessBlocker)
        {
            foreach (KeyCode actionKey in ActionKeys)
            {
                if (Input.GetKeyDown(actionKey))
                {
                    var decisionCode = System.Enum.GetName(typeof(KeyCode), actionKey);
                    Context.ProcessDecision(decisionCode);

                    UpdateUI();
                }
            }
        }
	}

    private void UpdateUI()
    {
        MessageToPlayer = Context.MessageToPlayer;

        var actionKeysList = new List<KeyCode>();

        foreach (string decisionCode in Context.CurrentDecisionCodes)
        {
            var mappedKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), decisionCode);
            actionKeysList.Add(mappedKeyCode);
        }

        ActionKeys = actionKeysList;
        SceneManager.LoadScene(Context.CurrentScene);
    }
}
