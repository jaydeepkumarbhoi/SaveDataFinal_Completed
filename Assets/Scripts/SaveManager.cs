using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using TMPro;

public class SaveManager : MonoBehaviour
{

    public static SaveManager instance;
    
    public  PlayerData playerData;

    
    private static string filePath;

    public GameObject displayPrefab, gameObjParent;

    public  string userName, mobileNo;

    public int count;

    string tempName, filePath2;

    public TMP_InputField unmt, mnot, emailt, addresst;
    public string email, address;

    private void Awake()
    {
        filePath = Application.dataPath + "/jsonDataSave.json";
         filePath2 = Application.persistentDataPath + "/jsonDataSave.don";
        LoadPlayer();
        instance = this;
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

        UserData getUserID = playerData.userList.Find(UserData => UserData.userId == PlayerPrefs.GetString("userId"));

        Debug.Log("Hello.." + PlayerPrefs.GetString("userId"));
        Debug.Log("Hi.."+getUserID);

        if (getUserID != null)
        {
            getUserID.contactInfoobj.contactList.Add(conInfo);
        }
        else {

            Debug.Log("Not call");

        }


        savePlayer();
    }


    public void validateLogin(Login login)
    {
        UserData getUserID = playerData.userList.Find(UserData => UserData.userId == login.username_edt.text);
     //   UserData getUserPass = playerData.userList.Find(UserData => UserData.password == login.pass_edt.text);
       
        if (getUserID.userId == login.username_edt.text && getUserID.password == login.pass_edt.text)
        {
            UiManager.instance.showNext(CanvasScreen.DisplayContacts);
          //  playerData.userList.Count();
            PlayerPrefs.SetString("userID", getUserID.ToString());
            count = getUserID.contactInfoobj.contactList.Count;
            Debug.Log("count="+getUserID.contactInfoobj.contactList.Count);
        }
        else
        {
            Debug.Log("Username and Password Inccorret");
        }

    }

    public void DisplaySingleList(string unm,string mno)
    {
        GameObject listData = Instantiate(displayPrefab, displayPrefab.transform.position, Quaternion.identity, gameObjParent.transform);

        DisplayListData data = listData.GetComponent<DisplayListData>();


        data.userNameTxt.text = unm;
        data.mobileNoTxt.text = mno;
    }


    public void destroyListData()
    {
        GameObject[] listOb=GameObject.FindGameObjectsWithTag("Finish");

        for(int i = 0; i < listOb.Length; i++)
        {
            Destroy(listOb[i]);
        }
    }

    public void displayCall()
    {
        UserData getUserID = playerData.userList.Find(UserData => UserData.userId == PlayerPrefs.GetString("userId"));

        for (int i = 0; i < getUserID.contactInfoobj.contactList.Count; i++)
        {
            GameObject listData = Instantiate(displayPrefab, displayPrefab.transform.position, Quaternion.identity, gameObjParent.transform);
         
            DisplayListData data=  listData.GetComponent<DisplayListData>();

            data.userNameTxt.text = getUserID.contactInfoobj.contactList[i].name;
            data.mobileNoTxt.text = getUserID.contactInfoobj.contactList[i].mobileNo;

            email= getUserID.contactInfoobj.contactList[i].emailId;
            address= getUserID.contactInfoobj.contactList[i].address;
          
        }

    }

    public void  fatchData(string dataName)
    {
        tempName = dataName;
    }

    public void UpdateData()
    {
        UserData getUserID = playerData.userList.Find(UserData => UserData.userId == PlayerPrefs.GetString("userId"));
        int count = getUserID.contactInfoobj.contactList.Count;
        for (int i = 0; i < count; i++)
        {
            if (getUserID.contactInfoobj.contactList[i].name == tempName)
            {
                getUserID.contactInfoobj.contactList[i].name = UpdateUserContacts.instance.userName_edt.text;
                getUserID.contactInfoobj.contactList[i].mobileNo = UpdateUserContacts.instance.mobileNo_edt.text;
                getUserID.contactInfoobj.contactList[i].emailId = UpdateUserContacts.instance.email_edt.text;
                getUserID.contactInfoobj.contactList[i].address = UpdateUserContacts.instance.address_edt.text;

                Debug.Log(getUserID.contactInfoobj.contactList[i].name);
                Debug.Log(getUserID.contactInfoobj.contactList[i].mobileNo);
                Debug.Log(getUserID.contactInfoobj.contactList[i].emailId);
                Debug.Log(getUserID.contactInfoobj.contactList[i].address);
            }
        }
    }


   

    public  void savePlayer()
    {
        BinaryFormatter formetor = new BinaryFormatter();
       // string filePath = Application.persistentDataPath + "/SaveDataManagerTask.jd";
        FileStream fstream = new FileStream(filePath2, FileMode.Create);
        formetor.Serialize(fstream, playerData);
        fstream.Close();


        //string jsonData = JsonUtility.ToJson(playerData);
        //File.WriteAllText(filePath, jsonData);

    }


    public void displayContactData(string name, string mno, string add, string email)
    {

        unmt.text = name;
        mnot.text = mno;
        addresst.text = add;
        emailt.text = email;

    }


    public void LoadPlayer()
    {
       

        //if (File.Exists(filePath))
        //{

        //    string jsonData = File.ReadAllText(filePath);
        //    playerData = JsonUtility.FromJson<PlayerData>(jsonData);
        //}
        //else
        //{
        //    Debug.Log("No file are there");
        //}


        if (File.Exists(filePath2))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(filePath2, FileMode.Open);
            playerData = formatter.Deserialize(fileStream) as PlayerData;
            fileStream.Close();


        }
        else
        {
            Debug.Log("********* File Not Exists ************");
         
        }
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

