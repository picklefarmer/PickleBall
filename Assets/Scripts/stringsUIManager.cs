using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stringsUIManager : MonoBehaviour
{

    Material initialMaterial;
    Renderer obj;
    private void OnEnable()
    {
        initialMaterial = GetComponentInChildren<Renderer>().material;
        pentatonicMode.strumString += onPluck;
    }
    private void OnDisable()
    {
        pentatonicMode.strumString-=onPluck;
        pentatonicMode.onNoteEnd -= pluckOff;
    }
    void onPluck(GameObject pick) {
        Material material = pick.GetComponentInChildren<Renderer>().material;
        switch (pick.transform.position.y)
        {
            case 0:pluck(5,material);break;
            case -1:pluck(4,material); break;
            case -2:pluck(3,material); break;
            case -3:pluck(2,material); break;
            case -4:pluck(1,material); break;
            case -5:pluck(0,material); break;  
                
        }
        Debug.Log(pick + "string position");
    }
    void pluck(int number,Material mat) {
        obj = gameObject.GetComponentsInChildren<Renderer>()[number];

        obj.material = mat;
        pentatonicMode.onNoteEnd += pluckOff;
    }

    void pluckOff() {

        obj.material = initialMaterial;
        
    }
}
