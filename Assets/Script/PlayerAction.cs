using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour, IHolder, IEater
{
    public static PlayerAction Instance;

    public const string ID = "PLAYER";

    float interactDistance = 5f;

    List<IPickable> pickables =  new List<IPickable>();

    int energy;

    public AudioSource playerAudio;
    

    void Awake()
    {
        Instance = this;
        

    // Start is called before the first frame update
    void Start()
    {

            CatalogUtil.ClearCatalog();
            CatalogUtil.HideClue();
            energy = 10;
        }
    }

    //IHolder
    public List<IPickable> GetPickables(){
        return pickables;
    }

    public void RemovePickable(IPickable pickable){
        this.pickables.Remove(pickable);
    }

    public bool CheckHasPickable(string pickableId){
       foreach(IPickable p in pickables){
           if(p.GetId().StartsWith(pickableId)){
               return true;
           }
       }

       return false;
    }

    public void AddPickable(IPickable pickable){
        this.pickables.Add(pickable);
    }

    //IEater
    public List<IFood> GetFoodList(){
        List<IFood> result = new List<IFood>();
        foreach(IPickable p in pickables)
        {
            if(p is IFood)
            {
                result.Add((p as IFood));
            }
        }
        return result;
    }


    public bool CheckHasFood (string foodId){
        List<IFood> result = new List<IFood>();
        foreach (IPickable p in pickables)
        {
            if (p is IFood && (p as IFood).GetId().Equals(foodId))
            {
                return true;
            }
        }
        return false;
    }

    public List<IFood> EatFood(List<IFood> foodList){
        List<IFood> result = new List<IFood>();
        foreach(IFood food in foodList) {
            food.EatenBy(this);
            result.Add(food);
        }
        return result;
    }

    public string GetEaterId()
    {
        return ID;
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        LayerMask roomMask = LayerMask.GetMask("room");
        if (Physics.Raycast(ray, out hit, interactDistance, roomMask))
        {
            Debug.DrawRay(ray.origin, ray.direction * 2f, Color.red);

            IOpenable openable = hit.collider.GetComponent<IOpenable>();
            IPickable pickable = hit.collider.GetComponent<IPickable>();
            ICatalog catalog = hit.collider.GetComponent<ICatalog>();
            IFood food = hit.collider.GetComponent<IFood>();
            IEater eater = hit.collider.GetComponent<IEater>();
            IDentifiable dentifiable = hit.collider.GetComponent<IDentifiable>();


            if (catalog != null)
            {
                catalog.ShowCatalog(this);
            }
            else
            {
                CatalogUtil.ClearCatalog();
            }

            if (openable != null)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    Debug.Log("Trying to open");
                    openable.OpenOrClose(this);
                }
            }

            if (food != null)
            {
                if (Input.GetKeyDown(KeyCode.Space) && food.IsFor(this))
                {
                    if (food.GetHolder() == this as IHolder)
                    {
                        this.energy += food.GetEnergy();
                        Debug.Log("energy is " + energy);
                        food.EatenBy(this);
                        this.RemoveFood(food);
                    }
                }
            }

            //for the bird
            if (eater != null)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    List<IFood> eaten = eater.EatFood(GetFoodList());
                    pickables.RemoveAll(p => (p is IFood) && eaten.Contains(p as IFood));
                }

            }

            if (pickables.Count == 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (pickable!=null && pickable.EnergyRequired() <= energy)
                    {
                        pickable.PickUp(this);
                        //reduce energy
                        this.energy -= pickable.EnergyRequired();
                        Debug.Log($"Energy = {this.energy}");
                    }
                    else if (pickable != null &&  pickable.EnergyRequired() > energy)
                    {
                        CatalogUtil.ShowClueMessage("I cannot move this, it is too heavy for me. " +
                            "I am too weak to move this at the moment. \n\n press SPACE to close");
                        playerAudio.Play();
                    }
                }
            }

            else if (pickables.Count != 0)
            {
                if (pickable != null && Input.GetMouseButtonDown(0))
                {
                    pickable.PutDown(this);
                }

                if (dentifiable != null)
                {
                    Debug.Log(dentifiable.GetId());
                    if (dentifiable.GetId() == "bathtubWater"
                    && pickables.Exists(p => p.GetId() == "bucket"))
                    {
                        IFillable fillable = (pickables[0] as IFillable);
                        if (Input.GetMouseButtonDown(1))
                        {
                            fillable.Fill();
                            Debug.Log("fill water");
                        }
                    }

                    if (dentifiable.GetId() == "fire"
                    && pickables.Exists(p => p.GetId() == "bucket"))
                    {
                        Debug.Log("Esists");
                        IFillable fillable = (pickables[0] as IFillable);
                        if (Input.GetMouseButtonDown(1))
                        {
                            fillable.Throw();
                            Debug.Log("throw water");

                            openable.OpenOrClose(this);

                        }
                    }
                }

                
            }
 
        }
        else
        {
            CatalogUtil.ClearCatalog();
        }

        
    }


   
    public string GetId()
    {
        return ID;
    }

    public int GetEnergy()
    {
        return energy;
    }

    public void RemoveFood(IFood food)
    {
        pickables.Remove(food);
    }

    public override bool Equals(object value)
    {
        PlayerAction playerAction = value as PlayerAction;

        return (playerAction != null)
            && (this as IDentifiable).GetId().Equals((playerAction as IDentifiable).GetId());
    }

    public override int GetHashCode()
    {
        int hash = 13;
        hash = (hash * 7) + (this as IDentifiable).GetId().GetHashCode();
        return hash;
    }
}
