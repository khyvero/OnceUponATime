using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyPic : MonoBehaviour,IPickable, ICatalog
{
    public const string ID = "photo";

    IHolder holder;

    Vector3 pickPosition = new Vector3(0f, 1.4f, -0.6f);
    Vector3 pickRotation = new Vector3(-120f, -180f, 0f);

    GameObject player;

    AudioSource playerAudio;
    bool playerSaid = false;

    void Start()
    {
        player = GameObject.Find("Guide");
        playerAudio = GetComponent<AudioSource>();
    }

    void ICatalog.ShowCatalog(Object caller)
    {
        if (holder == null)
        {
            CatalogUtil.ShowMessage("Photo  -  Pick Up : Mouse Left");
        }
        else if (holder != null)
        {
            CatalogUtil.ShowMessage("Photo  -  Put Down : Mouse Left");
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
            
            player.GetComponent<BoxCollider>().enabled = true;
            GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = player.transform;
            transform.localPosition = pickPosition;
            transform.localEulerAngles = pickRotation;

            if (!playerSaid)
            {
                CatalogUtil.ShowClueMessage("Wow, that looks like a cute happy family! I wonder who that was..." +
                    "And why is my mother keeping this picture here, under my old childhood toys ?\n\npress SPACE to close");
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
