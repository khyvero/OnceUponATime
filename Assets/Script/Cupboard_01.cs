using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cupboard_01 : MonoBehaviour,ICatalog, IOpenable
{
    public const string ID = "cupboard";

    Animator animator;
    bool isOpen = false;

    IHolder holder;

    //Vector3 pickPosition = new Vector3(1f, 0f, 3f);
    //Vector3 pickRotation = new Vector3(-13f, 30f, 14f);

    GameObject player;
    
    
    void Awake()
    {
        player = GameObject.Find("Guide");
        animator = GetComponent<Animator>();
    }

    void ICatalog.ShowCatalog(Object caller)
    {
        
        if (!isOpen){
            CatalogUtil.ShowMessage("Cupboad  -  Open : Mouse Right");
        }
        else if (isOpen){
            CatalogUtil.ShowMessage("Cupboad  -  Close : Mouse Right");
        }
        
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

    //IHolder IPickable.GetHolder(){
    //    return holder;
    //}

    //public int EnergyRequired()
    //{
    //    return 10;
    //}

    //void IPickable.PickUp(IHolder holder) {
    //    if (this.holder == null)
    //    {
    //        Debug.Log("picking");
    //        holder.AddPickable(this);
    //        this.holder = holder;
    //        GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
    //        GetComponent<Rigidbody>().isKinematic = true;
    //        transform.parent = player.transform;
    //        transform.localPosition = pickPosition;
    //        transform.localEulerAngles = pickRotation;
    //    }
    //}

    //void IPickable.PutDown(IHolder holder)
    //{

    //    if (this.holder != null)
    //    {
    //        Debug.Log("put down");
    //        transform.parent = null;
    //        Vector3 newPosition = transform.position;
    //        Vector3 newRotation = transform.eulerAngles;
    //        GetComponent<Rigidbody>().isKinematic = false;
    //        GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    //        transform.localPosition = newPosition;
    //        transform.localEulerAngles = newRotation;
    //        holder.RemovePickable(this);
    //        this.holder = null;
    //    }
    //}

    //string IDentifiable.GetId()
    //{
    //    return ID;
    //}

}
