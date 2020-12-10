using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyDress : MonoBehaviour, IPickable, ICatalog
{
    public const string ID = "babyDress";

    IHolder holder;

    Vector3 pickPosition = new Vector3(0f, 1f, 1f);
    Vector3 pickRotation = new Vector3(-0.5f, -107f, -2f);

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
            CatalogUtil.ShowMessage("Baby Dress  -  Pick Up : Mouse Left");
        }
        else if (holder != null)
        {
            CatalogUtil.ShowMessage("Baby Dress  -  Put Down : Mouse Left");
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

            if (!playerSaid)
            {
                CatalogUtil.ShowClueMessage("Hey why shoud my mother hide this from me in her room? " +
                "I recognise this little Dress, its from the baby girl on the photograph. But why is it here? " +
                "Does it belong do me? Am i this little girl? Is the family from the photo my real family?\n\npress SPACE to close");
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
