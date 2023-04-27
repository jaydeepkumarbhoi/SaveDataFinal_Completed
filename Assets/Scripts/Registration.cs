using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Registration : BaseClass
{
    public TMP_InputField userId_edt, password_edt, fullName_edt, mobileNo_edt;

    public Button reg_btn;
    void Start()
    {
        reg_btn.onClick.AddListener(Registration_ButtonCall);
       // login_btn.onClick.AddListener(Login_ButtonCall);
    }


    public void Registration_ButtonCall()
    {
        UiManager.instance.showNext(CanvasScreen.Login);
        SaveManager.instance.registerAddData(this);

       
        StartCoroutine(clearData());
    }


   



IEnumerator clearData()
{
    yield return new WaitForSeconds(0.8f);
   
        userId_edt.text = "";
        password_edt.text = "";
        fullName_edt.text = "";
        mobileNo_edt.text = "";
    }

    //public void Login_ButtonCall()
    //{
    //    UiManager.instance.showNext(CanvasScreen.Registration);
    //}

}
