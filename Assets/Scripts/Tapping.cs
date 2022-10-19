using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tapping : MonoBehaviour
{
    Fretboard fretboard;
    private void Start()
    {
        fretboard = GameObject.Find("GameBoard").GetComponent<Fretboard>(); 
    }
    private void OnBecameInvisible()
    {
        fretboard.noteList.Remove(gameObject);
        Destroy(gameObject);
        Debug.Log("destroying");
    }
}
