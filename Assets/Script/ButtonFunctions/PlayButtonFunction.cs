using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonFunction : MonoBehaviour
{
    public void PlayButtonClicked()
    {
        Debug.Log("The Play button has been pressed!");

        Object.FindObjectOfType<GameStateApplied>().gameState.SwitchToIntro();
    }
}
