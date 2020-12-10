using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipToCredit : MonoBehaviour
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
        Debug.Log("In Win The Skip button has been pressed!");

        Object.FindObjectOfType<GameStateApplied>().gameState.SwitchToCredit();
    }
}
