using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveData(PersistantData player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/UserScores.Score";
        FileStream stream = new FileStream(path, FileMode.Create);

        LevelData data = new LevelData(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static LevelData LoadData()
    {
        string path = Application.persistentDataPath + "/UserScores.Score";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            LevelData data = formatter.Deserialize(stream) as LevelData;
            stream.Close();
            return data;
            
        }
        else
        {
            Debug.Log("Save file not found in" + path);
            return null;
        }
    }
    public static bool CheckForFile()
    {
        string path = Application.persistentDataPath + "/UserScores.Score";
        if (File.Exists(path))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
