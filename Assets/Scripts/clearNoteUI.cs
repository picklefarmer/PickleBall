using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearNoteUI : MonoBehaviour
{
    Fretboard fretboard;
    GameObject strings;
    Material material;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        fretboard.noteList.ForEach(Destroy);
        var stringList = strings.GetComponentsInChildren<Renderer>();
        foreach (var item in stringList)
        {
            item.material = material;
        }
        fretboard.noteList.Clear();

    }
    void Start()
    {
        material = (Material)Resources.Load("Materials/Aspect");
        fretboard = GameObject.Find("GameBoard").GetComponent<Fretboard>();
        strings = GameObject.Find("stringsUI");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
