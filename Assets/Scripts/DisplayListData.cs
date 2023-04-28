using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DisplayListData : MonoBehaviour
{

   public  TextMeshProUGUI userNameTxt, mobileNoTxt;
    public Button callPersonBtn,ListBtbn;

    public static DisplayListData instance;
    public string username, mobileNo , email, address;
    public string em, add;
    
    void Start()
    {
        instance = this;
      //  SaveManager.instance.displayData(this);
       // callPersonBtn.onClick.AddListener(editContactData);
        ListBtbn.onClick.AddListener(editContactData);
        //userNameTxt.text = SaveManager.instance.name;
        //mobileNoTxt.text = SaveManager.instance.mobileNo;



    }

    public void editContactData()
    {

    
      
        SaveManager.instance.fatchData(userNameTxt.text);
        UiManager.instance.showNext(CanvasScreen.UpdateUserContacts);

        em = SaveManager.instance.email;
        address = SaveManager.instance.address;
        if (!(userNameTxt.text == null && mobileNoTxt.text == null && email == null && address == null))
            SaveManager.instance.displayContactData(userNameTxt.text, mobileNoTxt.text,em, address);


      
    }


   

}
