using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWitchSecret : MonoBehaviour, ICatalog, IOpenable
{
    Animator animator;
    bool isOpen = false;
    bool isLock = true;

    AudioSource playerAudio;
    bool playerSaid = false;

    void Start()
    {
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

        if (!holder.CheckHasPickable("fork") && isLock)
        {
            isLock = true;
            if (!playerSaid)
            {
                CatalogUtil.ShowClueMessage("The door is locked, I need a key for this... " +
                "Or maybe I could use a small, sharp object to crack the lock of the door." +
                "\n\npress SPACE to close");
                playerAudio.Play();
                playerSaid = true;
            }
            
            Debug.Log("door lock");
        }
        else if (holder.CheckHasPickable("fork"))
        {
            isLock = false;
        }
        if (!isOpen && !isLock)
        {
            animator.SetBool("open", true);
            isOpen = true;
            isLock = false;

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
}
