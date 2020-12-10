using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilet_01 : MonoBehaviour, IOpenable, ICatalog
{
    public const string ID = "toilet";

    Animator animator;
    bool isOpen = false;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void ICatalog.ShowCatalog(Object caller)
    {
        if (!isOpen)
        {
            CatalogUtil.ShowMessage("Toilet  -  Open : Mouse Right");
        }
        else if (isOpen )
        {
            CatalogUtil.ShowMessage("Toilet  -  Close : Mouse Right");
        }
        
    }

    void IOpenable.OpenOrClose(IHolder holder)
    {
        if (!isOpen)
        {
            animator.SetBool("open", true);
            isOpen = true;
        }
        else if (isOpen)
        {
            animator.SetBool("open", false);
            isOpen = false;
        }
    }

    public bool IsOpen()
    {
        return isOpen;
    }
}
