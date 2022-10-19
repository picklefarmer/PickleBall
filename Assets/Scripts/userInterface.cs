using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class userInterface : MonoBehaviour
{
    Fretboard fretboard;
    public string scaleName;
    stringsUIManager stringsUI;
    GameObject frets;
    GameObject bird;
    Vector3 flight;
    Vector3 fretFlight;
    Vector3 birdFlight;

   public Dictionary<string, List<GameObject>> ScaleLadder = new Dictionary<string, List<GameObject>>();
    // Start is called before the first frame update
    private void Start()
    {
        
        fretboard = GameObject.Find("GameBoard").GetComponent<Fretboard>();
        stringsUI = GameObject.Find("stringsUI").GetComponent<stringsUIManager>();
        //bird = GameObject.Find("bird");
        frets = GameObject.Find("Frets");
        ScaleLadder.Add("harmonicScale", fretboard.ScaleSet["harmonicScale"]);
        ScaleLadder.Add("melodicScale", fretboard.ScaleSet["melodicScale"]);
        ScaleLadder.Add("minorScale", fretboard.ScaleSet["minorScale"]);
        ScaleLadder.Add("majorScale", fretboard.ScaleSet["majorScale"]);
    }
    private void OnMouseDown()
    {

        string lastName = pentatonicMode.ScaleName;
        pentatonicMode.ScaleName = scaleName;
        flipVisible(scaleName,lastName);
        flight = stringsUI.transform.position;
        fretFlight = frets.transform.position;
        stringsUI.transform.position = new Vector3(flight.x, flight.y, pentatonicMode.rungHeight[scaleName]);
        frets.transform.position = new Vector3(fretFlight.x, fretFlight.y, pentatonicMode.rungHeight[scaleName] + -.5f);

       if (BirdUI.isBirdOn)
        {
            bird = GameObject.Find("bird");
           birdFlight = bird.transform.position;
            bird.transform.position = new Vector3(birdFlight.x, birdFlight.y, pentatonicMode.rungHeight[scaleName] + -1);

        }
        //Debug.Log(flight+scaleName);
        //fretboard.isVisible = !fretboard.isVisible;



        //Debug.Log("things are not wrong"+fretboard.scale.Count);
    }
    private void flipVisible(string scale,string lastName) {
        // fretboard.minorScale.ForEach(fretboard.toggleScale);
        // fretboard.harmonicScale.ForEach(fretboard.toggleScale);
        //fretboard.majorScale.ForEach(fretboard.toggleScale);
        if (lastName != null)
        {
            ScaleLadder[lastName].ForEach(fretboard.toggleScale);
        }
        ScaleLadder[scale].ForEach(fretboard.toggleScale);
        //ScaleLadder[scale].ForEach(fretboard.setHeight); 
      
    }
    private void OnMouseEnter()
    {
        setActive(true);
    }
    private void OnMouseExit()
    {
        setActive(false);
    }
    private void OnEnable()
    {
        setActive(false);
    }



    void setActive(bool aim)
    {
        var listObject = gameObject.GetComponentInChildren<Transform>();
        foreach (Transform t in listObject)
        {
            t.gameObject.SetActive(aim);
        }
    }
}
