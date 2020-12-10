using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipToMenu : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SkipButtonClicked();
        }
    }
    public void SkipButtonClicked()
    {
        Debug.Log("pressed!");
        Object.FindObjectOfType<GameStateApplied>().gameState.SwitchToMenu();

    }
}
