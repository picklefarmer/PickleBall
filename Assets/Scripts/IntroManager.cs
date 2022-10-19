using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
   // Rigidbody rb;
   // Vector3 gravity = new Vector3(0, 9.81f, 0);
    // Start is called before the first frame update
    private void Start()
    {
       // gameObject.AddComponent<Rigidbody>();
       // rb = GetComponent<Rigidbody>();
        //Physics.gravity = gravity;
///rb.isKinematic = true;
        //rb.useGravity = false;
    }
    private void OnMouseDown()
    {
       // var pos = new Vector3(1.33000004f, 2.4000001f, -0.0699351653f) - transform.position  ;
        SceneManager.LoadScene("Guitar");
      //  rb.AddForce(pos * 150);
       // rb.useGravity = true;
        
       // rb.useGravity = true;
    }
}
