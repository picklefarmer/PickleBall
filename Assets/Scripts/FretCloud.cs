using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FretCloud : MonoBehaviour
{
    GameObject game;
    Material Aspect;
    Material Glower;
    
    // Start is called before the first frame update
 
    void Start()
    {
        game = gameObject;
        Aspect = (Material)Resources.Load("Materials/Aspect", typeof(Material));
        Glower = (Material)Resources.Load("Materials/Glower", typeof(Material));
        game.GetComponent<Renderer>().material = Aspect;
    }
    private void OnMouseDown()
    {
        game.GetComponent<Renderer>().material = Glower;
    }
    private void OnMouseEnter()
    {
        game.GetComponent<Renderer>().material = Glower;
    }
    private void OnMouseExit()
    {
        game.GetComponent<Renderer>().material = Aspect;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
