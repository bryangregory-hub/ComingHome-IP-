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
