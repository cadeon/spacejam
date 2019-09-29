using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBox : MonoBehaviour
{
	public AudioSource boom;

	public void GoBoom()
	{
		boom.Play();
	}


}
