using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayContacts : BaseClass
{
   public Button addContactBtn;

    

    public static DisplayContacts instance;

   

    void Start()
    {
        addContactBtn.onClick.AddListener(addContactdetail);

        instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


   


    public void addContactdetail()
    {
        UiManager.instance.showNext(CanvasScreen.ContactData);
    }
}
