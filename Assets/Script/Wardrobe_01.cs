using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wardrobe_01 : MonoBehaviour, ICatalog, IOpenable, IPickable
{
    public const string ID = "wardrobe";

    public BoxCollider doorCollider;
    Animator animator;
    bool isOpen = false;

    IHolder holder;

    Vector3 pickPosition = new Vector3(-1.5f, 1.6f, 3.12f);
    Vector3 pickRotation = new Vector3(0f, 180f, 0f);

    GameObject player;

    void Awake()
    {
        player = GameObject.Find("Guide");
        animator = GetComponent<Animator>();
    }

    void ICatalog.ShowCatalog(Object caller)
    {
        if(!isOpen && holder == null){
            CatalogUtil.ShowMessage("Wardrobe  -  Pick Up : Mouse Left  ;  Open : Mouse Right");
        }
        else if (isOpen && holder == null){
            CatalogUtil.ShowMessage("Wardrobe  -  Close : Mouse Right");
        }
        else if (holder != null){
            CatalogUtil.ShowMessage("Wardrobe  -  Put Down : Mouse Left");
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

    //IPickable
    IHolder IPickable.GetHolder(){
        return holder;
    }

    public int EnergyRequired()
    {
        return 10;
    }

    void IPickable.PickUp(IHolder holder) {

        if (this.holder == null)
        {
            Debug.Log("picking");
            holder.AddPickable(this);
            this.holder = holder;
            GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = player.transform;
            transform.localPosition = pickPosition;
            transform.localEulerAngles = pickRotation;
        }
    }

    void IPickable.PutDown(IHolder holder)
    {
        if (this.holder != null)
        {
            Debug.Log("put down");
            transform.parent = null;
            Vector3 newPosition = transform.position;
            Vector3 newRotation = transform.eulerAngles;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            transform.localPosition = newPosition;
            transform.localEulerAngles = newRotation;
            holder.RemovePickable(this);
            this.holder = null;
        }
    }

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
//void OnTriggerStay(Collider item){
//Debug.Log("touch");
//if (item.gameObject.name == "guide"){
//(this as IOpenable).OpenOrClose();
//}

//}

//void OnTriggerExit(Collider item){
//Debug.Log("Exit");
//if (item.gameObject.name == "guide"){
//ObjectFactory.GetCanvas().SetActive(false);
//}
//}

