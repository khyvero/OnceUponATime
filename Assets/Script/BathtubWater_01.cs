using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathtubWater_01 : MonoBehaviour, ICatalog, IOpenable, IDentifiable
{
    public const string ID = "bathtubWater";

    GameObject water;

    ParticleSystem waterParticles;
    MeshRenderer waterMeshRenderer;

    bool isOpen = false;

    IHolder holder;

    private void Awake()
    {
        water = GameObject.Find("tubWaterCtrl_tubWater");
        waterParticles = water.GetComponentInChildren<ParticleSystem>();
        waterMeshRenderer = water.GetComponent<MeshRenderer>();
        waterMeshRenderer.material.SetFloat("_Cutoff", 1);
        water.SetActive(false);
    }


    void ICatalog.ShowCatalog(Object caller)
    {
        if (!isOpen)
        {
            CatalogUtil.ShowMessage("Handle  -  Switch On : Mouse Right");
        }
        else if (isOpen)
        {
            CatalogUtil.ShowMessage("Handle  -  Switch Off : Mouse Right");
        }
    }

    void IOpenable.OpenOrClose(IHolder holder)
    {
        if (!isOpen)
        {
            water.SetActive(true);
            UpdateSinkWater(0);
            waterParticles.Play();
            isOpen = true;
        }
        else if (isOpen)
        {
            UpdateSinkWater(1);
            water.SetActive(false);
            isOpen = false;
        }
    }

    public bool IsOpen()
    {
        return isOpen;
    }


    //private void OnTriggerStay(Collider other)
    //{
    //    Debug.Log("touch water");
    //    UpdateSinkWater(GetHeight(other));
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    Debug.Log("touch water");
    //    UpdateSinkWater(0);
    //}

    //float GetHeight(Collider collider)
    //{
    //    return collider.transform.position.y + collider.bounds.size.y;
    //}

    void UpdateSinkWater(float newHeight)
    {
        Vector3 newPosition = new Vector3(transform.position.x, newHeight, transform.position.z);
        waterParticles.transform.position = newPosition;

        newHeight /= transform.localScale.y;
        waterMeshRenderer.material.SetFloat("_Cutoff", newHeight);
        Debug.Log(newHeight);
    }

    public string GetId()
    {
        return ID;
    }
}
