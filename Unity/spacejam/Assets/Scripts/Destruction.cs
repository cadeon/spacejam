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
    float debrisInitialVelocity = 90.0f;
    BoomBox boombox;


    void Start() {
        boombox = GameObject.FindGameObjectWithTag("BoomBox").GetComponent<BoomBox>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // TODO: Add code that insta-destroys the satellite if it touches a planet. Perhaps relating to the object's mass and/or velocity. 

        TakeDamage(1);
    }

    void TakeDamage(int damageTaken)
    {
        Debug.Log("Damaged");

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
            boombox.GoBoom();
            Vector2 satSpeed = gameObject.GetComponent<Rigidbody2D>().velocity;
            for (int i = 0; i < numberOfDebris; i++)
            {
                GameObject debris = Instantiate(debrisObject);
                Vector2 randomVector = Random.insideUnitCircle;
                debris.GetComponent<Rigidbody2D>().mass = Random.Range(0.1f,0.7f);
                debris.transform.position = transform.position + (Vector3)randomVector*debrisInitialDistance;
                debris.GetComponent<Rigidbody2D>().AddForce(randomVector*debrisInitialVelocity);
            }
        }
    }

}
