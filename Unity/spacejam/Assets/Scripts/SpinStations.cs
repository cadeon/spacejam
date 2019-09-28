using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinStations : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate all the stations
        transform.RotateAround(Vector3.zero, Vector3.forward, 10 * Time.deltaTime);

        // Keep the stations upright

        GameObject station1 = GameObject.Find("SpaceStation1");
        Vector2 vup1 = new Vector2(station1.transform.position.x, station1.transform.position.y + 10);
        station1.transform.LookAt(vup1);

        GameObject station2 = GameObject.Find("SpaceStation2");
        Vector2 vup2 = new Vector2(station2.transform.position.x, station2.transform.position.y + 10);
        station2.transform.LookAt(vup2);

        GameObject station3 = GameObject.Find("SpaceStation3");
        Vector2 vup3 = new Vector2(station3.transform.position.x, station3.transform.position.y + 10);
        station3.transform.LookAt(vup3);

        GameObject station4 = GameObject.Find("SpaceStation4");
        Vector2 vup4 = new Vector2(station4.transform.position.x, station4.transform.position.y + 10);
        station4.transform.LookAt(vup4);




    }
}
