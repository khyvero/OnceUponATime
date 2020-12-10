using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class CatalogUtil 
{
   
    
    public static void ShowMessage(String message){
        ObjectFactory.get().GetMsgBk().SetActive(true);
        ObjectFactory.get().GetMsg().text = message;
    }

    public static void AppendMessage(String message){
        ObjectFactory.get().GetMsgBk().SetActive(true);
        ObjectFactory.get().GetMsg().GetComponent<TextMeshProUGUI>().text += "\n";
        ObjectFactory.get().GetMsg().GetComponent<TextMeshProUGUI>().text += message;
    }

    public static void HideCatalog(){
        ObjectFactory.get().GetMsg().GetComponent<TextMeshProUGUI>().text = "";
        ObjectFactory.get().GetMsgBk().SetActive(false);        
    }

    public static void ShowCatalog(){
        ObjectFactory.get().GetMsgBk().SetActive(true);
        //ObjectFactory.get().GetMsg().SetActive(true);
    }

    public static void ClearCatalog(){
        ObjectFactory.get().GetMsgBk().SetActive(false);
        ObjectFactory.get().GetMsg().text = "";
    }

    public static void ShowClueMessage(String clueMessage){
        ObjectFactory.get().GetClueMsg().GetComponent<TextMeshProUGUI>().text = "";
        ObjectFactory.get().GetClueMsgBk().SetActive(true);
        ObjectFactory.get().GetClueMsg().GetComponent<TextMeshProUGUI>().text = clueMessage;
    }

    public static void HideClue(){
        ObjectFactory.get().GetClueMsg().GetComponent<TextMeshProUGUI>().text = "";
        ObjectFactory.get().GetClueMsgBk().SetActive(false);        
    }


    ////Esc Message
    //public static void CloseEscMassage()
    //{
    //    GameObject esc = ObjectFactory.get().GetEscMessage();
    //    if (esc != null)
    //    {
    //        esc.SetActive(false);
    //        Debug.Log("closeEscMessage");

    //    }
    //}
    //public static void OpenEscMassage()
    //{
    //    GameObject esc = ObjectFactory.get().GetEscMessage();
    //    if (esc != null)
    //    {
    //        ObjectFactory.get().GetEscMessage().SetActive(true);
    //        Debug.Log("OpenEscMessage");
    //    }
    //}
}
