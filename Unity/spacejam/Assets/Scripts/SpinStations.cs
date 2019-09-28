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

        }
}
