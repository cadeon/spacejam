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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            print("Mouse Clicked. Coordinates: " + clickLocation);
        }
        if (Input.GetMouseButtonUp(0))
        {
            releaseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            print("Mouse Released. Coordinates: " + releaseLocation);
            spawnedObject = Instantiate(objectToSpawn);
            spawnedObject.transform.position = clickLocation;
            spawnedObject.GetComponent<Rigidbody2D>().AddForce((releaseLocation - clickLocation) * launchForceScale);
        }
    }
}
