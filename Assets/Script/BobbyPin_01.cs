using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobbyPin_01 : MonoBehaviour, ICatalog, IPickable
{
    public const string ID = "bobbyPin";

    IHolder holder;

    Vector3 pickPosition = new Vector3(-4.4f, 3f, -2f);
    Vector3 pickRotation = new Vector3(22f, 73f, -35f);

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
        if (holder == null)
        {
            CatalogUtil.ShowMessage("Bobby Pin  -  Pick Up : Mouse Left");
        }

        else if (holder != null)
        {
            CatalogUtil.ShowMessage("Bobby Pin  -  Put Down : Mouse Left");
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
            CatalogUtil.ShowClueMessage("I need hundreds of those bobby pins to get my hair done... " +
                "and I always seem to loose them somewhere because they are so small... " +
                "\n\n press SPACE to close");
            if (!playerSaid)
            {
                playerAudio.Play();
                playerSaid = true;
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
