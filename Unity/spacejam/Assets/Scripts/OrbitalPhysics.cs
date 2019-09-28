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
    }

    // Update is called once per frame
    void Update()
    {
        planet = GameObject.Find("Planet");
        // Need to handle drag. This is once per update. Gravity is the loop below.
        float planetDistance = (planet.transform.position - gameObject.transform.position).magnitude;
        double Cd = 0.1; //Should be possible to set per company / satellite
        double drag = (Cd * (1 / planetDistance) * rb.velocity.magnitude);

        rb.drag = (float)drag;

        // Handles gravity between this body and all other bodies
        foreach (GameObject gravityBody in gravityBodies)
        {
            float targetMass = gravityBody.GetComponent<Rigidbody2D>().mass;
            Vector2 gravityToGravity = gravityBody.transform.position - gameObject.transform.position;
            rb.AddForce(gravityToGravity.normalized * targetMass);
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



