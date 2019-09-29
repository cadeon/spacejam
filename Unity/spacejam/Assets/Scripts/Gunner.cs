using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner : MonoBehaviour
{
	public float fireRate = 1;
	public GameObject projectile;

	public Transform target;
	public int power;

	// NOTE: Offset needs to be increased if size of gunner's collider is expanded, or will destroy self
	public float offset = 0.1f;

	private float timeToFire;

	void Start()
	{
		timeToFire = fireRate;
	}

	void Update()
	{
		// count down, then fire
		timeToFire -= Time.deltaTime;
		if(timeToFire <= 0)
		{
			target = SelectTarget();
			
			if(target != null)
			{
				// aim returns the firing vector
				Vector2 vec = Aim();
				Fire(vec);
				timeToFire = fireRate;
			}
		}
	}

	private Vector2 Aim()
	{
		// get vector between gunner and target
		Vector2 v = (target.position - transform.position);
		v.Normalize();

		// adjust launch point of projectile to the direction + offset (to avoid hitting self)
		v.x += offset;
		v.y += offset;

		return v;
	}

	private Transform SelectTarget()
	{
		return target;
	}

	private void Fire(Vector2 vec)
	{
		GameObject proj = Instantiate(projectile, vec, transform.rotation);
		proj.GetComponent<Rigidbody2D>().AddForce(vec * power);
	}
}
