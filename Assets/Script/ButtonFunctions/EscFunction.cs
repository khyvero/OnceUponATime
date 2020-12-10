using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscFunction : MonoBehaviour
{

    //private void Start()
    //{
    //    CatalogUtil.CloseEscMassage();

    //}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("esc click");
            //CatalogUtil.OpenEscMassage();
            Object.FindObjectOfType<GameStateApplied>().gameState.SwitchToMenu();
            Cursor.lockState = CursorLockMode.None;
        }
    }


}
