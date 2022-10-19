using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ChordNote : MonoBehaviour
{
    Fretboard fretboard;
    AudioMixer mixer;
    public float frequency1;

    //[Range(380,600)]  //Creates a slider in the inspector
    public float frequency2;

    public float sampleRate = 44100;
    public float waveLengthInSeconds = 2.0f;


    float phase = 0;
    float phase2 = 0;

    public AudioSource audioSource;
    AudioLowPassFilter lowey;
    //AudioMixer audioMixer;
    int timeIndex = 0;
    
    bool isTrigger = false;
    private void Start()
    {
        fretboard = GameObject.Find("GameBoard").GetComponent<Fretboard>();
        mixer = (AudioMixer)Resources.Load("TheAudioMixer");
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = mixer.FindMatchingGroups("Master")[0];
        lowey = gameObject.AddComponent<AudioLowPassFilter>();
        audioSource.playOnAwake = false;
        lowey.cutoffFrequency = 219;
        audioSource.reverbZoneMix = 0;
        audioSource.volume = .5f;
        audioSource.spatialBlend = 0;
    }
    
 
    private void OnTriggerEnter(Collider collision)

    {
        Debug.Log(collision + " Collission");
        if (collision.gameObject.CompareTag("Pick"))
        {
            
            if (audioSource.isPlaying)
            {
                pentatonicMode.onNoteEnd?.Invoke();
                isTrigger = false;
                if (BirdUI.isBirdOn)
                {
                    audioSource.Stop();
                }
            }
            else
            {
                pentatonicMode.strumString?.Invoke(gameObject);
                gameObject.GetComponentInChildren<Renderer>().material.EnableKeyword("_EMISSION");
                gameObject.GetComponentInChildren<Renderer>().material.SetColor("_EmissionColor", gameObject.GetComponentInChildren<Renderer>().material.color);
                Debug.Log("entered note from bird   ");
                isTrigger = true;
                if (BirdUI.isBirdOn)
                {
                    audioSource.Play();
                }
            }

        }
    }
    private void OnDisable()
    {
        pentatonicMode.onNoteEnd?.Invoke();
        audioSource.Stop();
    }
   

    private void OnMouseDown()
    {
        fretboard.noteList.Remove(gameObject);
        Destroy(gameObject);
    }
    void OnAudioFilterRead(float[] data, int channels)
    {
        for (int i = 0; i < data.Length; i += channels)
        {
            phase += 2 * Mathf.PI * frequency1 / sampleRate;
            phase2 += 2 * Mathf.PI * frequency2 / sampleRate;

            data[i] = Mathf.Sin(phase);
            if (channels == 2)
                data[i + 1] = Mathf.Sin(phase2);
            if (phase >= 2 * Mathf.PI)
            {
                phase -= 2 * Mathf.PI;
            }
            if (phase2 >= 2 * Mathf.PI)
            {
                phase2 -= 2 * Mathf.PI;
            }
        }
    }


}
