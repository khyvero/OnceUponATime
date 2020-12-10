using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key_Secret_01 : MonoBehaviour,IPickable, ICatalog
{
    
    IHolder holder;

    Vector3 pickPosition = new Vector3(2.5f, 0.8f, 1f);
    Vector3 pickRotation = new Vector3(-8.5f, -48f, 9f);

    public const string ID = "keySecret";

    GameObject player;


    void Awake()
    {
        player = GameObject.Find("Guide");
    }


   public void ShowCatalog(Object caller)
    {
        if(holder == null){
            CatalogUtil.ShowMessage("Key  -  Pick Up : Mouse Left");
        }
        else if (holder != null){
            CatalogUtil.ShowMessage("Key  -  Put Down : Mouse Left");
        }
    }

    public IHolder GetHolder(){
        return holder;
    }

    public int EnergyRequired()
    {
        return 0;
    }

    public void PickUp(IHolder holder) {
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

        Key_Secret_01 key = value as Key_Secret_01;

        return (key != null)
            && (this.GetId().Equals(key.GetId()));
    }

    public override int GetHashCode()
    {
        int hash = 13;
        hash = (hash * 7) + this.GetId().GetHashCode();
        return hash;
    }
}
