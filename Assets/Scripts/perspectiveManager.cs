using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perspectiveManager : MonoBehaviour
{
    Camera mainCamera;
    bool isPerpective;
    //float leanAmount = 0f;
    Quaternion birdseye =  Quaternion.Euler(0f, 0f, 0f);
    Quaternion perspective= Quaternion.Euler(-22f, 0f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    private void OnMouseDown()
    {
        if (isPerpective)
        {
            mainCamera.transform.rotation = birdseye; 
         
        }
        else
        {
            mainCamera.transform.rotation = perspective;

        }
        isPerpective = !isPerpective;
    }
}
