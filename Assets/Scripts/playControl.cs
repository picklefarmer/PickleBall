using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playControl : MonoBehaviour
{

    private void OnMouseDown()
    {
        pentatonicMode.isPlaying = !pentatonicMode.isPlaying;
       
        //Debug.Log("clicked"+pentatonicMode.isPlaying);
    }
}
