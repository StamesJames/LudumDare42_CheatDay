using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

    public AudioSource audioSource;



    public AudioClip einatmen;
    public AudioClip ausatmen;
    public AudioClip step;
    public AudioClip landing;
    public AudioClip jump;
    public AudioClip nomNom;
    public AudioClip poop;
    public AudioClip poopDenied;
    public AudioClip mmh;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Einatmen()
    {
        audioSource.PlayOneShot(einatmen);
    }

    public void Ausatmen()
    {
        audioSource.PlayOneShot(ausatmen);
    }


    public void Step()
    {
        audioSource.PlayOneShot(step);
    }

    public void Landing()
    {
        audioSource.PlayOneShot(landing);
    }

    public void Jump()
    {
        audioSource.PlayOneShot(jump);
    }

    public void NomNom()
    {
        audioSource.PlayOneShot(nomNom);
    }

    public void Poop()
    {
        audioSource.PlayOneShot(poop);
    }

    public void PoopDenied()
    {
        audioSource.PlayOneShot(poopDenied);
    }

    public void Mmh()
    {
        audioSource.PlayOneShot(mmh);
    }

}
