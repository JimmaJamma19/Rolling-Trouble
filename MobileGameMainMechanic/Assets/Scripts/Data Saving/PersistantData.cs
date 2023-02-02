using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistantData : MonoBehaviour
{
    public static PersistantData Instance;

    public int[] LevelScores;
    public int TotalLevelScores;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);

        

    }

    public void UpdateLevelScores(int StarsCollected)
    {
        if (StarsCollected > LevelScores[SceneManager.GetActiveScene().buildIndex - 1])
        {
            LevelScores[SceneManager.GetActiveScene().buildIndex - 1] = StarsCollected;
        }
        PersistantData.Instance.TotalLevelScores = 0;
        for (int i = 0; i < LevelScores.Length; i++)
        {
            Debug.Log(LevelScores[i]);
            TotalLevelScores += LevelScores[i];
            //LevelScores[i] = 0; //Used to reset the stored scores
        }
        SaveSystem.SaveData(this);
    }

    public void LoadData()
    {
        LevelData data = SaveSystem.LoadData();
        if (data.LevelScores != null)
        {
            LevelScores = data.LevelScores;
            for (int i = 0; i < data.LevelScores.Length; i++)
            {
                print(LevelScores[i]);
                
            }
            print("Loading the list of scores was successful");
        }
        else
        {
            LevelScores = new int[SceneManager.sceneCountInBuildSettings - 1];
        }
    }

    public void NewFile()
    {
        LevelScores = new int[SceneManager.sceneCountInBuildSettings - 1];
        TotalLevelScores = 0;
        for (int i = 0; i < LevelScores.Length; i++)
        {
            LevelScores[i] = 0;
        }
        SaveSystem.SaveData(this);
    }
}
