/******************************************************************************
Author: Bryan Gregory

Name of Class: Win

Description of Class: This scripts identifies if the player has reach the end with all requirment ment

Date Created: 03/08/2021
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public GameObject Player;
    public GameObject robot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// check if win condition is true 
    /// if true end game
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject==Player && robot.GetComponent<PatrolAI>().currentState=="Following")
        {
            SceneManager.LoadScene("WinMenu");
        }
    }
}
