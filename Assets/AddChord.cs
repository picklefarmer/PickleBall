using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AddChord : MonoBehaviour
{
    Fretboard fretboard;
    void Start()
    {
        fretboard = GameObject.Find("GameBoard").GetComponent<Fretboard>();
    }
    private void OnMouseDown()
    {
        if (fretboard.noteList != null)
        {
            createChord();
            fretboard.noteList.Clear();
        }
    }

    void createChord()
    {
        GameObject first = new GameObject();
        foreach(GameObject note in fretboard.noteList.ToList()){
            note.transform.parent = first.transform;
            
        }
        pentatonicMode.chords.Add(first);
        pentatonicMode.chords[pentatonicMode.chords.Count-1].SetActive(false);
    }
}
