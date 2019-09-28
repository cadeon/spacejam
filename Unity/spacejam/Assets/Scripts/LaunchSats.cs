using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchSats : MonoBehaviour
{
    public GameObject objectToSpawn;
    Vector2 stationLocation;
    Vector2 releaseLocation;
    GameObject spawnedObject;
    public float launchForceScale = 60.0f;
    public float launchFrequency = 10;


    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0,99) <= launchFrequency)
        {

            stationLocation = gameObject.transform.position;
            releaseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spawnedObject = Instantiate(objectToSpawn);
            spawnedObject.transform.position = stationLocation;
            Vector2 randomVector = Random.insideUnitCircle;
            spawnedObject.GetComponent<Rigidbody2D>().AddForce((Vector3)randomVector * launchForceScale);
        }
    }
}

