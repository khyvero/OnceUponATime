using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple_01 : MonoBehaviour, ICatalog, IFood
{
    public const string ID = "food_apple";

    IHolder holder;
    IEater eater;

    Vector3 pickPosition = new Vector3(2f, -0.2f, 2.5f);
    Vector3 pickRotation = new Vector3(0f, 0f, 0f);

    GameObject player;
    ParticleSystem particles;

    void Awake()
    {
        player = GameObject.Find("Guide");
        particles = GetComponentInChildren<ParticleSystem>();
    }

    void ICatalog.ShowCatalog(Object caller)
    {
        if (holder == null)
        {
            CatalogUtil.ShowMessage("Apple  -  Pick Up : Mouse Left");
        }
        else if (holder != null)
        {
            CatalogUtil.ShowMessage("Apple  -  Eat : Space  ;  Put Down : Mouse Left");
        }
    }

    //IPickable
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
            //Destroy(gameObject);
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
            player.GetComponent<BoxCollider>().enabled = false;
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
        if ((this as IFood).IsFor(eater))
            Debug.Log("eating apple");
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
        Apple_01 apple = value as Apple_01;

        return (apple != null)
            && (this as IDentifiable).GetId().Equals((apple as IDentifiable).GetId());
    }

    public override int GetHashCode()
    {
        int hash = 13;
        hash = (hash * 7) + (this as IDentifiable).GetId().GetHashCode();
        return hash;
    }
}