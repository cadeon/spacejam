using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalPhysics : MonoBehaviour
{
    // Gravity behavior between bodies is completely dependent on body mass
    // There's no distance limit to gravity / it does not increase or decrease over distance
    // Initialize an array of GameObjects to be the planets 
    GameObject[] gravityBodies;
    GameObject planet;
    Rigidbody2D rb;

    void Start()
    {
        // Populate the array of planets, satellites, and debris
        gravityBodies = GameObject.FindGameObjectsWithTag("Gravity");
        rb = GetComponent<Rigidbody2D>();
        planet = GameObject.Find("Planet");
    }

    // Update is called once per frame
    void Update()
    {
        // Handles gravity between this body and all other bodies
        foreach (GameObject gravityBody in gravityBodies)
        {
            float targetMass = gravityBody.GetComponent<Rigidbody2D>().mass;
            Vector2 gravityToGravity = gravityBody.transform.position - gameObject.transform.position;
            rb.AddForce(gravityToGravity.normalized * targetMass);
        }

        // Handles Drag 
//        Vector2 planetDistance = planet.transform.position - gameObject.transform.position;
//        float drag = 1 / planetDistance.magnitude;
//        rb.velocity *= drag;


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



