using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryRapunzel : MonoBehaviour, ICatalog, IOpenable,  IPickable
{
    public const string ID = "diaryRapunzel";

    Animator animator;
    bool isOpen = false;
    

    IHolder diaryHolder;

    Vector3 pickPosition = new Vector3(0.2f, 1.4f, -0.8f);
    Vector3 pickRotation = new Vector3(-55f, 0f, 0f);

    GameObject player;

    AudioSource playerAudio;

    bool playerSaid = false;


    void Awake()
    {
        player = GameObject.Find("Guide");
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    void ICatalog.ShowCatalog(Object caller)
    {
        if (!isOpen && diaryHolder == null)
        {
            CatalogUtil.ShowMessage("Diary  -  Pick Up : Mouse Right");
        }
        else if (!isOpen && diaryHolder != null)
        {
            CatalogUtil.ShowMessage("Diary  -  Open : Mouse Right  ;  Put Down : Mouse Left");
        }

        else if (isOpen && diaryHolder != null)
        {
            CatalogUtil.ShowMessage("Diary  -  Close : Mouse Right");
        }


    }

    void IOpenable.OpenOrClose(IHolder holder)
    {
            if (!isOpen && diaryHolder != null)
            {
                animator.SetBool("open", true);
                isOpen = true;

            if (!playerSaid)
                {
                    playerAudio.Play();
                    playerSaid = true;
                }
            }
            else if (isOpen && diaryHolder != null)
            {
                animator.SetBool("open", false);
                isOpen = false;
            }
    }

    public bool IsOpen()
    {
        return isOpen;
    }

    IHolder IPickable.GetHolder()
    {
        return diaryHolder;
    }

    public int EnergyRequired()
    {
        return 0;
    }

    void IPickable.PickUp(IHolder holder)
    {

        if (this.diaryHolder == null)
        {
            Debug.Log("picking");
            holder.AddPickable(this);
            this.diaryHolder = holder;
            //CatalogUtil.ShowClueMessage("\n\npress SPACE to close");
            GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = player.transform;
            transform.localPosition = pickPosition;
            transform.localEulerAngles = pickRotation;
        }
    }

    void IPickable.PutDown(IHolder holder)
    {
        if (this.diaryHolder != null)
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
            this.diaryHolder = null;
        }
    }

    string IDentifiable.GetId()
    {
        return ID;
    }


}
