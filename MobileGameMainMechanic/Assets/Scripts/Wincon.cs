using UnityEngine;
using UnityEngine.SceneManagement;

public class Wincon : MonoBehaviour
{
    public float waitTime = 5f;
    bool gameEnded = false;
   public void gameFinished()
   {
        if (gameEnded == false)
        {
            gameEnded = true;
            Debug.Log("gameOver");
            Invoke("Reset", waitTime);
        }
   }
    void Reset()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
