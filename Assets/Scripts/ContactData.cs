using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ContactData : BaseClass 
{
    public TMP_InputField userName_edt, address_edt, email_edt, mobileNo_edt;

    public Button submitBtn;

    private void Start()
    {
        submitBtn.onClick.AddListener(addContacts);
    }

    public void addContacts()
    {
        SaveManager.instance.DisplaySingleList(userName_edt.text,mobileNo_edt.text);
        UiManager.instance.showNext(CanvasScreen.DisplayContacts);
        SaveManager.instance.contactAddData(this);
    }
}
