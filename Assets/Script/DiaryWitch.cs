using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaryWitch : MonoBehaviour, ICatalog, IOpenable, IPickable
{
    public const string ID = "diaryWitch";

    Animator animator;
    bool isOpen = false;

    IHolder diaryHolder;

    Vector3 pickPosition = new Vector3(0.2f, 1.4f, -0.8f);
    Vector3 pickRotation = new Vector3(-55f, 0f, 0f);

    GameObject player;


    void Awake()
    {
        player = GameObject.Find("Guide");
        animator = GetComponent<Animator>();
    }

    void ICatalog.ShowCatalog(Object caller)
    {
        if (!isOpen && diaryHolder == null)
        {
            CatalogUtil.ShowMessage("Diary  -  Pick Up : Mouse Right");
        }
        else if (!isOpen && diaryHolder != null)
        {
            CatalogUtil.ShowMessage("Diary  -  Open : Mouse Right ; Put Down : Mouse Left");
        }
        else if (isOpen && diaryHolder != null)
        {
            CatalogUtil.ShowMessage("Diary  -  Close : Mouse Right");
        }
    }

    void IOpenable.OpenOrClose(IHolder holder)
    {
        if (!isOpen && holder != null)
        {
            animator.SetBool("open", true);
            isOpen = true;
        }
        else if (isOpen && holder != null)
        {
            animator.SetBool("open", false);
            CatalogUtil.ShowClueMessage("This is unbelievable, she is sick! " +
                "She is a liar and she betrayed me for all my live! " +
                "I really do have a different family! I need to get out of here immediately!" +
                "\n\npress SPACE to close");
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
