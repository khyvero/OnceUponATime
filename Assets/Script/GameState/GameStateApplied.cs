using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateApplied : MonoBehaviour
{
    public GameState gameState;

    void Start()
    {
        // Make sure this GameObject stays in the hierarchy when scenes switch
        DontDestroyOnLoad(this);
    
        gameState = new GameState();

        Debug.Log("Initialised GameState code object.");
        Debug.Log("The current state is: " + gameState.CurrentState);

        Debug.Log("Now attempting to switch to Menu state.");
        gameState.SwitchToMenu();
    }
}
