using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Necklace_01 : MonoBehaviour, ICatalog, IPickable
{
    public const string ID = "necklace_01";

    IHolder holder;

    Vector3 pickPosition = new Vector3(0f, 1f, 1.5f);
    Vector3 pickRotation = new Vector3(-30f, -32f, 66.5f);

    GameObject player;

    AudioSource playerAudio;
    bool playerSaid = false;

    void Awake()
    {
        player = GameObject.Find("Guide");
        playerAudio = GetComponent<AudioSource>();
    }


    void ICatalog.ShowCatalog(Object caller)
    {
        if(holder == null){
            CatalogUtil.ShowMessage("Necklace  -  Pick Up : Mouse Left");
        }
        else if (holder != null){
            CatalogUtil.ShowMessage("Necklace  -  Put Down : Mouse Left");
        }
    }

    IHolder IPickable.GetHolder(){
        return holder;
    }

    public int EnergyRequired()
    {
        return 0;
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

            if (!playerSaid)
            {
                CatalogUtil.ShowClueMessage("This Necklace belongs to me ever since I am living. " +
                "It always gives me a save feeling of beeing home.\n\npress SPACE to close");
                playerAudio.Play();
                playerSaid = true;
            }
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
