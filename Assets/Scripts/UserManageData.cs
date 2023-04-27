using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class UserManageData 
{
   public string userId, password, fullname, mobileNo;

    public UserManageData(Registration user) {

        userId = user.userId_edt.text;
        password = user.password_edt.text;
        fullname = user.fullName_edt.text;
        mobileNo = user.mobileNo_edt.text;

    }

}
