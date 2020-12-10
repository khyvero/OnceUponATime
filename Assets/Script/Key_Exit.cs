using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Exit : MonoBehaviour, IPickable, ICatalog
{
    public const string ID = "keyExit";

    IHolder holder;

    Vector3 pickPosition = new Vector3(1.4f, 0f, 0f);
    Vector3 pickRotation = new Vector3(-15f, -40f, 5f);

    GameObject player;

    bool msgShowed = false;

    AudioSource playerAudio;

    void Awake()
    {
        player = GameObject.Find("Guide");
        playerAudio = GetComponent<AudioSource>();
    }

    void ICatalog.ShowCatalog(Object caller)
    {
        if (holder == null)
        {
            CatalogUtil.ShowMessage("Key  -  Pick Up : Mouse Left");
        }
        else if (holder != null)
        {
            CatalogUtil.ShowMessage("Key  -  Put Down : Mouse Left");
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

            if (!msgShowed)
            {
                CatalogUtil.ShowClueMessage("This key must lead to the way out of here!" +
               "I know every room in this tower by heart, except from this one here... " +
               "I bet the exit is somewhere around here!\n\npress SPACE to close");
                playerAudio.Play();
                msgShowed = true;

            }
           
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
