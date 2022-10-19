using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyUI : MonoBehaviour
{
    bool isOn = true;
    string[] animalTotem = new string[] {
        "turtle",
        "eagle",
        "bear",
        "wolf",
        "deer"
        };
    Dictionary<string,animalUI> totemUI=new Dictionary<string,animalUI>();  
    private void OnMouseDown()
    {
        pentatonicMode.ScaleType = !pentatonicMode.ScaleType;
        if (isOn)
        {
            gameObject.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
            isOn = false;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            isOn = true;
        }
       foreach(var name in totemUI.Keys)
        {
            totemUI[name].animalObjects.ForEach(Destroy);
            totemUI[name].animalObjects.Clear();
        }
    }
    private void Start()
    {
        foreach(var name in animalTotem)
        {
            totemUI[name] = GameObject.Find(name).GetComponent<animalUI>();
        }
    }
}
