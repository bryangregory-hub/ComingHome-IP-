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
        Story,
        StoryWithQuest,
        btnDactvSecurity,
        btnFloorOpen,
       
    }
    // the distance to spawn the object;
    private Transform theDest;
    public whichType  currentState;
    public GameObject Player;
    [Header("Med kit")]
    public float heal_p;
    [Header("Door animations")]
    public GameObject door;
    [Header("Story and monolog")]
    public bool _hovr=false;
    public GameObject quest;
    public GameObject storyPopUp;
    [Header("Sentury Turret")]
    public GameObject Turret;
    void Start()
    {
        
        
    }
    private void Update()
    {
        theDest = GameObject.Find("Destination").transform;
        if (Input.GetKeyUp(KeyCode.E)&& currentState == whichType.pickUp)
        {
            print("keyup");
            NoInteract();
        }
        

    }
    public void Story()
    {
        if (currentState == whichType.Story)
        {
            if (_hovr == true)
            {
                print("story");
                storyPopUp.SetActive(true);
            }
            else if (_hovr == false)
            {
                print("notstory");
                storyPopUp.SetActive(false);
            }

        }
        if (currentState == whichType.StoryWithQuest)
        {
            if (_hovr == false)
            {
                print("story");
                storyPopUp.SetActive(true);
                quest.SetActive(true);
            }
            else if (_hovr == true)
            {
                print("notstory");
                storyPopUp.SetActive(false);
                
            }

        }


    }
    public void Interact()
    {
        //Debug.Log(name + " has been interacted with.");
        if (currentState == whichType.pickUp)
        {

            GetComponent<Rigidbody>().isKinematic = true;
            
            GetComponent<Rigidbody>().useGravity = false;
            
            this.transform.position = theDest.position;
            this.transform.rotation = theDest.rotation;
            this.transform.parent = GameObject.Find("Destination").transform;
        }
        else if (currentState == whichType.oneTime)
        {
            //print("this is one time");
            Player.GetComponent<SamplePlayer>().heal();
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
        else if (currentState == whichType.btnFloorOpen)
        {
            _btnEtc();
        }
        

    }
    public void NoInteract()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
        
    }

    public void _btnDoor()
    {
        //smt happens
        print("hoi");
        Animator d=door.gameObject.GetComponent<Animator>();
        d.SetBool("Door_open", true);
    }
    public void _btnDactvSecurity()
    {
        //smt happens
        Turret.gameObject.GetComponent<Turret>().enabled = false;
    }
    public void _btnEtc()
    {
        //smt happens
    }
}
