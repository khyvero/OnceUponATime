using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonFunction : MonoBehaviour
{
    public void MenuButtonClicked()
    {
        Debug.Log("The Menu button has been pressed!");

        Object.FindObjectOfType<GameStateApplied>().gameState.SwitchToMenu();
    }
}
