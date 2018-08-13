using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStomachPlayer : MonoBehaviour {

    public AudioSource audioSource;

    public AudioClip jeah;


    public void Jeyh()
    {
        audioSource.PlayOneShot(jeah);
    }


}
