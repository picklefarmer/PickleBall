using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureManager : MonoBehaviour
{
  
    bool isSingle = true;
    Quaternion rotation;
    public animalUI animalInterface;
    public animalUI aui;
    GameObject cylinder;
    public int colorValue;
    Fretboard Fretboard;
    
    // Start is called before the first frame update
    void Start()
    {
        rotation = transform.localRotation;
        //Instantiate(figureObject, startLocation, Quaternion.identity);
        // connectorObject = GameObject.Find(gamePieceManager).gameObject;

        animalInterface = FindObjectOfType<animalUI>();

       
        Fretboard = FindObjectOfType<Fretboard>();
        
        
    }
    private void OnMouseDown()
    {
        
        //var arr = animalInterface.animalObjects;
        
        var zAmount = pentatonicMode.rungHeight[pentatonicMode.ScaleName]+pentatonicMode.totemHeight[gameObject.name];
        Color paint = Fretboard.colorArray[colorValue];
        Debug.Log(paint + "sent color reference");
        //animalInterface.startLocation = transform.position;
        if(zAmount == 0)
        {

            gameObject.transform.DOMoveZ(-zAmount + 1, 1f).OnComplete(() => gameObject.transform.DOMoveZ(zAmount, 1f).OnComplete(() =>
            {
                animalInterface.sendPiece(transform.position, Fretboard.colorArray[colorValue]);
            }));
        }
        else
        {
            gameObject.transform.DOMoveZ(-zAmount, 1f).OnComplete(() => gameObject.transform.DOMoveZ(zAmount, 1f).OnComplete(() =>
            {

                animalInterface.sendPiece(transform.position, Fretboard.colorArray[colorValue]);
            }));
        }
    }
    // Update is called once per frame
    private void OnMouseEnter()
    {
        if (isSingle)
        {
            
            //gameObject.transform.DORotate(new Vector3(-90,-90,0),1);
            gameObject.transform.DOLocalRotate(new Vector3(-90, -90, 0), 1).OnComplete(() =>
            {

          //      animalInterface.animalObjects.ForEach(toggleVisible);
            //    gameObject.SetActive(true);

            });
           
            //isSingle = false;
        }
    }
    private void OnMouseExit()
    {
       
        
        //gameObject.transform.DORotate(new Vector3(0, 180, 90), 1);
        gameObject.transform.DORotateQuaternion(rotation, 1).OnComplete( ()=> {
        //    animalInterface.animalObjects.ForEach(toggleVisible);
         //   gameObject.SetActive(true);
        });
        //isSingle = true;

    }
    void toggleVisible(GameObject obj)
    {
        if (obj.activeSelf == false)
        {
            obj.SetActive(true);
        }
        else
        {
            obj.SetActive(false);
        }
    }
}
