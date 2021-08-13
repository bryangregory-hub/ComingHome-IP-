/******************************************************************************
Author: Bryan Gregory

Name of Class: InteractableObject

Description of Class: This scripts helps identify when the player is interacting with an object
if its a pick up/hold item or checks if anything is interacting with the objects in the game.

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
        liftDoor
    }
    // the distance to spawn the object;
    private Transform theDest;
    public whichType  currentState;
    public GameObject Player;
    [Header("Med kit")]
    public float heal_p;
    [Header("Door")]
    public GameObject door;
    public GameObject DoorIndi;
    [Header("Story and monolog")]
    public bool _hovr=false;
    public GameObject quest;
    public GameObject storyPopUp;
    [Header("Sentury Turret")]
    public GameObject Turret;
    public GameObject TurretQuestIndicator;
    public GameObject turretInidi;
    
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
        

    }/// <summary>
    /// this is to check base of enums if story display smt
    /// </summary>
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
    /// <summary>
    /// this would handle more of the other enums it can differ from holding the item, useing it one time, or a toggle
    /// </summary>
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
        else if (currentState == whichType.liftDoor)
        {
            door.GetComponent<Animator>().SetBool("Lift", true);
            DoorIndi.SetActive(true);
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
        
        Animator d=door.gameObject.GetComponent<Animator>();
        d.SetBool("Door_open", true);
        DoorIndi.SetActive(true);
    }
    public void _btnDactvSecurity()
    {
        //smt happens
        Turret.gameObject.GetComponent<Turret>().range = 0;
        
        turretInidi.gameObject.SetActive(true);
        
            TurretQuestIndicator.gameObject.SetActive(false);   
        
        

    }
    public void _btnEtc()
    {
        //smt happens
    }
}
