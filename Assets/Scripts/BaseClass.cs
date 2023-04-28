using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CanvasScreen
{
    Registration,
    Login,
    ContactData,
    DisplayContacts,
    UpdateUserContacts

}

public class BaseClass : MonoBehaviour
{
   
    [HideInInspector]
     public Canvas newCanvas;


   

    private void Awake()
    {
        newCanvas = GetComponent<Canvas>(); 
    }

  
    public void  showScreen()
    {

        newCanvas.enabled = true;
    }

    public void hideScreen()
    {

        newCanvas.enabled = false;
    }

    
}
