using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{

    SoundWave wave;
    // Start is called before the first frame update
    /* private void OnCollisionEnter(Collision collision)
     {
         Debug.Log(collision.gameObject.name);
         if(collision.gameObject.CompareTag("Note"))         
             Destroy(gameObject);
     }
    */
    public Color colorRef;
    private void OnEnable()
    {
        wave = GameObject.Find("SoundObject").GetComponent<SoundWave>();
        StartCoroutine(WaitToFade());
        
    }
    int countdown = 10;
    float alpha= .1f;
    IEnumerator WaitToFade() {
        Debug.Log("WAITTIFADE");
        while (countdown-- > 0)
        {
            //gameObject.GetComponent<Renderer>().material.color += new Color(0,0,0,alpha);
            
                //material.color += new Color(0, 0, 0, alpha);
            yield return new WaitForSeconds(1);
        }
        pentatonicMode.onEnd?.Invoke();
        Destroy(gameObject);
        wave.audioSource.Stop();
    }
    public void setColor() { 
        
        var materials = gameObject.GetComponentsInChildren<Renderer>();
        Debug.Log(colorRef + "COLOR REF");
        foreach (Renderer mat in materials)
        {
            //paint = mat.material.color;
            //paint.a -= alpha;
            mat.material.color = colorRef;
            mat.material.SetColor("_EmissionColor", colorRef);
            mat.material.EnableKeyword("_EMISSION");
        }
    }
}
