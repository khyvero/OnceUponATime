using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectFactory : MonoBehaviour
{
    public GameObject canvas;
    public GameObject msgBk;
    public TextMeshProUGUI msg;
    public GameObject clueMsgBk;
    public TextMeshProUGUI clueMsg;

    //public GameObject EscMessage;

    public static ObjectFactory Instance {get; private set;}

    void Awake(){
    
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

   public GameObject GetCanvas(){
        return canvas;
    }
   
   public GameObject GetMsgBk(){
        return msgBk;
    }

    public TextMeshProUGUI GetMsg(){
        return msg;
    }

    public GameObject GetClueMsgBk(){
        return clueMsgBk;
    }
    public TextMeshProUGUI GetClueMsg(){
        return clueMsg;
    }

    //public GameObject GetEscMessage()
    //{
    //    return EscMessage;
    //}

    public static ObjectFactory get(){
            return Instance;
    }


    
}
