/******************
 * Author: Nicholas Chen
 * Name Of class: enemy targeting and death 
 * Description of Class: This will control how much health the enemy has and how much damage it should take. Also controls the death of enemies.
 * Date Created: 5/8/2021
 */
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    public float health = 50f; //health for target

    public void TakeDamage (float amount) //function for target to take damage
    {
        health -= amount;
        if (health <= 0f) // if the enemy's health reaches 0, the die function will execute
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);    //function to destroy the game object 
    }
}
