using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdUI : MonoBehaviour
{
    public static bool isBirdOn=false;
    private void OnMouseDown()
    {
        if (isBirdOn)
        {
            pentatonicMode.birdEnd?.Invoke();
            isBirdOn=false;
        }
        else
        {
            if (pentatonicMode.ScaleName != null)
            {
                pentatonicMode.birdStart?.Invoke();
                isBirdOn = true;
            }
        }
    }
    
}
