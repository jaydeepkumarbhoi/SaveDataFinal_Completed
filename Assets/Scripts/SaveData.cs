using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public static class SaveData
{

   // List<Registration> playerData = new List<Registration>();

    public static void savePlayer(Registration player)
    {
        BinaryFormatter formetor = new BinaryFormatter();
        string filePath = Application.persistentDataPath + "/SaveDataTask.jd";
        FileStream fstream = new FileStream(filePath, FileMode.Create);

         UserManageData pdata = new UserManageData(player);

        formetor.Serialize(fstream, pdata);

        fstream.Close();

    }

    public static UserManageData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/SaveDataTask.jd";


        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            UserManageData pdata = formatter.Deserialize(fileStream) as UserManageData;

            fileStream.Close();

           
            return pdata;
        }
        else
        {
            return null;
        }
    }
}
