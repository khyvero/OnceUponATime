using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorWitchRm : MonoBehaviour, IOpenable, ICatalog
{
    public static DoorWitchRm Instance;

    Animator animator;
    bool isOpen = false;
    bool isLock = true;

    AudioSource playerAudio;
    bool playerSaid = false;

    void Awake()
    {
        Instance = this;

        animator = GetComponent<Animator>();

        playerAudio = GetComponent<AudioSource>();
    }

    void ICatalog.ShowCatalog(Object caller)
    {

        if (!isOpen)
        {
            CatalogUtil.ShowMessage("Door  -  Open : Mouse Right");
        }
        else if (isOpen)
        {
            CatalogUtil.ShowMessage("Door  -  Close : Mouse Right");
        }
    }

    void IOpenable.OpenOrClose(IHolder holder)
    {

        if (!holder.CheckHasPickable("keyWitchRm") && isLock)
        {
            CatalogUtil.ShowClueMessage("I cannot open it, I need a key!" +
                "\n\npress SPACE to close");
            isLock = true;
        }
        else if (holder.CheckHasPickable("keyWitchRm"))
        {
            Debug.Log("door is unLock");
            isLock = false;
        }

        if (!isOpen && !isLock && !playerSaid)
        {
            animator.SetBool("open", true);
            isOpen = true;
            playerAudio.Play();
            playerSaid = true;
        }

        else if (!isOpen && !isLock)
        {
            animator.SetBool("open", true);
            isOpen = true;
        }
        else if (isOpen)
        {
            Debug.Log("close door");
            animator.SetBool("open", false);
            isOpen = false;
        }
    }

    public bool IsOpen()
    {
        return isOpen;
    }

    public bool GetIsOpen()
    {
        return isOpen;
    }
}
