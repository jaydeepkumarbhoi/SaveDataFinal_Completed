using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveManager : MonoBehaviour
{

    public static SaveManager instance;
    
    public  PlayerData playerData;

    public UserData userDataCall;

    private static string filePath;

    public GameObject displayPrefab,gameObjParent;


    UserData getUserIDCall; 
    private void Awake()
    {
        filePath = Application.dataPath + "/jsonDataSave.json";
        LoadPlayer();
        instance = this;

     //   getUserIDCall= playerData.userList.Find(UserData => UserData.userId == Login.instance.username_edt.text);
    }

    public void registerAddData(Registration registration) {

        UserData udata = new UserData();
       
        udata.userId = registration.userId_edt.text;
        udata.password = registration.password_edt.text;
        udata.fullName = registration.fullName_edt.text;
        udata.mobileNo = registration.mobileNo_edt.text;
        udata.contactInfoobj = new ContactDataCall();
        playerData.userList.Add(udata);

        savePlayer();
    }



    public void contactAddData(ContactData con)
    {
       
        ContactInfo conInfo = new ContactInfo();
        
        conInfo.name = con.userName_edt.text;
        conInfo.mobileNo = con.mobileNo_edt.text;
        conInfo.address = con.address_edt.text;
        conInfo.emailId = con.email_edt.text;

        UserData getUserID = playerData.userList.Find(UserData => UserData.userId == Login.instance.username_edt.text);

        Debug.Log("Hello.." + PlayerPrefs.GetString("userId"));
        Debug.Log("Hi.."+getUserID);

        if (getUserID != null)
        {
            getUserID.contactInfoobj.contactList.Add(conInfo);
        }

        savePlayer();
    }


    public void validateLogin(Login login)
    {
        UserData getUserID = playerData.userList.Find(UserData => UserData.userId == login.username_edt.text);
        //UserData getUserPass = playerData.userList.Find(UserData => UserData.password == login.pass_edt.text);
       
        if (getUserID.userId == login.username_edt.text && getUserID.password == login.pass_edt.text)
        {
            UiManager.instance.showNext(CanvasScreen.DisplayContacts);
          //  playerData.userList.Count();
            PlayerPrefs.SetString("userID", getUserID.ToString());
            displayData( getUserID.contactInfoobj.contactList.Count);
        }
        else
        {
            Debug.Log("Username and Password Inccorret");
        }

    }

    public void displayData(int count)
    {
        for(int i = 0; i <= count; i++)
        {
            Instantiate(displayPrefab,displayPrefab.transform.position,Quaternion.identity, gameObjParent.transform);
        }
    }


    public  void savePlayer()
    {
        //    BinaryFormatter formetor = new BinaryFormatter();
        //    string filePath = Application.persistentDataPath + "/SaveDataManagerTask.jd";
        //    FileStream fstream = new FileStream(filePath, FileMode.Create);
        //    formetor.Serialize(fstream, playerData);
        //    fstream.Close();


        string jsonData = JsonUtility.ToJson(playerData);
        File.WriteAllText(filePath, jsonData);

    }

    public void LoadPlayer()
    {
        string  path = Application.persistentDataPath + "/jsonDataSave.json";

        if (File.Exists(filePath))
        {

            string jsonData = File.ReadAllText(filePath);
            playerData = JsonUtility.FromJson<PlayerData>(jsonData);
        }
        else
        {
            Debug.Log("No file are there");
        }


        //if (File.Exists(path))
        //{
        //    BinaryFormatter formatter = new BinaryFormatter();
        //    FileStream fileStream = new FileStream(path, FileMode.Open);

        //    playerData = formatter.Deserialize(fileStream) as PlayerData;

        //    fileStream.Close();


        //}
        //else
        //{
        //    Debug.Log("********* File Not Exists ************");
        //    playerData.userData = new UserData();
        //    playerData.contacts = new List<ContactInfo>();
        //}
    }


}


[System.Serializable]
public  class PlayerData
{
    public List<UserData> userList = new List<UserData>();


}

[System.Serializable]
public class UserData
{
    public string userId;
    public string password;
    public string fullName;
    public string mobileNo;
    public ContactDataCall contactInfoobj = new ContactDataCall();
}

[System.Serializable]
public class ContactDataCall
{
    public List<ContactInfo> contactList = new List<ContactInfo>();
}


[System.Serializable]
public class ContactInfo
{
    public string name;
    public string mobileNo;
    public string address;
    public string emailId;

}

