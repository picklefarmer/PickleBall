using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayChord : MonoBehaviour
{
    // Start is called before the first frame update
    public int tempo = 5;
    int counter = 0;
    private void OnMouseDown()
    {
        playChord();
    }


    void playChord() {
        pentatonicMode.isChordPlay = true;
        StartCoroutine(Tempo());
    }


    IEnumerator  Tempo() {
        while (counter < pentatonicMode.chords.Count)
        {
            pentatonicMode.chords [counter].SetActive(true);
            
            yield return new WaitForSeconds(tempo);
            pentatonicMode.chords[counter].SetActive(false);
            counter++;
        }
        pentatonicMode.isChordPlay = false;
        counter = 0;
    }
}
