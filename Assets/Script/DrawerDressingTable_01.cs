using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerDressingTable_01 : MonoBehaviour, IOpenable, ICatalog
{
    public const string ID = "drawer";

    Animator animator;
    bool isOpen = false;

    public BoxCollider drawerCollider;


    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void ICatalog.ShowCatalog(Object caller)
    {

        if (!isOpen)
        {
            CatalogUtil.ShowMessage("Drawer  -  Open : Mouse Right");
        }
        else if (isOpen)
        {
            CatalogUtil.ShowMessage("Drawer  -  Close : Mouse right");
        }
    }

    void IOpenable.OpenOrClose(IHolder holder)
    {

        if (!isOpen)
        {
            animator.SetBool("open", true);
            isOpen = true;
            drawerCollider.enabled = false;

            //CountDownTimer.GetInstance().CountDown(20, () =>
            //{
            //    Bird_01.GetInstance().Show();
            //});
        }
        else if (isOpen)
        {
            Debug.Log("close");
            animator.SetBool("open", false);
            isOpen = false;
            drawerCollider.enabled = true;
        }
    }

    public bool IsOpen()
    {
        return isOpen;
    }
}
