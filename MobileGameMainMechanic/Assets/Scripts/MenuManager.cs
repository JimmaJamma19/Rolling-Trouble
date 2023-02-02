using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject Panel, InfoPanel;    
    private bool isMuted;
    public int totalStarsCollected;
    public Text TotalStarsUI;
    public GameObject MainMenu;
    public GameObject LevelMenu;
    private float time = 0.3f;
    private int i;
    //private int TotalStarsCount
    void Start()
    {
        Time.timeScale = 1f; //this is needed because Im pausing the game in every level.

        isMuted = PlayerPrefs.GetInt("MUTED") == 1;
        isMuted = false;

        if (SaveSystem.CheckForFile())
        {
            LevelData data = SaveSystem.LoadData();
            PersistantData.Instance.LoadData();
            if (data != null) { TotalStarsUI.text = data.totalScore.ToString(); }
        }
        else
        {
            PersistantData.Instance.NewFile();
        }




        /*
        if (returned == true)
        {
            LevelData data = SaveSystem.LoadData();
            TotalStarsUI.text = data.totalScore.ToString();
        }
        */
        /*
        if (data.LevelScores != null)
        {
            for (int i = 0; i < data.LevelScores.Length; i++)
            {
                totalStarsCollected += data.LevelScores[i];
                print(data.LevelScores[i].ToString());
            }
            TotalStarsUI.text = totalStarsCollected.ToString();
        }
        */
    }
    public void settings()
    {
        StartCoroutine(CountdownForPlayandLevelButtons(time, i = 7));
    }
    public void InfoPanelButton()
    {
        StartCoroutine(CountdownForPlayandLevelButtons(time, i = 8));
    }
    public void PlayButton()
    {
        StartCoroutine(CountdownForPlayandLevelButtons(time, i = 0));
    }
    public void MusicButton()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
        PlayerPrefs.SetInt("MUTED", isMuted ? 1 : 0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Loadlevel1()
    {
        StartCoroutine(CountdownForPlayandLevelButtons(time, i = 1));
    }
    public void Loadlevel2()
    {
        StartCoroutine(CountdownForPlayandLevelButtons(time, i = 2));
    }
    public void Loadlevel3()
    {
        StartCoroutine(CountdownForPlayandLevelButtons(time, i = 3));
    }
    public void Loadlevel4()
    {
        StartCoroutine(CountdownForPlayandLevelButtons(time, i = 4));
    }
    public void Loadlevel5()
    {
        StartCoroutine(CountdownForPlayandLevelButtons(time, i = 5));
    }
    public void Loadlevel6()
    {
        StartCoroutine(CountdownForPlayandLevelButtons(time, i = 6));
    }
    public void openlevelmenu()
    {
        StartCoroutine(Countdown(MainMenu, LevelMenu, time, i = 0));
    }
    public void GoBackMainMenu()
    {
        StartCoroutine(Countdown(MainMenu, LevelMenu, time, i = 1));
    }
    public IEnumerator Countdown(GameObject MainMenuRef, GameObject LevelMenuRef, float time, int i)
    {
        float elapsedTime = 0;
        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        if (i == 0)
        {
            LevelMenuRef.SetActive(true);
            MainMenuRef.SetActive(false);
        }
        else if (i == 1)
        {
            LevelMenuRef.SetActive(false);
            MainMenuRef.SetActive(true);
        }

    }
    public IEnumerator CountdownForPlayandLevelButtons(float time, int i)
    {
        float elapsedTime = 0;
        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        if (i == 0) // play button 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (i == 1)//loading level 1
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (i == 2)//loading level 2
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
        else if (i == 3)//loading level 3
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        }
        else if (i == 4)//loading level 4
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
        }
        else if (i == 5)//loading level 5
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
        }
        else if (i == 6)//loading level 6
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 6);
        }
        else if (i == 7)//setting button
        {
            Panel.GetComponent<Animator>().SetTrigger("Pop");
        }
        else if ( i == 8 )
        {
            InfoPanel.GetComponent<Animator>().SetTrigger("InfoPanelPop");
        }

    }
}
