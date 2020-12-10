using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_01 : MonoBehaviour, ICatalog, IEater
{
    private static Bird_01 Instance;

    public const string ID = "BIRD_01";

    AudioSource birdAudio;

    List<IFood> foodList = new List<IFood>();

    public AudioClip[] birdSound;

    public AudioSource playerAudio;

    bool playerSaid = false;

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }

    private void Start()
    {
       
        gameObject.SetActive(false);

        birdAudio = gameObject.GetComponent<AudioSource>();
        playerAudio = GetComponent<AudioSource>();
    }

    public static Bird_01 GetInstance()
    {
        return Instance;
    }

    public void Show()
    {
        gameObject.SetActive(true);
        gameObject.GetComponent<AudioSource>().Play();
    }

    void ICatalog.ShowCatalog(Object caller)
    {
        Debug.Log("bird cames");

        if (caller is IEater)
        {
            IEater eater = caller as IEater;

           bool hasFoodForMe = eater.GetFoodList().Exists(f => f.IsFor(this));

            if(hasFoodForMe)
            {
                CatalogUtil.ShowMessage("This bird looks really hungry! Let's find food for it. \n Feed : Mouse Right");
               
            }
            else if(foodList.Count == 0)
            {
                CatalogUtil.ShowMessage("This bird looks really hungry! Let's find food for it. \n Bird  -  You don't have food for me!");
                birdAudio.clip = birdSound[1];
                birdAudio.volume = 0.1f;
                birdAudio.Play();
            }
        }

       
    }


    public void ShowClue()
    {
        CatalogUtil.ShowClueMessage("Hmm... It's a beautiful melody. I remember somebody singing it when I was young. " +
            "Was that mother? No it couldn't be, she would never sing something so pretty to me.\n\npress SPACE to close");
        if (!playerSaid)
        {
            playerAudio.Play();
            playerSaid = true;
        }

        CountDownTimer.GetInstance().CountDown(2, () =>
        {
            gameObject.SetActive(false);
        });
    }

    //IEater
    public List<IFood> GetFoodList()
    {
        return foodList;
    }

    public bool CheckHasFood(string foodId)
    {
        foreach(IFood f in foodList)
        {
            if (f.GetId().Equals(foodId))
            {
                return true;
            }
        }

        return false;
    }

    public string GetEaterId()
    {
        return ID;
    }

    public List<IFood> EatFood(List<IFood> foodList)
    {
        List<IFood> result = new List<IFood>();
        foreach (IFood food in foodList)
        {

            if (food.IsFor(this))
            {

                this.foodList.Add(food);
                food.EatenBy(this);

                birdAudio.clip = birdSound[0];
                birdAudio.volume = 1f;
                birdAudio.Play();
                Invoke("ShowClue", birdAudio.clip.length);

                result.Add(food);
            }
        }

        return result;
    }

     void IEater.RemoveFood(IFood food)
    {
        foodList.Remove(food);
    }

    public override bool Equals(object value)
    {
        Bird_01 bird = value as Bird_01;

        return (bird != null)
            && (this.GetId().Equals(bird.GetId()));
    }

    public override int GetHashCode()
    {
        int hash = 13;
        hash = (hash * 7) + this.GetId().GetHashCode();
        return hash;
    }

    public string GetId()
    {
        return ID;
    }
}
