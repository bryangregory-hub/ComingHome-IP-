/******************************************************************************
Author: Bryan Gregory

Name of Class: InteractableObject

Description of Class: This scripts helps identify why the player is interacting with
if its a pick up and hold item or a one time pick up.

Date Created: 03/08/2021
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractableObject : MonoBehaviour
{
    /// <summary>
    /// using enums to find the different types
    /// </summary>
    public enum whichType
    {
        pickUp,
        oneTime,
        btnDoor,
        btnDactvSecurity,
        btnEtc
    }
    // the distance to spawn the object;
    private Transform theDest;
    public whichType  currentState;

    public GameObject door;
     
    void Start()
    {
        theDest = GameObject.Find("Destination").transform;
        
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E)&& currentState == whichType.pickUp)
        {
            print("keyup");
            NoInteract();
        }
    }

    public void Interact()
    {
        //Debug.Log(name + " has been interacted with.");
        if (currentState == whichType.pickUp)
        {
            
            print("this is pick up");
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.parent = GameObject.Find("Destination").transform;
            this.transform.position = theDest.position;
            this.transform.rotation = theDest.rotation;
        }
        else if (currentState == whichType.oneTime)
        {
            //print("this is one time");
            gameObject.SetActive(false);
        }
        else if (currentState == whichType.btnDoor)
        {
            _btnDoor();
        }
        else if (currentState == whichType.btnDactvSecurity)
        {
            _btnDactvSecurity();
        }
        else if (currentState == whichType.btnEtc)
        {
            _btnEtc();
        }

    }
    
    public void NoInteract()
    {
        
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<BoxCollider>().enabled = true;
    }

    public void _btnDoor()
    {
        //smt happens
    }
    public void _btnDactvSecurity()
    {
        //smt happens
    }
    public void _btnEtc()
    {
        //smt happens
    }
}
