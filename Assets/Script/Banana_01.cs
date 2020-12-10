using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana_01 : MonoBehaviour, ICatalog, IFood
{
    public const string ID = "food_banana";

    IHolder holder;
    IEater eater;

    Vector3 pickPosition = new Vector3(1f, 0f, 3f);
    Vector3 pickRotation = new Vector3(-13f, 30f, 14f);

    GameObject player;
    ParticleSystem particles;

    void Awake()
    {
        player = GameObject.Find("Guide");
        particles = GetComponentInChildren<ParticleSystem>();
    }

    void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CatalogUtil.HideClue();
        }
    }

    void ICatalog.ShowCatalog(Object caller)
    {
        if (holder == null)
        {
            CatalogUtil.ShowMessage("Banana - press E to eat or press R to pick up");
        }
        else if (holder != null)
        {
            CatalogUtil.ShowMessage("Banana - press E to eat or press R to put down");
        }

    }

    //IPickable
    IHolder IPickable.GetHolder()
    {
        return holder;
    }

    public int EnergyRequired()
    {
        return 5;
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
        if (Input.GetKeyDown(KeyCode.R))
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

    //IFood
    IEater IFood.GetEater()
    {
        return eater;
    }

    bool IFood.IsFor(IEater eater)
    {
        return eater.GetId().Equals(PlayerAction.ID);
    }

    void IFood.EatenBy(IEater eater)
    {
        if (Input.GetKeyDown(KeyCode.E) && (this as IFood).IsFor(eater))
        {
            this.eater = eater;
            particles.Play();
            CountDownTimer.GetInstance().CountDown(1, () =>
            {
                player.GetComponent<BoxCollider>().enabled = false;
                GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
                gameObject.SetActive(false);
                CatalogUtil.ShowClueMessage("Mhh tasty, I feel much stronger now! \n\n press SPACE to close");
            });
            //CountDownTimer.GetInstance().CountDown(100, () =>
            //{
            //    gameObject.SetActive(true);
            //});
            
        }
    }

    public int GetEnergy()
    {
        return 10;
    }

    string IDentifiable.GetId()
    {
        return ID;
    }

    public override bool Equals(object value)
    {
        Banana_01 banana = value as Banana_01;

        return (banana != null)
            && (this as IDentifiable).GetId().Equals((banana as IDentifiable).GetId());
    }

    public override int GetHashCode()
    {
        int hash = 13;
        hash = (hash * 7) + (this as IDentifiable).GetId().GetHashCode();
        return hash;
    }

}