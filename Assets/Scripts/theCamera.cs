using System.Collections;
//using UnityEditor.Tilemaps;
//using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class theCamera : MonoBehaviour
{
    [SerializeField] public int cameraOffset    =   10;
    [SerializeField] public int cameraScale = 5;
    private Rect screenRect = Rect.zero;
    GameObject bird;
   // Renderer[] birds;

    Camera myCamera;
    Vector3 worldPosition;
    private void Start()
    {
        myCamera = Camera.main;
        bird = GameObject.Find("bird");
        //birds = gameObject.GetComponentsInChildren<Renderer>();
        hideBird();
    }

    private void Update()
    {
        screenRect = new Rect(0f, 0f, Screen.width, Screen.height);

        if (screenRect.Contains(Input.mousePosition))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = myCamera.nearClipPlane;
            worldPosition = myCamera.ScreenToWorldPoint(mousePos);
            
            worldPosition.x = (worldPosition.x - cameraOffset)/cameraScale;
            worldPosition.y = (worldPosition.y  - cameraOffset)/cameraScale;
            worldPosition.z = -9f;
            //Debug.Log(worldPosition);
            myCamera.transform.position = worldPosition;
        }
          
    }
    private void OnEnable()
    {
        pentatonicMode.birdStart += showBird;
        pentatonicMode.birdEnd += hideBird;
    }
    private void OnDisable()
    {
        pentatonicMode.birdStart -= showBird;
        pentatonicMode.birdEnd -= hideBird;
    }


    void showBird() {
       
            bird.gameObject.SetActive(true);
            var birdFlight = bird.transform.position;
            bird.transform.position = new Vector3(birdFlight.x, birdFlight.y, pentatonicMode.rungHeight[pentatonicMode.ScaleName] + -1);
        
        /*foreach (var bird in birds) { 
        
            bird.gameObject.SetActive(true);
        
        }*/
    }
    void hideBird()
    {
        bird.gameObject.SetActive(false);
      /*  foreach (Renderer t in birds)
        {

            t.gameObject.SetActive(false);
        }*/
    }
}
