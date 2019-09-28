using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalPhysics : MonoBehaviour
{
    public float maxGravDist = 4.0f;
    public float maxGravity = 35.0f;

    // Initialize an array of GameObjects to be the planets 
    GameObject[] primaryBodies;
    Rigidbody2D rb;

    void Start()
    {
        // Populate the array of planets  
        primaryBodies = GameObject.FindGameObjectsWithTag("Planet");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject primaryBody in primaryBodies)
        {
            float distance = Vector2.Distance(primaryBody.transform.position, gameObject.transform.position);
            if (distance <= maxGravDist)
            {
                Vector2 orbitalToPrimary = primaryBody.transform.position - gameObject.transform.position;
                rb.AddForce(orbitalToPrimary.normalized * (1.0f - distance / maxGravDist) * maxGravity);
            }
        }
    }



    /* 
 * Original suggested code from https://answers.unity.com/questions/1067579/how-to-make-a-central-point-of-gravity.html
 * 
 using UnityEngine;
 using System.Collections;
 
 public class Bullet2 : MonoBehaviour {
     
     public float maxGravDist = 4.0f;
     public float maxGravity = 35.0f;
 
     GameObject[] planets;
 
     void Start () {
         planets = GameObject.FindGameObjectsWithTag("Planet");
     }
     
     void FixedUpdate () {
         foreach(GameObject planet in planets) {
             float dist = Vector3.Distance(planet.transform.position, transform.position);
             if (dist <= maxGravDist) {
                 Vector3 v = planet.transform.position - transform.position;
                 rigidbody2D.AddForce(v.normalized * (1.0f - dist / maxGravDist) * maxGravity);
             }
         }
     }
 }
 */
}



