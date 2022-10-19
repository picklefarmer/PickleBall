using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ring : Inventory,IPlayable
{
    private void Start()
    {
        gameObject.name = "ring";
    }
    public void play() { }
}
