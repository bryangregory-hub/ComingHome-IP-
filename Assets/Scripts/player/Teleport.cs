/******************************************************************************
Author: Bryan Gregory

Name of Class: Teleport

Description of Class: This scripts would teleport the player to different position in the game

Date Created: 03/08/2021
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject thePlayer;
    public GameObject transScreen;

    private void Start()
    {
        transScreen.SetActive(false);
       
    }
    public void OnTriggerEnter(Collider other)
    {//teleports player back to the main room
        if (gameObject.tag=="Untagged")
        {
            thePlayer.transform.position = teleportTarget.transform.position;
            StartCoroutine(Transition());
        }
        
    }
    /// <summary>
    /// when player steps on teleporter a loading screen will apear
    /// </summary>
    /// <returns></returns>
    private IEnumerator Transition()
    {
        transScreen.SetActive(true);
        thePlayer.GetComponent<SamplePlayer>().moveSpeed = 0;
        yield return new WaitForSeconds(1);
        thePlayer.GetComponent<SamplePlayer>().moveSpeed = 5;
        transScreen.SetActive(false);
    }
    void Update()
    {
        

    }

}
