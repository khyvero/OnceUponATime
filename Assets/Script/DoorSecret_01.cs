using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorSecret_01 : MonoBehaviour, ICatalog, IOpenable
{
    Animator animator;
    bool isOpen = false;
    bool isLock = true;


    AudioSource playerAudio;


    void Awake()
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

        if (!holder.CheckHasPickable("keySecret") && isLock)
        {
            isLock = true;
            CatalogUtil.ShowClueMessage("This door is locked, I need a Key for this." +
                "\n\npress SPACE to close");
            Debug.Log("door lock");

        }
        else if (holder.CheckHasPickable("keySecret"))
        {
            isLock = false;
            CatalogUtil.ShowClueMessage("How weird is this? " +
                "There is a secret room behind my wardrobe with just a chest inside? " +
                "My mother is definitely trying to hide something from me." +
                "\n\npress SPACE to close");
            playerAudio.Play();
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
            isLock = false;
        }
    }

    public bool IsOpen()
    {
        return isOpen;
    }

}