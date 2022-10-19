using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.TextCore.Text;
using UnityEngine;

public static class pentatonicMode
{
    public static Action onEnd;
    public static Action onNoteEnd;
    public static Action birdStart;
    public static Action birdEnd;
    public static Action<GameObject> strumString;
    public static GameObject cloud;
    public static string ScaleName;
    public static bool isChordPlay = false;
    public static bool ScaleType = false;
    public static bool isPlaying = false;
    public static List<GameObject> chords = new List<GameObject> ();
    public static Dictionary<string, Vector3> projection = new Dictionary<string, Vector3>()
    {
        {"key",new Vector3(0,0,0) },
        {"ladder",new Vector3(0,0,0) },
        {"candle" ,new Vector3(0,0,0) },
        {"wand",new Vector3(0,0,0) },
        {"ring" ,new Vector3 (0,0,0) },
        {"bracelet",new Vector3 (0,0,0) },
        {"flute", new Vector3(0,0,0) }
    };
    public static Dictionary<string,float> totemHeight=new Dictionary<string, float>()
    {
        {"turtle",-1 },
        {"deer",-1.5f },
        {"wolf",-2 },
        {"bear",-2.5f },
        {"eagle",-3 }
    };
    public static Dictionary<string, float> rungHeight = new Dictionary<string, float>()
    {
        {"minorScale",1 },
        {"majorScale",0 },
        {"harmonicScale",-1 },
        {"melodicScale",-2 }
    };
    public static Dictionary<string, List<int[]>> ScaleDrive = new Dictionary<string, List<int[]>>() {


    { "majorScale" , new List<int[]>
    {
        new int[]   { 6,0,7,1,0,2,0,3,4,0,5,0},
        new int[]   { 2,0,3,4,0,5,0,6,0,7,1,0},
        new int[]   { 5,0,6,0,7,1,0,2,0,3,4,0},
        new int[]   { 1,0,2,0,3,4,0,5,0,6,0,7},
        new int[]   { 3,4,0,5,0,6,0,7,1,0,2,0},
        new int[]   { 6,0,7,1,0,2,0,3,4,0,5,0}
    }
        },
        {"minorScale", new List<int[]>
    {
        new int[]    {0,7,0,1,0,0,3,0,4,0,5,0,0,7 },
        new int[]    {0,3,0,4,0,5,0,0,7,0,1,0,0,3 },
        new int[]    {5,0,0,7,0,1,0,0,3,0,4,0,5,0 },
        new int[]    {1,0,0,3,0,4,0,5,0,0,7,0,1,0 },
        new int[]    {0,4,0,5,0,0,7,0,1,0,0,3,0,4 },
        new int[]    {0,7,0,1,0,0,3,0,4,0,5,0,0,7 }
    }
        },
        {"harmonicScale", new List<int[]>
    {
        new int[]    {0,2,3,0,4,0,5,6,0,0,7,1 },
        new int[]    {0,5,6,0,0,7,1,0,2,3,0,4 },
        new int[]    {7,1,0,2,3,0,4,0,5,6,0,0 },
        new int[]    {0,4,0,5,6,0,7,1,0,2,3,0 },
        new int[]    {6,0,0,7,1,0,2,3,0,4,0,5 },
        new int[]    {0,2,3,0,4,0,5,6,0,0,7,1 }
    }
        },
        {"melodicScale",new List<int[]>
    {

            new int[]{7,1,0,2,3,0,4,0,5,0,6,0 },
            new int[]{0,4,0,5,0,6,0,7,1,0,2,3 },
            new int[]{6,0,7,1,0,2,3,0,4,0,5,0 },
            new int[]{2,3,0,4,0,5,0,6,0,7,1,0 },
            new int[]{0,5,0,6,0,7,1,0,2,3,0,4 },
            new int[]{7,1,0,2,3,0,4,0,5,0,6,0 },
    }
        }
    };
    public static void drawFret() {

    }

    public static float[] noteTable = new float[]{
        82.41f,   87.31f,   92.50f,   98.00f,   103.8f,   110.0f,   116.5f,   123.5f,
        130.8f,   138.6f,   146.8f,   155.6f,   164.8f,   174.6f,   185.0f,   196.0f,   207.7f,   220.0f,   233.1f,   246.9f,
        261.6f,   277.2f,   293.7f,   311.1f,   329.6f,   349.2f,   370.0f,   392.0f,   415.3f,   440.0f,   466.2f,   493.9f,
        523.3f,   554.4f,   587.3f,   622.3f,   659.3f,   698.5f,   740.0f,   784.0f,   830.6f,   880.0f,   932.3f,   987.8f
    };

}
