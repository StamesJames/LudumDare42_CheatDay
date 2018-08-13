using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour {


    public float spareTime;

    private float activateTime;

    private void Start()
    {
        activateTime = Time.time + spareTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player") && activateTime <= Time.time)
        {
            GameManager.Instance.DieBecausePoop();
            Destroy(gameObject);
        }
    }


}
