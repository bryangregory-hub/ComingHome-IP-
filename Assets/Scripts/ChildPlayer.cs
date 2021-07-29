/******************************************************************************
Author: Elyas Chua-Aziz

Name of Class: DemoPlayer

Description of Class: This class will control the movement and actions of a 
                        player avatar based on user input.

Date Created: 09/06/2021
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildPlayer : SamplePlayer
{
    //protected override void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("TEST");
    //}

    protected override void CollisionFunction(Collision collision)
    {
        Debug.Log("OVERRIDDEN");
    }
}
