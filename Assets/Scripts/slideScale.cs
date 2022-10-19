using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;

using UnityEngine;


public class slideScale : MonoBehaviour
{
    Fretboard fretboard;
    
    public int isLeftUI;
    public void Start()
    {
        fretboard = GameObject.Find("GameBoard").GetComponent<Fretboard>();
        
    }

    // Start is called before the first frame update
    private void OnMouseDown()
    {
       
        var scale   = pentatonicMode.ScaleDrive[pentatonicMode.ScaleName];
        var notes = fretboard.ScaleSet[pentatonicMode.ScaleName];
        var flight = notes[0].transform.position.z;    
           
            for (var i = 0; i < scale.Count; i++)
            {
                int[] list = scale[i].ToArray();
                list = list.Skip(isLeftUI).Concat(list.Take(isLeftUI)).ToArray();
                scale.RemoveAt(i);
                scale.Insert(i, list);
            }

            notes.ForEach(Destroy);
            notes.Clear();
        
            fretboard.hand(scale, notes,flight);
        
    }
}
 