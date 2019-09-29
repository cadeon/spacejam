using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBox : MonoBehaviour
{
	public AudioSource boom;
    public AudioSource scream;

    public void Scream()
    {
        scream.Play();
    }

	public void GoBoom()
	{
		boom.Play();
	}


}
