using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayContacts : BaseClass
{
   public Button addContactBtn;

    public GameObject contentPrefab;
    void Start()
    {
        addContactBtn.onClick.AddListener(addContactdetail);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addContactdetail()
    {
        UiManager.instance.showNext(CanvasScreen.ContactData);

        PlayerPrefs.GetString("userID");
    

       // SaveManager.instance.userDataCall.
    }
}
