using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    Vector3 initialScale;
    
    public SoundWave wave;
    GameObject note;
    Vector3 direction;
    private void OnEnable()
    {
        note = (GameObject)Resources.Load("rose");
        initialScale = transform.localScale;
       // wave = GameObject.Find("SoundObject").GetComponent<SoundWave>();
        
    }
    private void OnMouseEnter()
    {
        transform.DOScale(.5f, 1);
        transform.DORotate(new Vector3(0, 180, 0), 2f);
    }
    private void OnMouseExit()
    {
        transform.DOScale(initialScale,1);
    }
    private void OnMouseDown()
    {
        direction = pentatonicMode.projection[name];
        Vector3 here = transform.position;
        here += direction;
        var sideNote = Instantiate(note,here,Quaternion.Euler(90,0,0));
    }
}
