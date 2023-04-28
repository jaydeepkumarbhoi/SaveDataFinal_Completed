using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUserContacts : BaseClass
{
    public TMP_InputField userName_edt, address_edt, email_edt, mobileNo_edt;
    public Button editBtn,closeBtn;

    public static UpdateUserContacts instance;
    void Start()
    {
        
        editBtn.onClick.AddListener(EditUpdateContacts);
        closeBtn.onClick.AddListener(closeBtnCall);

        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void closeBtnCall()
    {
        UiManager.instance.showNext(CanvasScreen.DisplayContacts);
    }

    public void EditUpdateContacts()
    {
        SaveManager.instance.destroyListData();
        SaveManager.instance.UpdateData();
        SaveManager.instance.displayCall();
        UiManager.instance.showNext(CanvasScreen.DisplayContacts);
    }
}
