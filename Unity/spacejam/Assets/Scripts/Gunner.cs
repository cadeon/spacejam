using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner : MonoBehaviour
{
	public float fireRate = 1;
	public GameObject projectile;

	public Transform target;
	public int power;

	// reference to own satellite
	private Satellite satSelf;

	// NOTE: Offset needs to be increased if size of gunner's collider is expanded, or will destroy self
	public float offset = 0.1f;

	private float timeToFire;

	public TeamsManager teamsMngr;

	void Start()
	{
		timeToFire = fireRate;
		satSelf = GetComponent<Satellite>();
		teamsMngr = GameObject.FindGameObjectWithTag("TeamsManager").GetComponent<TeamsManager>();
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

		// v.x += transform.position.x;
		// v.y += transform.position.y;

		return v;
	}

	// need to select target from teams manager, because tags are unavailable and names are unreliable
	private Transform SelectTarget()
	{
		foreach(GameObject entity in teamsMngr.EnemyTeams(satSelf.team))
		{
			if(entity == null)
				continue;

			if(target == null)
			{
				target = entity.transform;
				continue;
			}
			else if(entity.transform.position.magnitude < target.position.magnitude)
			{
				target = entity.transform;
			}
		}

		Debug.Log(target.gameObject.name);

		return target;
	}

	private void Fire(Vector2 vec)
	{
		GameObject proj = Instantiate(projectile, (vec + new Vector2(transform.position.x, transform.position.y)), transform.rotation);
		proj.GetComponent<Rigidbody2D>().AddForce(vec * power);
	}
}
