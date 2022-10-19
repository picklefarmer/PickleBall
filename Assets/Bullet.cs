using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    int speed = 10;
    void Update()
    {
        transform.Translate(new Vector3(0,0,-1) * speed * Time.deltaTime);
    }
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

}
