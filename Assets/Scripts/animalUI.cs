using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;
//using static TreeEditor.TreeEditorHelper;

public class animalUI : MonoBehaviour
{
    public List<GameObject> animalObjects = new List<GameObject>();
    Fretboard fretboard;
    public GameObject noteObject;
    public GameObject figureObject;
    GameObject battle;
    GameObject castle;
    public bool isVisible = true;
    public float zPosition;
    public Vector3 destination;
    public Vector3 startLocation;
    float Step = .125f;
    float counter = 0;
    float speed = .125f;
    // public int offsetX = -5;
    GameObject gamePiece;

    Dictionary<string, int[,]> animal = new Dictionary<string, int[,]> {
        {   "deer",new int[,] {
           { 5,0,0,7 },
           { 1,0,0,3 },
           { 4,0,5,0 },
           { 7,0,1,0 },
           { 0,3,0,4 },
           { 5,0,0,7 }
        }},
        {   "bear",new int[,]{
           { 0,3,0,4 },
           { 5,0,0,7 },
           { 1,0,0,3 },
           { 4,0,5,0 },
           { 0,7,0,1 },
           { 0,3,0,4 }
        } },
        {   "wolf",new int[,]{
           { 0,4,0,5,0 },
           { 0,7,0,1,0 },
           { 0,3,0,4,0 },
           { 5,0,0,7,0 },
           { 0,1,0,0,3 },
           { 0,4,0,5,0 }
        } },
        {   "eagle",new int[,]{
           { 1,0,0,3 },
           { 4,0,5,0 },
           { 7,0,1,0 },
           { 3,0,4,0 },
           { 5,0,0,7 },
           { 1,0,0,3 }
        } },
        {   "turtle",new int[,]{
            {0,7,0,1 },
            {0,3,0,4 },
            {5,0,0,7 },
            {1,0,0,3 },
            {0,4,0,5 },
            {0,7,0,1 }
        } }
    };
    Dictionary<string, Quaternion> rotations = new Dictionary<string, Quaternion>
   {
       {"deer",Quaternion.Euler (180,0,180) },
       {"bear",Quaternion.Euler(180,0,-90) },
       {"wolf",Quaternion.Euler(180,0,180) },
       {"eagle",Quaternion.Euler(180,0,-90) },
       {"turtle",Quaternion.Euler(0,0,-90) }
};
    Dictionary<string, Color32> animalPallete = new Dictionary<string, Color32>
    {
        { "deer",      new Color32(255,89,94,255) },
        { "bear",      new Color32(255,202,58,255)},
        { "wolf",      new Color32(138,201,38,255)},
        { "eagle",     new Color32(25,130,196,255)},
        { "turtle",   new Color32(106,76,147,255)}
    };
    public void sendPiece(Vector3 clicked,Color paint)
    {
        if (gamePiece == null)
        {
            //clicked.z = 0;
            startLocation = clicked;

            gamePiece = Instantiate(battle, clicked, Quaternion.identity);
            gamePiece.GetComponent<Castle>().colorRef = paint;
            gamePiece.GetComponent<Castle>().setColor();
            //gamePiece.GetComponent<Renderer>().material.SetColor("_EmissionColor",paint);
            //gamePiece.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            //gamePiece.transform.rotation = Quaternion.Euler(90, 0, 0);
            // gamePiece.transform.localScale = new Vector3(.5f, .5f, .5f);

        }

        if (clicked != startLocation)
        {

            destination = clicked;
            Vector3 pos = destination - startLocation;
            // StartCoroutine(movePiece());
            // gamePiece.transform.DOMove(destination, 1);
            // Physics.gravity = new Vector3(0,9.81f,0);
           GameObject shattered = Instantiate(castle, destination,Quaternion.Euler(0,-90,90));
            shattered.GetComponent<Castle>().colorRef = paint;
            shattered.GetComponent<Castle>().setColor();
            //Debug.Log(destination+" "+startLocation+" "); 
            var gamePieces= gamePiece.GetComponentsInChildren<Rigidbody>();
            foreach (var piece in gamePieces)
            {
                piece.GetComponent<Rigidbody>().AddForce(pos * 25);
            }
            //gamePiece.GetComponent<Rigidbody>().AddForce(pos * 125);
            
            
            //gamePiece.transform.DOScale(1, 1).OnComplete(() => gamePiece.transform.DOScale(.5f, 1));
            //gamePiece.transform.DOScale(0,1); 

        }

    }
    void Start() {
        //Debug.Log("instantiating object");
        //gameObject.GetComponent<Renderer>().material.color = animalPallete[gameObject.name];
        fretboard = GameObject.Find("GameBoard").GetComponent<Fretboard>();
        //figureObject = (GameObject)Resources.Load("gamePiece");
        zPosition = pentatonicMode.totemHeight[gameObject.name];
        link = toggleMain;
        castle = (GameObject)Resources.Load("castle shattered");
        battle = (GameObject)Resources.Load("ball");

    }

