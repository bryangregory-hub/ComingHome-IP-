/******************************************************************************
Author: Bryan Gregory

Name of Class: Bullet

Description of Class: This scripts work with turret as the turrent fires it spawn the bullet

Date Created: 03/08/2021
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	private Transform target;

	public float speed = 70f;

	public void Seek(Transform _target)
	{
		target = _target;
	}

	// Update is called once per frame
	/// <summary>
	/// find the tag and fly to it .
	/// </summary>
	void Update()
	{

		if (target == null)
		{
			
			//Destroy(gameObject);
			return;
		}

		Vector3 dir = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if (dir.magnitude <= distanceThisFrame)
		{
			HitTarget();
			return;
		}

		transform.Translate(dir.normalized * distanceThisFrame, Space.World);
		transform.LookAt(target);

	}
	/// <summary>
	/// when gameboject touch player/enemy tag destroy it 
	/// </summary>
	/// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Player")
        {
			Destroy(this.gameObject);
        }
    }
    void HitTarget()
    {
        Destroy(this.gameObject);
    }
    
    // Update is called once per frame
    
    
}
