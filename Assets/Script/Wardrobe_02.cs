using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wardrobe_02 : MonoBehaviour, ICatalog, IOpenable
{
    public const string ID = "wardrobe_02";

    public BoxCollider doorCollider;
    Animator animator;
    bool isOpen = false;

    IHolder holder;

    GameObject player;

    void Awake()
    {
        player = GameObject.Find("Guide");
        animator = GetComponent<Animator>();
    }

    void ICatalog.ShowCatalog(Object caller)
    {
        if(!isOpen){
            CatalogUtil.ShowMessage("Wardrobe  -  Open : Mouse Right");
        }
        else if (isOpen){
            CatalogUtil.ShowMessage("Wardrobe  -  Close : Mouse Right");
        }
        
    }

    void IOpenable.OpenOrClose(IHolder holder){
        if (!isOpen){
            animator.SetBool("open", true);
            doorCollider.enabled = false;
            isOpen = true;
        }
        else if (isOpen){
            animator.SetBool("open", false);
            doorCollider.enabled = true;
            isOpen = false;
        }
    }

    public bool IsOpen()
    {
        return isOpen;
    }

    ////IPickable
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

    public string GetId()
    {
        return ID;
    }

    public override bool Equals(object value)
    {

        Wardrobe_01 wardrobe_01 = value as Wardrobe_01;

        return (wardrobe_01 != null)
            && (this.GetId().Equals(wardrobe_01.GetId()));
    }

    public override int GetHashCode()
    {
        int hash = 13;
        hash = (hash * 7) + this.GetId().GetHashCode();
        return hash;
    }

}

