using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineManager : MonoBehaviour
{
  
    public int currentpoints;
    public int pointsadded;
    public int totalpointsavailable = 60;
    public int lineValueUI;
    public Button drop;
    public Text LineAvailableUI;

    public GameObject linepref; //getting the reference to the line gameobject
    LineScript CurrentLine;    //getting the reference to the lineScript

    public LineRemainingUIScript LineBar;

    public bool IsGamePaused;
    public GameObject pauseMenu;

    private void Start()
    {
        LineBar.SetMaxInkUI(totalpointsavailable);        
    }
    void Update()
    {
        if (IsGamePaused == false)
        {
            if (currentpoints < totalpointsavailable)
            {
                if (Input.GetMouseButtonDown(0)) //(Input.GetTouch(0).phase == TouchPhase.Moved && Input.touchCount > 0) ||  //Drawing the line while the left button is pressed
                {
                    GameObject lineGameObject = Instantiate(linepref);
                    CurrentLine = lineGameObject.GetComponent<LineScript>();
                }

                if (Input.GetMouseButton(0))
                {
                    Vector2 mousepo = Camera.main.ScreenToWorldPoint(Input.mousePosition); //getting the currernt world point we use the camera.main.screentoworldpoint to convert the screen (pixel) coordinates into world coordinates
                    CurrentLine.UpdateLine(mousepo); //passing the world point to the lineScript function to add it to the list
                }
            }

            if (currentpoints >= totalpointsavailable)
            {
                //print("no more ink available");
            }
        }
        
    }

    public void IncreasePoints()
    {
        currentpoints++;
        LineBar.SetInk(totalpointsavailable -currentpoints);
        SetLineRemainValueUI(currentpoints);
        print("Total points created: " + currentpoints.ToString());
    }
    public void SetLineRemainValueUI(int currentpoints)
    {
        lineValueUI = (currentpoints * 100) / totalpointsavailable;
        lineValueUI = 100 - lineValueUI;
        LineAvailableUI.text = lineValueUI.ToString();
    }

    public void PauseGame()
    {
        IsGamePaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        IsGamePaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}

