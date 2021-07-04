// FOr files on operating system
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    static string savePath = Application.persistentDataPath + "/player.data";
    public static void SaveData()
    {
        BinaryFormatter formatter = new BinaryFormatter();


        FileStream stream = new FileStream(savePath, FileMode.Create);

        UserData data = new UserData();

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static UserData LoadData() {
        if (File.Exists(savePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(savePath, FileMode.Open);

            UserData data = formatter.Deserialize(stream) as UserData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not saved");
            return null;
        }
    }
}
