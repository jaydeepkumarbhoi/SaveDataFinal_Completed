using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayContacts : BaseClass
{
   public Button addContactBtn,closeBtn;

    

    public static DisplayContacts instance;

   

    void Start()
    {
        addContactBtn.onClick.AddListener(addContactdetail);
        closeBtn.onClick.AddListener(closeBtncall);
        instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

 public void closeBtncall()
    {
        UiManager.instance.showNext(CanvasScreen.Login);
    }

    public void addContactdetail()
    {
        UiManager.instance.showNext(CanvasScreen.ContactData);
    }
}
