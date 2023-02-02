using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerReady : MonoBehaviour
{
    public ParticleSystem starparticle, starparticle2, starparticle3, winparticle;
    MenuManager menu;
    public Rigidbody2D rigidb;
    public float playervel = 5;
    public GameObject player, WinMenu, StarON, StarON2, StarON3,StarOFF, StarOFF2, StarOFF3, pauseButton, star, star2, star3;
    public Text starText;
    public int starscollected = 0;
    public GameObject SoundManagerRef;

    //Scaling down stars variables----
    private Vector3 newScale = new Vector3(0.1f, 0.1f, 0.1f);
    private float time = 0.3f;
    //--------------------------------
    private bool BackTrack = false; 

    private bool started = false;

    private void Start()
    {
        menu = GetComponent<MenuManager>();
        
    }
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            DropButton();
            //if (started == false)
            //{

            //    rigidb.velocity = new Vector3(0, -50, 0);
            //    started = true;
            //}
            

        }

        if(Input.GetKeyDown("left ctrl"))
        {
            RestartingGame();
        }
        if (rigidb.velocity.x < 0) { BackTrack = true; }
    }
    public void DropButton()
    {
        rigidb.bodyType = RigidbodyType2D.Dynamic;
        print("asdadasd");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Star")
        {
            if(collision.gameObject == star)
            {
                starparticle.Play();
            }
            if (collision.gameObject == star2)
            {
                starparticle2.Play();
            }
            if (collision.gameObject == star3)
            {
                starparticle3.Play();
            }
            SoundManagerRef.GetComponent<SoundManager>().PlayStarSound();
            print("ball hit star");
            starscollected++;
            starText.text = starscollected.ToString();
            StartCoroutine(ScaleOverTime(collision.gameObject, newScale, time));
           
            
            print("particle");
           
        }
        if (collision.tag == "Bin")
        {
            print("ball hit bin");
            //FindObjectOfType<Wincon>().gameFinished();
            SoundManagerRef.GetComponent<SoundManager>().PlayWinSound();
            SoundManagerRef.GetComponent<SoundManager>().PlayConfettiSound();
            winparticle.Play();                    
            WinMenu.SetActive(true);
            pauseButton.SetActive(false);
            if (starscollected == 0) {StarON.SetActive(false); StarON2.SetActive(false); StarON3.SetActive(false); StarOFF.SetActive(true); StarOFF2.SetActive(true); StarOFF3.SetActive(true);} //no stars collected
            if (starscollected == 1) {StarON.SetActive(true); StarON2.SetActive(false); StarON3.SetActive(false); StarOFF.SetActive(false); StarOFF2.SetActive(true); StarOFF3.SetActive(true);}  
            if (starscollected == 2) {StarON.SetActive(true); StarON2.SetActive(true); StarON3.SetActive(false); StarOFF.SetActive(false); StarOFF2.SetActive(false); StarOFF3.SetActive(true);}  
            if (starscollected == 3) {StarON.SetActive(true); StarON2.SetActive(true); StarON3.SetActive(true); StarOFF.SetActive(false); StarOFF2.SetActive(false); StarOFF3.SetActive(false);}
            
        }
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Line(Clone)" && rigidb.velocity.y < 0 && BackTrack == false)
        {
            print(rigidb.velocity);
            rigidb.velocity = rigidb.velocity * 1.2f;
        }
        if (collision.collider.name == "Bucket")
        {
            print("bukeeet");
        }
    }

    public void RestartingGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void NextLevelPressesd()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PersistantData.Instance.UpdateLevelScores(starscollected);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        PersistantData.Instance.UpdateLevelScores(starscollected);
    }
    public IEnumerator ScaleOverTime(GameObject ObjectRef, Vector3 newScale, float time)
    {
        float elapsedTime = 0;
        Vector3 currentSize = ObjectRef.transform.localScale;
        while (elapsedTime < time)
        {
            ObjectRef.transform.localScale = Vector3.Lerp(currentSize, newScale, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        Destroy(ObjectRef);
        //ObjectRef.transform.position = newScale;
    }

}
