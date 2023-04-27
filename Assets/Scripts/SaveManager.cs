using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveManager : MonoBehaviour
{

    public static SaveManager instance;
   public  PlayerData playerData = new PlayerData();
    string filePath = "/jsonDataSave.json";
    private void Awake()
    {
        instance = this;


        if (File.Exists(filePath))
        {

            string jsonData = File.ReadAllText(Application.dataPath + filePath);
            playerData = JsonUtility.FromJson<PlayerData>(jsonData);
        }
        else
        {
            Debug.Log("No file are there");
        }


        
    }

    public void registerAddData(Registration registration) {

        UserData udata = new UserData();
        udata.userId = registration.userId_edt.text;
        udata.password = registration.userId_edt.text;
        udata.fullName = registration.userId_edt.text;
        udata.mobileNo = registration.userId_edt.text;

        //playerData.userData.userId = registration.userId_edt.text;
        //playerData.userData.password = registration.password_edt.text;
        //playerData.userData.fullName = registration.fullName_edt.text;
        //playerData.userData.mobileNo = registration.mobileNo_edt.text;

        playerData.userData.Add(udata);

        savePlayer();
    }



    public void contactAddData(ContactData con)
    {
        ContactInfo conInfo = new ContactInfo();
        UserData udata = new UserData();
        conInfo.name = con.userName_edt.text;
        conInfo.mobileNo = con.address_edt.text;
        conInfo.address = con.email_edt.text;
        conInfo.emailId = con.mobileNo_edt.text;

        // playerData.contacts.Add(conInfo);

      // List<UserData> obj= new List<UserData>();

     //   playerData.userData.AddRange();
        savePlayer();
    }


    public  void savePlayer()
    {
        //    BinaryFormatter formetor = new BinaryFormatter();
        //    string filePath = Application.persistentDataPath + "/SaveDataManagerTask.jd";
        //    FileStream fstream = new FileStream(filePath, FileMode.Create);
        //    formetor.Serialize(fstream, playerData);
        //    fstream.Close();


        string jsonData = JsonUtility.ToJson(playerData);
        File.WriteAllText(Application.dataPath + filePath, jsonData);

    }

    public  void LoadPlayer()
    {
        string path = Application.persistentDataPath + filePath;

        if (File.Exists(path))
        {

          
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
public class PlayerData{

   //public UserData userData = new UserData();
    public List<UserData> userData = new List<UserData>();
}

[System.Serializable]
public class UserData
{
    public string userId;
    public string password;
    public string fullName;
    public string mobileNo;
    public List<ContactInfo> contacts = new List<ContactInfo>();
}

[System.Serializable]
public class ContactInfo
{
    public string name;
    public string mobileNo;
    public string address;
    public string emailId;
}
