using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife_01 : MonoBehaviour, ICatalog, IPickable
{
    public const string ID = "knife";

    IHolder holder;

    Vector3 pickPosition = new Vector3(-5f, 0.5f, -1.6f);
    Vector3 pickRotation = new Vector3(-24f, -26f, 0f);

    GameObject player;

    void Awake()
    {
        player = GameObject.Find("Guide");
    }

    void ICatalog.ShowCatalog(Object caller)
    {
        if (holder == null)
        {
            CatalogUtil.ShowMessage("Knife  -  Pick Up : Mouse Left");
        }
        else if (holder != null)
        {
            CatalogUtil.ShowMessage("Knife  -  Put Down : Mouse Left");
        }
    }

    IHolder IPickable.GetHolder()
    {
        return holder;
    }

    public int EnergyRequired()
    {
        return 0;
    }

    void IPickable.PickUp(IHolder holder)
    {
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

    string IDentifiable.GetId()
    {
        return ID;
    }
}
