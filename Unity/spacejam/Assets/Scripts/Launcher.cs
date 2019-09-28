using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
	public float speed = 50f;
	private float prevX;
	private float prevY;

	void Update() 
	{
		// aiming via the controller stick
		float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		float y = Input.GetAxis("Vertical") * speed * Time.deltaTime;

		// update position with station position
		x += transform.parent.position.x;
		y += transform.parent.position.y;

		Vector2 v = new Vector2(x, y);

		transform.position = v;

	}

}