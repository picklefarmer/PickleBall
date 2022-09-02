using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Fretboard : MonoBehaviour
{
    public int[,] myArray = new int[3, 6] { {0,0,0,0,0,1 }, {0,1,0,0,0,0 }, { 0,1,0,1,0,0} };
    public GameObject fingers;
    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log(myArray.GetLength(1));
      //  strum(1, 1);
       // strum(2, 2);
        hand();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void strum(float height, float width)
    {
        Instantiate(fingers, new Vector3(height, width, 1), Quaternion.identity);
    }
    void hand()
    {
        var height = myArray.GetLength(0);
        var width = myArray.GetLength(1);
        Debug.Log(width);
        Debug.Log(height);
        for (int y = 0; y < height; ++y)
        {
            for (int x = 0; x < width; ++x)
            {

                if (myArray[y, x] == 1)
                {
                    //Debug.Log(myArray[y, x].ToString());
                    strum(x, y);
                }

            }
        }
        
    }
}
