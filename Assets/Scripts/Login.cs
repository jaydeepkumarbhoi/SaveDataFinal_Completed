using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Login : BaseClass
{
   public Button login_btn,reg_btn;
    public TMP_InputField username_edt, pass_edt;

    public static Login instance;
    void Start()
    {
        login_btn.onClick.AddListener(loginButtonCall);
        reg_btn.onClick.AddListener(regButtonCall);
        instance = this;

    }

    public void regButtonCall()
    {
        UiManager.instance.showNext(CanvasScreen.Registration);
      
    }

    public void loginButtonCall()
    {

        SaveManager.instance.validateLogin(this);

        StartCoroutine(clearData());
        
    }

    IEnumerator  clearData()
    {
        yield return new WaitForSeconds(0.8f);
        username_edt.text = "";
        pass_edt.text = "";
    }
}
