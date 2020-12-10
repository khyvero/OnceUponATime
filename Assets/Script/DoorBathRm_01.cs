using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorBathRm_01 : MonoBehaviour, ICatalog, IOpenable
{
   Animator animator;
    bool isOpen = false;
    
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void ICatalog.ShowCatalog(Object caller)
    {
        
        if(!isOpen){
            CatalogUtil.ShowMessage("Door  -  Open : Mouse Right");
        }
        else if(isOpen){
            CatalogUtil.ShowMessage("Door  -  Close : Mouse Right");
        }
    }

    void IOpenable.OpenOrClose(IHolder holder){

        if (!isOpen ){
            animator.SetBool("open", true);
            isOpen = true;

            CountDownTimer.GetInstance().CountDown(1, () =>
            {
                Bird_01.GetInstance().Show();
            });
        }
        else if (isOpen){
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
