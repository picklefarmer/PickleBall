using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{

    public int count = 0;
    private void OnMouseDown()
    {
        addForce();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            fire();
        };
        if (Input.GetKeyDown(KeyCode.LeftControl)){
            fire();
        }
    }


    void fire() {
    
    
    GameObject go = ObjectPool.instance.GetPooledObject();

        if(go != null)
        {
            go.transform.position = transform.position;
            go.SetActive(true);
        }
    
    }
    void addForce() {

        var wings = gameObject.GetComponentsInChildren<Rigidbody>();
       
        Debug.Log("flap "+count);
        foreach(Rigidbody wing in wings)
        {
            wing.AddForce(Vector3.forward * 125);
        }
        count++;
    }



}
