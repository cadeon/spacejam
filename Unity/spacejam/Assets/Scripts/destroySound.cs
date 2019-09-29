using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class destroySound : MonoBehaviour
{
    public AudioClip destroyClip;

    void onDestroy()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.clip = destroyClip;
        audio.Play();
    }
}