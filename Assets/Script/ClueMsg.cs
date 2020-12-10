using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueMsg : MonoBehaviour
{

    private void Start()
    {
        CatalogUtil.HideClue();
    }

    void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CatalogUtil.HideClue();
        }
    }
}
