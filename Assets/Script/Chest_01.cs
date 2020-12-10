using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest_01 : MonoBehaviour, IOpenable, ICatalog
{
    Animator animator;
    bool isOpen = false;
    bool isLock = true;

    public Collider cover;

    public const string ID = "chest";

    AudioSource playerAudio;

    bool playerSaid = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
        cover.enabled = true;
        playerAudio = GetComponent<AudioSource>();

    }

    void ICatalog.ShowCatalog(Object caller)
    {
        if(!isOpen){
            CatalogUtil.ShowMessage("Chest  -  Open : Mouse Right");
        }
        else if(isOpen){
            CatalogUtil.ShowMessage("Chest  -  Close : Mouse Right");
        }

        
        
    }

    void IOpenable.OpenOrClose(IHolder holder){
       
        if (holder.GetPickables().Count == 0)
        {
            isLock = true;
            CatalogUtil.ShowClueMessage("The Chest is locked, I need something to open it." +
                "\n\npress SPACE to close");
        }

        else if (!holder.CheckHasPickable("bobbyPin") && isLock)
        {
            isLock = true;

            if (!playerSaid)
            {
                CatalogUtil.ShowClueMessage("This chest is locked... The lock is very small... " +
                "If I‘m not able to find such a small key, maybe I can find some other tiny object " +
                "that I could use to crack the lock.\n\npress SPACE to close");
                playerAudio.Play();
                playerSaid = true;
            }

        }
        
        else if (holder.CheckHasPickable("bobbyPin")){
            isLock = false;
        }

        if (!isOpen && !isLock){
            animator.SetBool("open", true);
            cover.enabled = false;
            isOpen = true;
            isLock = false;
        }
        else if (isOpen){
            Debug.Log("close door");
            animator.SetBool("open", false);
            cover.enabled = true;
            isOpen = false;
        }
    }
    public bool IsOpen()
    {
        return isOpen;
    }
}
