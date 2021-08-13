/******************
 * Author: Nicholas Chen
 * Name Of class: Gun
 * Description of Class: This would control the damage and range of gun. Also uses raycast for detecting and aiming at objects
 * Date Created: 5/8/2021
 */
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot() //function for shooting 
    {
        RaycastHit hit;
         if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) //if raycast hits 
        {
            Debug.Log(hit.transform.name);
            EnemyTarget target = hit.transform.GetComponent<EnemyTarget>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
