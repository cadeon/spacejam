using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public float maxZoomOut = 40.0f;
    Camera cam; 

    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize + 1.0f, 0.0f, maxZoomOut);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - 1.0f, 0.0f, maxZoomOut);
        }
    }
}
