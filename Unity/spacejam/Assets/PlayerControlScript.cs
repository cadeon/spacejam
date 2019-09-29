﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlScript : MonoBehaviour
{
    public GameObject[] satellites;
    public int selected = 0;
    //public GameObject objectToSpawn;
    GameObject spawnedObject;
    public float launchPower;
    public Transform frontEnd;
    public Transform backEnd;
    List<GameObject> mySatellites = new List<GameObject>(); // An array to store ALL satellites launched by this player. Will be useful for scoring. 
                                                            // Destroyed satelites will be NULL, so take this into account when scoring. 

    // Update is called once per frame
    void Update()
    {
        // Switch Satellites 
        if (Input.GetButtonDown("Select Satellite"))
        {
            if (selected < satellites.Length - 1)
                selected++;
            else
                selected = 0;
            //Debug.Log("Selected Satellite: " + selected);
        }

        // Hold to charge & launch
        if (Input.GetAxis("RightTrigger") != 0)
        {
            launchPower += 250 * Time.deltaTime;
        }
        else if(launchPower > 0.0f)
        {
            spawnedObject = Instantiate(satellites[selected], transform.position, Quaternion.identity);
            spawnedObject.GetComponent<Rigidbody2D>().AddForce((transform.position - backEnd.position) * launchPower);
            launchPower = 0.0f;
            mySatellites.Add(spawnedObject);    // Add satellite to list
        }
    }
}