    void OnMouseDown()
    {
        Debug.Log("instatiating objects");
        var arr = animal[gameObject.name];
        counter = 0;
        if (pentatonicMode.ScaleName != null)
        {
            if (animalObjects.Count == 0)
            {
                Debug.Log("instatiating objects");
                slap(arr, animalObjects);
                pentatonicMode.isPlaying = false;
                StartCoroutine(movePiece(link));
            }
            else
            {
                if (animalObjects[0].activeSelf == true)
                {
                    animalObjects.ForEach(obj => obj.SetActive(false));
                }
                else
                {
                    pentatonicMode.isPlaying = false;
                    StartCoroutine(movePiece(link));
                    animalObjects.ForEach(obj => obj.SetActive(true));
                    animalObjects.ForEach(obj => fretboard.setHeight(obj, zPosition));
                }
            }
        }

    }
    public void slidePentatonic(bool isRight)
    {
        if (isRight)
        {
            animalObjects.ForEach(obj => obj.transform.position += new Vector3(1, 0, 0));
        }
        else
        {
            animalObjects.ForEach(obj => obj.transform.position -= new Vector3(1, 0, 0));

        }
    }

    void slap(int[,] arr, List<GameObject> objects)
    {
        var height = arr.GetLength(0);
        var width = arr.GetLength(1);
        var offsetx = -5;
        var offsety = -5;
        for (var x = 0; x < height; x++)
        {
            for (var y = 0; y < width; y++)
            {
                if (arr[x, y] != 0)
                {
                    GameObject element;
                    if (pentatonicMode.ScaleType)
                    {
                        element = Instantiate(noteObject, new Vector3(y + offsetx, x + offsety, zPosition + pentatonicMode.rungHeight[pentatonicMode.ScaleName]), Quaternion.identity);
                        element.GetComponent<Renderer>().material.SetColor("_EmissionColor", gameObject.GetComponent<Renderer>().material.color);
                        element.tag = "Pentatonic";
                        element.GetComponent<MeshCollider>().convex = true;
                        element.GetComponent<MeshCollider>().isTrigger = true;
                        //element.name = gameObject.name;
                        Debug.Log(element.name + "Instantiated name");
                        element.AddComponent<FigureManager>();
                        //element.GetComponent<FigureManager>().colorValue = arr[x, y];
                        element.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
                        element.transform.localScale = new Vector3(0.25f, .25f, .25f);
                        element.transform.localRotation = Quaternion.Euler(180,0,-90);
                    }
                    else
                    {
                        var item = fretboard.inventory[fretboard.inventoryList[arr[x, y]]];
                        element = Instantiate(item, new Vector3(y + offsetx, x + offsety, zPosition + pentatonicMode.rungHeight[pentatonicMode.ScaleName]), item.transform.rotation);
                    }

                    element.name = gameObject.name;
                    //element.
                    objects.Add(element);
                }
            }
        }
       
    }
    IEnumerator movePiece(linkMethod main) {
        Debug.Log("coroutine");


        yield return new WaitForSeconds(1f);
        Debug.Log("end Coroutine");
        main();

    }
    delegate void linkMethod();
    linkMethod link;
    void toggleMain() { 
    pentatonicMode.isPlaying = !pentatonicMode.isPlaying;
    }
}
