using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BedsideTable_01 : MonoBehaviour, ICatalog, IOpenable
{
    public const string ID = "bedsideTable";

    Animator animator;
    bool isOpen = false;

    IHolder holder;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void ICatalog.ShowCatalog(Object caller)
    {
        if(!isOpen && holder == null){
            CatalogUtil.ShowMessage("Table  -  Open : Mouse Right");
        }
        else if (isOpen && holder == null){
            CatalogUtil.ShowMessage("Table  -  Close : Mouse Right");
        }
        //else if (holder != null){
        //    CatalogUtil.ShowMessage("Table - press R to put down");
        //}
        
    }

    void IOpenable.OpenOrClose(IHolder holder){
        if (!isOpen){
            animator.SetBool("open", true);
            isOpen = true;
        }
        else if (isOpen){
            animator.SetBool("open", false);
            isOpen = false;
        }
    }

    public bool IsOpen()
    {
        return isOpen;
    }
}

//IPickable

//IHolder IPickable.GetHolder(){
//    return holder;
//}

//public int EnergyRequired()
//{
//    return 30;
//}

//void IPickable.PickUp(IHolder holder) {
//    if (Input.GetKeyDown(KeyCode.R) && this.holder == null) {
//        Debug.Log("picking");
//holder.AddPickable(this);
//            this.holder = holder;
//GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
//GetComponent<Rigidbody>().isKinematic = true;
//transform.parent = player.transform;
//transform.localPosition = pickPosition;
//transform.localEulerAngles = pickRotation;

    //    }
    //}

//void IPickable.PutDown(IHolder holder)
//{
//        Debug.Log("put down");
//    if (Input.GetKeyDown(KeyCode.R) && this.holder != null)
//    {
//        Debug.Log("put down");
//        holder.RemovePickable(this);
//        this.holder = null;
//    }

//}

//string IDentifiable.GetId()
//{
//    return ID;
//}

