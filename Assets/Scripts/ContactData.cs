using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ContactData : BaseClass 
{
    public TMP_InputField userName_edt, address_edt, email_edt, mobileNo_edt;

    public Button submitBtn;

    

    public void editContactData()
    {
        UiManager.instance.showNext(CanvasScreen.Login);
        SaveManager.instance.contactAddData(this);
    }
}
