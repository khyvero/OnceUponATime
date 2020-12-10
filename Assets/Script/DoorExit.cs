using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DoorExit : MonoBehaviour, IOpenable, ICatalog
{
    public const string ID = "doorExit";

    Animator animator;
    bool isOpen = false;
    bool isLock = true;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void ICatalog.ShowCatalog(Object caller)
    {
        CatalogUtil.ShowMessage("Door  -  Open : Mouse Right");
        
    }

    void IOpenable.OpenOrClose(IHolder holder)
    {

        if (!holder.CheckHasPickable("keyExit") && isLock)
        {
            isLock = true;
            animator.SetBool("lock", true);
            Debug.Log("door lock");
        }
        else if (holder.CheckHasPickable("keyExit"))
        {
            isLock = false;
        }
        if (!isOpen && !isLock)
        {
            animator.SetBool("open", true);
            isOpen = true;

            CountDownTimer.GetInstance().CountDown(1, () =>
            {
                Object.FindObjectOfType<GameStateApplied>().gameState.SwitchToWin();
                Cursor.lockState = CursorLockMode.None;
            });
            
        }
        
    }

    public bool IsOpen()
    {
        return isOpen;
    }
}
