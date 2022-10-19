using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;


using UnityEngine;


public class Fretboard : MonoBehaviour
{
    public string[] inventoryList = new string[] {
        "",
        "keyTotem" ,
        "ring" ,
        "candle" ,
        "ladder" ,
        "flute" ,
        "bracelet" ,
        "wand" 
    };
    public Dictionary<string,GameObject> inventory=new Dictionary<string,GameObject>();
    public GameObject fingers;
    //public GameObject pluck;
    public Color[] colorArray = {      Color.black,
                                Color.red,         //1
                            new Color(.9f, .4f, 0),//2
                                Color.yellow,      //3
                                Color.green,       //4
                                Color.cyan,        //5 
                                Color.blue,        //6 
                            new Color(1, 0, 1) ,    //7 
                                Color.gray

    };
    public Color32[] palleteFive = { 
        new Color32(0,0,0,0),
        new Color32(255,89,94,255),
        new Color32(255,202,58,255),
        new Color32(138,201,38,255),
        new Color32(25,130,196,255),
        new Color32(106,76,147,255)
    };
    public Color32[] palleteSeven = { 
        new Color32(0,0,0,0),
        new Color32(249,65,68,  100),
        new Color32(243,114,44, 100),
        new Color32(248,150,30, 100),
        new Color32(249,199,79, 100),
        new Color32(144,190,109,100),
        new Color32(67,170,139, 100),
        new Color32(87,117,144, 100)
    };
    //int colorIndex = 0;
    // public List<GameObject> minorScale;
    // public List<GameObject> majorScale;
    // public List<GameObject> harmonicScale;

    public Dictionary<string, List<GameObject>> ScaleSet = new Dictionary<string, List<GameObject>>() {
        {"majorScale",new List<GameObject>()},
        {"minorScale",new List<GameObject>()},
        {"harmonicScale",new List<GameObject>()},
        {"melodicScale",new List<GameObject>()},
    };

    public List<GameObject> noteList;
   // public int isTwelve = 0;
    bool isFirst = false;
    public bool isVisible=false;
    bool afterStart = false;
    public Dictionary<int, GameObject> totemList = new Dictionary<int, GameObject>();
    //private Dictionary<string, List<GameObject>> ScaleLadder;


    //private int[,] minorPentatonic = pentatonicMode.minor;
    // private int[,] majorPentatonic = pentatonicMode.major;

    public void loadInventory() {
        int i = 0;
        foreach (var name in inventoryList)
        {
            if (name != "")
            {
                inventory.Add(name, (GameObject)Resources.Load(name));
               // Instantiate(inventory[name], new Vector3(-12, -1 * i, -2), inventory[name].transform.rotation);
                i++;
            }
        }

    }
    void Start()
    {
       
        loadInventory();
        hand(pentatonicMode.ScaleDrive["majorScale"], ScaleSet["majorScale"], pentatonicMode.rungHeight["majorScale"]);
        hand(pentatonicMode.ScaleDrive["minorScale"], ScaleSet["minorScale"], pentatonicMode.rungHeight["minorScale"]);
        hand(pentatonicMode.ScaleDrive["harmonicScale"], ScaleSet["harmonicScale"], pentatonicMode.rungHeight["harmonicScale"]);
        hand(pentatonicMode.ScaleDrive["melodicScale"], ScaleSet["melodicScale"], pentatonicMode.rungHeight["melodicScale"]);

        afterStart = true;

    }
  
   
    void strum(float height, float width,int colIndex,List<GameObject> scale,float flight,float frequency)
    {
        var offsetx = 10;
        var offsety = -5f;
        height-= offsetx;
        width += offsety;
        var noteInstance= Instantiate(fingers, new Vector3(height, width, flight), Quaternion.identity);
        
        //noteInstance.GetComponent<noteWorthy>().colorRef = palleteSeven[colIndex];
        noteInstance.GetComponent<noteWorthy>().colorRef = colorArray[colIndex];
        noteInstance.GetComponent<noteWorthy>().noteType = colIndex;
        noteInstance.GetComponent<noteWorthy>().frequency = frequency;
        scale.Add(noteInstance);
       
       
    }
    public void hand(List<int[]> pentatonic,List<GameObject> scale,float flight)
    {
        var height = pentatonic.Count;
        var width = pentatonic[0].GetLength(0);
      
        for (int y = 0; y < height; ++y)
        {
            for (int x = 0; x < width; ++x)
            {
                if (pentatonic[y][ x] != 0)
                {
                   strum(x, y, pentatonic[y][x],scale,flight,noteCalculator(x,y));
                }

            }
        }

        if (!afterStart)
        {
            scale.ForEach(toggleScale);
        }
    }
    public void toggleScale(GameObject note)
    {
        if (note.activeSelf)
        {
            note.SetActive(false);
        }
        else
        {
            note.SetActive(true);
        }
    }
    public float noteCalculator(int fret, int line) {
        int plus;
        if (line == 4)
        {
            plus = 19;
        }
        else if (line == 5)
        {
            plus = 24;
        }
        else { 
            plus = line * 5;
        }

        var note = fret + plus;
        return pentatonicMode.noteTable[note];
    }
    public void setHeight(GameObject note,float offset)
    {
        Vector3 height = note.transform.position;
        note.transform.position = new Vector3(height.x, height.y,offset+ pentatonicMode.rungHeight[pentatonicMode.ScaleName]);
    }
    
}
