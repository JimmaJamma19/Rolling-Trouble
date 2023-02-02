using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class LevelData
{
    //public int[] LevelScores;
    //public int[] StarsCollected;
    public int totalScore;
    public int[] LevelScores;

    public LevelData(PersistantData player)
    {   
        LevelScores = new int[SceneManager.sceneCountInBuildSettings - 1];
        //Debug.Log("New array created");
        LevelScores = player.LevelScores;
        totalScore = player.TotalLevelScores;
        //Debug.Log("Numbers added to the existing array");
        
    }
    
}
