using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Login : BaseClass
{
   public Button login_btn,reg_btn;
    public TextMeshProUGUI username_edt, pass_edt;
    void Start()
    {
        login_btn.onClick.AddListener(loginButtonCall);
        reg_btn.onClick.AddListener(regButtonCall);

    }

    public void regButtonCall()
    {
        UiManager.instance.showNext(CanvasScreen.Registration);

       //if(username_edt.text == SaveManager.instance.playerData.userData.userId && pass_edt.text== SaveManager.instance.playerData.userData.password) {
       //     loginButtonCall();
       // }
       // else
       // {
       //     Debug.Log("UserName && passwprd incorrect");
       // }

    }

    public void loginButtonCall()
    {
        UiManager.instance.showNext(CanvasScreen.ContactData);
    }
}
