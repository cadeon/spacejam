using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    public int health = 1;
    public GameObject debrisObject;
    public int numberOfDebris;
    bool isQuitting = false;
    float debrisInitialDistance = 1.0f;
    float debrisInitialVelocity = 40.0f;

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

    void OnApplicationQuit()
    {
        isQuitting = true;
    }

    private void OnDestroy()
    {
        // TODO: Spawn debris 
        if (!isQuitting)
        {
            for (int i = 0; i < numberOfDebris; i++)
            {
                GameObject debris = Instantiate(debrisObject);
                Vector2 randomVector = Random.onUnitSphere;
                randomVector = randomVector.normalized;
                debris.GetComponent<Rigidbody2D>().mass = Random.value;
                debris.transform.position = transform.position + (Vector3)randomVector*debrisInitialDistance;
                debris.GetComponent<Rigidbody2D>().AddForce(gameObject.GetComponent<Rigidbody2D>().velocity + randomVector*debrisInitialVelocity);
            }
        }
    }

}
