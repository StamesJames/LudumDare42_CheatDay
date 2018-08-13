using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBodyBuilder : MonoBehaviour {

    public AudioSource audioScource;

    public AudioClip step;
    public AudioClip ohYeah;
    public AudioClip krom;
    public AudioClip pow;

    public void Step()
    {
        audioScource.PlayOneShot(step);
    }


    public void OhYeah()
    {
        audioScource.PlayOneShot(ohYeah);
    }

    public void Krom()
    {
        audioScource.PlayOneShot(krom);
    }

    public void Pow()
    {
        audioScource.PlayOneShot(pow);
    }


}
