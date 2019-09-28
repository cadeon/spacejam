using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToPlace : MonoBehaviour
{
    public GameObject objectToSpawn;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            print("Mouse Clicked. Coordinates: " + clickLocation);
            GameObject spawnedObject = Instantiate(objectToSpawn);
            spawnedObject.transform.position = clickLocation;
        }
    }
}
