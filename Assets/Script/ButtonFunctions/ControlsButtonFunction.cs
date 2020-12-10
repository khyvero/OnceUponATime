using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsButtonFunction : MonoBehaviour
{
    public void ControlsButtonClicked()
    {
        Debug.Log("The Controls button has been pressed!");

        Object.FindObjectOfType<GameStateApplied>().gameState.SwitchToControls();
    }
}
