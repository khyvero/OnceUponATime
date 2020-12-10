using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket_01 : MonoBehaviour, ICatalog, IPickable, IFillable
{
    public const string ID = "bucket";

    string idString;

    IHolder holder;

    Vector3 pickPosition = new Vector3(0.17f, -0.9f, 1.7f);
    Vector3 pickRotation = new Vector3(0f, 270f, 0f);

    GameObject player;

    bool isEmpty;
    bool isPicking;
    bool thrown;

    Animator animator;

    void Awake()
    {
        player = GameObject.Find("Guide");
        animator = GetComponent<Animator>();

        isEmpty = true;
        isPicking = false;
        thrown = false;
    }

    void ICatalog.ShowCatalog(Object caller)
    {
        if (holder == null)
        {
            CatalogUtil.ShowMessage("Bucket  -  Pick Up : Mouse Left");
        }

        else if (holder != null)
        {
            CatalogUtil.ShowMessage("Bucket  -  Put Down : Mouse Left");
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
            CountDownTimer.GetInstance().CountDown(1, () =>
            {
                GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
                GetComponent<Rigidbody>().isKinematic = true;
                transform.parent = player.transform;
                transform.localPosition = pickPosition;
                transform.localEulerAngles = pickRotation;
            });
            if (isEmpty && !isPicking)
            {
                animator.SetInteger("BucketStates", 1);
                isPicking = true;
            }
            else if (!isEmpty && !isPicking)
            {
                animator.SetInteger("BucketStates", 5);
                isPicking = true;
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
            if (isEmpty && isPicking && !thrown)
            {
                animator.SetInteger("BucketStates", 2);
                isPicking = false;
            }
            else if (!isEmpty && isPicking && thrown)
            {
                animator.SetInteger("BucketStates", 4);
                isPicking = false;
            }
            else if(isEmpty && isPicking && thrown)
            {
                animator.SetInteger("BucketStates", 7);
                isPicking = false;
            }

            holder.RemovePickable(this);
            this.holder = null;
        }
    }

    string IDentifiable.GetId()
    {
        return ID;
    }


   void IFillable.Fill()
    {
        if (isEmpty)
        {
            Debug.Log("fill water");
            animator.SetInteger("BucketStates", 3);
            isEmpty = false;
            thrown = false;

        }
        
    }

    void IFillable.Throw()
    {
        if (!isEmpty)
        {
            Debug.Log("Throw water");
            animator.SetInteger("BucketStates", 6);
            isEmpty = true;
            thrown = true;
        }
        
    }

    bool IFillable.IsEmpty()
    {
        return isEmpty;
    }

   
}

