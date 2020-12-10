using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButtonFunction : MonoBehaviour
{
    public void QuitButtonClicked()
    {
        Debug.Log("The Quit button has been pressed!");

        Object.FindObjectOfType<GameStateApplied>().gameState.QuitGame();
    }
}
