using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove_01 : MonoBehaviour, ICatalog, IOpenable
{
    public const string ID = "stove";

    Animator animator;
    bool isOpen = false;

    IHolder holder;

    public BoxCollider doorCollider;


    void Awake()
    {
        animator = GetComponent<Animator>();
      
    }

    void ICatalog.ShowCatalog(Object caller)
    {
       
        if (!isOpen)
        {
            CatalogUtil.ShowMessage("Oven  -  Open : Mouse Right");
        }
        else if (isOpen)
        {
            CatalogUtil.ShowMessage("Oven  -  Close : Mouse Right");
        }

    }

    void IOpenable.OpenOrClose(IHolder holder)
    {
        if (!isOpen)
        {
            animator.SetBool("open", true);
            isOpen = true;
            doorCollider.enabled = false;
        }
        else if (isOpen)
        {
            animator.SetBool("open", false);
            isOpen = false;
            doorCollider.enabled = true;
        }
    }

    public bool IsOpen()
    {
        return isOpen;
    }
}
