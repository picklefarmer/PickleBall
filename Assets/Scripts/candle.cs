using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candle : Inventory,IPlayable
{
    
    private void Start()
    {
        gameObject.name = "candle";
    }
    public void play() { }
   
}
