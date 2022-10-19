using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class noteWorthy : MonoBehaviour
{
    //public Light noteSense;
    public GameObject pluck;

    public GameObject keyObject;
    Vector3 pluckPos;
    public SoundWave wave;
    
    public Color colorRef;
    public int noteType;
    public float frequency;

    Fretboard fretboard;
    GameObject flower;
    Dictionary<string, Color> noteCounter    =   new Dictionary<string, Color>();

    void turnToBlack() {

        gameObject.GetComponent<Renderer>().material.color = Color.black;
        pentatonicMode.onEnd -= turnToBlack;
    
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Pentatonic")) {

            other.gameObject.GetComponent<FigureManager>().colorValue = noteType;
        };
        if (other.CompareTag("Piece"))
        {
            wave.frequency1 = frequency;
            gameObject.GetComponent<Renderer>().material.color = colorRef;
            pentatonicMode.onEnd += turnToBlack;
           // wave.frequency2 = frequency;
        }
        if (other.CompareTag("Ball"))
        {
            wave.frequency2 = frequency;
            gameObject.GetComponent<Renderer>().material.color = colorRef;
            pentatonicMode.onEnd += turnToBlack;
        }
        /*
        gameObject.GetComponent<Renderer>().material.color = colorRef;
        if (other.name != "Tap(Clone)")
        {
            tallyTotem(other);
        }
        */
    }
    private void OnMouseDown()
    {
        //noteSense.color = colorRef;
        Debug.Log(frequency);
        wave.frequency1 = frequency;
        wave.frequency2 = frequency;
        //override start data
        GameObject pluckInstance = null;
        pluckPos = transform.position;
        pluckPos = new Vector3(Mathf.Round(pluckPos.x),pluckPos.y,pluckPos.z);
        if (pluckInstance == null)
        {
            if (pentatonicMode.ScaleType)
            {
                var item = fretboard.inventory[fretboard.inventoryList[noteType]];
                var jumpPos = pluckPos;

                jumpPos.z += -1;
                //pluckInstance = Instantiate(item, jumpPos, item.transform.rotation);
                pluckInstance = Instantiate(flower, jumpPos,Quaternion.Euler(180,0,0));
                pluckInstance.GetComponent<ChordNote>  ().frequency1 = frequency;
                pluckInstance.GetComponent <ChordNote> ().frequency2 = frequency;
                pluckInstance.GetComponentInChildren<Renderer>().material.color = colorRef;
                
            }
            else
            {

                pluckInstance  = Instantiate(pluck, pluckPos,Quaternion.identity);
                pluckInstance.GetComponent<Renderer>().material.SetColor("_EmissionColor", colorRef);
                pluckInstance.GetComponent<Rigidbody>().useGravity = true;
            }

            fretboard.noteList.Add(pluckInstance);
        }
        /*
        else if (pluckInstance.activeSelf)
        {
            //lightInstance.enabled = false;
            //pluckInstance.SetActive(false);
            fretboard.noteList.Remove(pluckInstance);
            Destroy(pluckInstance);
            //gameObject.GetComponent<Renderer>().material.color = new Color32(82, 37, 0,255);
        }
        else
        {
            pluckInstance.SetActive(true);
            Debug.Log("already made");
            //lightInstance.enabled = true;
        }
        */
    }
    void Start()
    {
        wave = GameObject.Find("SoundObject").GetComponent<SoundWave>();
        fretboard = GameObject.Find("GameBoard").GetComponent<Fretboard>();
        //keyObject = (GameObject)Resources.Load("keyTotem");
       // lightPos = transform.position;
        pluckPos = transform.position;
        flower = (GameObject)Resources.Load("Flower");
        //lightPos.z = 0f;
        //pluckPos.z = 1f;
        //noteSense.intensity = 0.25f;
        
    }

    void tallyTotem(Collider other) {
        var totemList = fretboard.totemList;
        var totemLength = totemList.Count;
        var keyHeight = new Vector3(-12f, -totemLength, -1f);
        //if (!noteCounter.ContainsKey(other.name))
        
            //var color = other.GetComponent<Renderer>().material.color;
            //noteCounter[other.name] = true;
            //noteCounter.Add(other.name, color);
        if (!totemList.ContainsKey(noteType))
         {
            var totemKey = Instantiate(keyObject, keyHeight, Quaternion.Euler(0f, 90f, 0f));
            totemKey.GetComponent<Renderer>().material.color = colorRef;
            totemKey.GetComponent<Renderer>().material.SetColor("_EmissionColor", colorRef);
           totemList.Add(noteType,totemKey ) ;
         }
        
    }
    private float speed = 1;
    void Update()
    {

        if (pentatonicMode.isPlaying)
        {
            if (transform.position.x <= -10)
            {
                transform.Translate(Vector3.right * 12);
            }
            else
            {
                transform.Translate(Vector3.left *speed* Time.deltaTime);
            }
        }
        else
        {
            Vector3 pos = transform.position;
            pos.x = Mathf.RoundToInt(transform.position.x);
            transform.position = pos;
        }
    }
}
