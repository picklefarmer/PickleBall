using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slidePentatonicUI : MonoBehaviour
{
    animalUI animal;
    public string animalName;
    public bool isLeft;

    void Start()
    {
        animal = GameObject.Find(animalName).GetComponent<animalUI>();
    }
    private void OnMouseDown()
    {
        if (isLeft)
        {
           //animal.offsetX -= 1;
            animal.slidePentatonic(false);
        }
        else
        {
            //animal.offsetX += 1;
            animal.slidePentatonic(true);
        }
       
    }
}
