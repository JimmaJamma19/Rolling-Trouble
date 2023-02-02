using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LineRemainingUIScript : MonoBehaviour
{
    public Slider slider;

   
    public void SetInk(int ink)
    {
        slider.value = ink;
    }
    public void SetMaxInkUI(int ink)
    {
        slider.maxValue = ink;
        slider.value = ink;
    }

}
