using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
	public float speed = 50f;
    public int controllerNumber;
    private float prevX;
	private float prevY;

    float smooth = 5.0f;
    float tiltAngle = 60.0f;

    void Update() 
	{
        float xaxis = Input.GetAxis(controllerNumber + "P Horizontal");
        float yaxis = Input.GetAxis(controllerNumber + "P Vertical");

        float arrowangle = Mathf.Atan2(xaxis, -yaxis) * Mathf.Rad2Deg;

        // aiming via the controller stick
        float x = xaxis * speed * Time.deltaTime;
		float y = yaxis * speed * Time.deltaTime;

		// update position with station position
		x += transform.parent.position.x;
		y += transform.parent.position.y;

		Vector2 v = new Vector2(x, y);

        // update rotation

        // Rotate by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(0, 0, arrowangle);

        transform.position = v;
        transform.rotation = Quaternion.Slerp(transform.rotation, target, 100);

        if (controllerNumber == 4)
        {
            Debug.Log("X : " + xaxis);
            Debug.Log("Y : " + yaxis);
        }

        if (xaxis == 0f && yaxis == 0f)
        {
            transform.localScale = new Vector3(0f, 0f, 0f);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }


    }

}