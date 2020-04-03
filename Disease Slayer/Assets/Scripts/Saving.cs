using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class Saving
{
   public static void SavedSettings(Settings settings)
   {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/settings.exe";

        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(settings);

        formatter.Serialize(stream, data);
        stream.Close();
   }

    public static SaveData LoadData()
    {
        string path = Application.persistentDataPath + "/settings.exe";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
           SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Savefile not found in" + path);
            return null;
        }
    }
}
