using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlScript : MonoBehaviour
{
    public int controllerNumber;

    public GameObject[] satellites;
    public int selected = 0;
    //public GameObject objectToSpawn;
    float launchChargeModifier = 400.0f;   // A multiplier for the charge time. 250.0 is default, but can be changed. 
    float launchChargeCap = 800.0f;   // The max charge 
    float launchChargeMinimum = 100.0f;   // The minimum charge to fire a satellite
    GameObject spawnedObject;
    public float launchPower;
    public Transform frontEnd;
    public Transform backEnd;
    List<GameObject> mySatellites = new List<GameObject>(); // An array to store ALL satellites launched by this player. Will be useful for scoring. 
                                                            // Destroyed satelites will be NULL, so take this into account when scoring. 
    public Team team;
    public TeamsManager teamsMngr;

    void Start()
    {
        teamsMngr = GameObject.FindGameObjectWithTag("TeamsManager").GetComponent<TeamsManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // Switch Satellites 
        if (Input.GetButtonDown(controllerNumber + "P Select Satellite"))
        {
            if (selected < satellites.Length - 1)
                selected++;
            else
                selected = 0;
            //Debug.Log("Selected Satellite: " + selected);
        }

        // Hold to charge & launch
        if (Input.GetButton(controllerNumber + "P Launch Satellite"))
        {
            launchPower = Mathf.Clamp(launchPower + Time.deltaTime * launchChargeModifier, 0.0f, launchChargeModifier * 2);
        }
        else if(launchPower > 0.0f)
        {
            if (launchPower > launchChargeMinimum)
            {
                spawnedObject = Instantiate(satellites[selected], transform.position, Quaternion.identity);
                spawnedObject.GetComponent<Rigidbody2D>().AddForce((Vector2)((transform.position - backEnd.position) * launchPower));
                mySatellites.Add(spawnedObject);    // Add satellite to list
            
                Satellite sat = spawnedObject.GetComponent<Satellite>();
                if(sat != null)
                {
                    sat.team = team;
                    teamsMngr.AddSat(team, spawnedObject);
                }
            }
            launchPower = 0.0f;
        }
    }
}
