using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundWave : MonoBehaviour
{

    //[Range(380,600)]  //Creates a slider in the inspector
    public float frequency1;

    //[Range(380,600)]  //Creates a slider in the inspector
    public float frequency2;

    public float sampleRate = 44100;
    public float waveLengthInSeconds = 2.0f;

    public AudioSource audioSource;
    AudioLowPassFilter lowey;
    //AudioMixer audioMixer;
    int timeIndex = 0;

    void Start()
    {
        //audioMixer = GetComponent<TheAudioMixer>();
        audioSource = gameObject.GetComponent<AudioSource>();
        lowey = gameObject.AddComponent<AudioLowPassFilter>();
        lowey.cutoffFrequency = 219;
        //audioSource.outputAudioMixerGroup = audioMixer;
        audioSource.playOnAwake = false;
        audioSource.volume = .5f;
        audioSource.spatialBlend = 0; //force 2D sound
        audioSource.Stop(); //avoids audiosource from starting to play automatically
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!audioSource.isPlaying)
            {
                timeIndex = 0;  //resets timer before playing sound
                audioSource.Play();
            }
            else
            {
                audioSource.Stop();
            }
        }
    }

    float phase = 0;
    float phase2 = 0;
    void OnAudioFilterRead(float[] data, int channels)
    {
        for (int i = 0; i < data.Length; i += channels)
        {
            phase += 2 * Mathf.PI * frequency1 / sampleRate;
            phase2 += 2 * Mathf.PI * frequency2 / sampleRate;

            data[i] = Mathf.Sin(phase);
            if(channels==2)
                data[i+1]= Mathf.Cos(phase2);
            if (phase >= 2 * Mathf.PI)
            {
                phase -= 2 * Mathf.PI;
            }
            if(phase2 >= 2 * Mathf.PI)
            {
                phase2 -= 2* Mathf.PI;
            }
        }
    }



    /*
    void OnAudioFilterRead(float[] data, int channels)
    {
        for (int i = 0; i < data.Length; i += channels)
        {
            data[i] = CreateSquare(timeIndex, frequency1, sampleRate);

            if (channels == 2)
                data[i + 1] = CreateSine(timeIndex, frequency2, sampleRate);

            timeIndex++;

            //if timeIndex gets too big, reset it to 0
            if (timeIndex >= (sampleRate * waveLengthInSeconds))
            {
                timeIndex = 0;
            }
        }
    }
    */
    //Creates a sinewave
    public float CreateSine(int timeIndex, float frequency, float sampleRate)
    {
        return Mathf.Sin(2 * Mathf.PI * timeIndex * frequency / sampleRate);
    }
   public float CreateSquare(int timeIndex,float frequency, float sampleRate)
    {
        return Mathf.Sign(Mathf.Sin(2 * Mathf.PI * timeIndex * frequency / sampleRate));

    }
}
