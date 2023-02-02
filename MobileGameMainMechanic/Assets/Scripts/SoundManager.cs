using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource buttonclick, winsound, starsound, confetti; //click sound
    public void PlayClickSound()
    {
        buttonclick.Play();

    }
    public void PlayWinSound()
    {
        winsound.Play();
    }
    public void PlayStarSound()
    {
        starsound.Play();
    }
    public void PlayConfettiSound()
    {
        confetti.Play();
    }
}
