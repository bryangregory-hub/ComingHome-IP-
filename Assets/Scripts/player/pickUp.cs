using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{
    public Transform theDest;

        
    void OnMouseDown()
    {

            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.parent = GameObject.Find("Destination").transform;
            this.transform.position = theDest.position;
            this.transform.rotation = theDest.rotation;
        
    }
    void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<BoxCollider>().enabled = true;
    }
}
