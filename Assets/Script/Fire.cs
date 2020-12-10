using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour, ICatalog, IOpenable, IDentifiable
{
    public const string ID = "fire";

    public BoxCollider fireCollider;

    ParticleSystem fireParticles;
    ParticleSystem smokeParticles;

    public BoxCollider key_secretCollider;

    bool onFire = true;

    GameObject bucket;

    bool bucketIsEmpty = true;


    void Awake()
    {
        fireParticles = GetComponentInChildren<ParticleSystem>();
        smokeParticles = GetComponentsInChildren<ParticleSystem>()[1];
        fireParticles.Play();
        smokeParticles.Play();
        key_secretCollider.enabled = false;

        bucket = GameObject.Find("Bucket_01");

    }

    void Update()
    {
        IFillable fillable = bucket.GetComponent<IFillable>();

        if (fillable != null && !fillable.IsEmpty())
        {
            bucketIsEmpty = false;
        }

        Debug.Log(bucketIsEmpty);
    }

    void ICatalog.ShowCatalog(Object caller)
    {
        if (onFire)
        {
            CatalogUtil.ShowMessage("Fire  -  Look : Mouse Right");
            
        }
        if (onFire && !bucketIsEmpty)
        {
            CatalogUtil.ShowMessage("Fire  -  Slack : Mouse Right");
        }
    }

    void IOpenable.OpenOrClose(IHolder holder)
    {
        if (onFire)
        {
            if (!holder.CheckHasPickable("bucket") || bucketIsEmpty)
            {
                CatalogUtil.ShowClueMessage("I should find water to put off." +
                "\n\npress SPACE to close");
            }
            
            if(holder.CheckHasPickable("bucket") && !bucketIsEmpty)
            {
                Debug.Log(bucketIsEmpty);
                CountDownTimer.GetInstance().CountDown(1, () =>
                {
                    Debug.Log("fire off");
                    fireParticles.Stop();
                    fireCollider.enabled = false;
                    key_secretCollider.enabled = true;
                    onFire = false;
                });

                CountDownTimer.GetInstance().CountDown(2, () =>
                {
                    Debug.Log("fire off");
                    smokeParticles.Stop();
                    onFire = false;
                });
            }
        }
       
    }

    public bool IsOpen()
    {
        return onFire;
    }
    public string GetId()
    {
        return ID;
    }
}
