using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToPlace : MonoBehaviour
{
    public GameObject objectToSpawn;

    Vector2 clickLocation;
    Vector2 releaseLocation;
    GameObject spawnedObject;
    public float launchForceScale = 60.0f;

    private bool launching;
    public float launchPower;
    public Transform frontEnd;
    public Transform backEnd;

    // Update is called once per frame
    void Update()
    {
        float rightTrigger = Input.GetAxis("RightTrigger");

        Debug.Log(rightTrigger);

        if (rightTrigger != 0)
        {
            launching = true;
        } 
        else 
        {
            launching = false;
        }

        if (launching) 
        {
            launchPower += 100 * Time.deltaTime;
        }
        else if (launchPower > 0f) 
        {
            spawnedObject = Instantiate(objectToSpawn, frontEnd.position, Quaternion.identity);
            spawnedObject.GetComponent<Rigidbody2D>().AddForce((frontEnd.position - backEnd.position) * launchPower);

            launchPower = 0f;
        }

            // releaseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // 
            // spawnedObject.transform.position = clickLocation;
            


        // Keyboard and Mouse controls

        // if (Input.GetMouseButtonDown(0))
        // {
        //     clickLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //     print("Mouse Clicked. Coordinates: " + clickLocation);
        // }
        

        // if (Input.GetMouseButtonUp(0))
        // {
        //     releaseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //     print("Mouse Released. Coordinates: " + releaseLocation);
        //     spawnedObject = Instantiate(objectToSpawn);
        //     spawnedObject.transform.position = clickLocation;
        //     spawnedObject.GetComponent<Rigidbody2D>().AddForce((releaseLocation - clickLocation) * launchForceScale);
        // }
    }
}
