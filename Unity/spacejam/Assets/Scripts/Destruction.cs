using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    public int health = 1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // TODO: Add code that insta-destroys the satellite if it touches a planet. Perhaps relating to the object's mass and/or velocity. 
        TakeDamage(1);
    }

    void TakeDamage(int damageTaken)
    {
        health = health - damageTaken; 
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        // TODO: Spawn debris 
    }

}
