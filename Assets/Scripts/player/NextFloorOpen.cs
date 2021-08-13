/******************************************************************************
Author: Bryan Gregory

Name of Class: Next Floor Open

Description of Class: This scripts would help check if a keycard is touching a keypad and smt happens

Date Created: 03/08/2021
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NextFloorOpen : MonoBehaviour
{
    public GameObject keycard;
    public GameObject teleporter;
    public GameObject alert;
    public GameObject door;
    public GameObject cardindi;
    
    // Start is called before the first frame update
    public bool securityRoom;
    void Start()
    {
        alert.gameObject.SetActive(false);
        teleporter.gameObject.SetActive(false);
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// if acess card is interacted with the the keypad smt will happen
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "card"&& securityRoom == false)
        {
            print("hi");
            alert.gameObject.SetActive(true);
            keycard.gameObject.SetActive(false);
            teleporter.gameObject.SetActive(true);
            cardindi.gameObject.SetActive(false);
        }
        if (other.gameObject.tag=="card"&&securityRoom==true)
        {
            alert.gameObject.SetActive(true);
            keycard.gameObject.SetActive(false);
            door.GetComponent<Animator>().enabled = true;
        }
    }

}
