using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConscienceController : MonoBehaviour {

    #region public variables

    public Transform player;
    public float maxSpeed;
    public float speedGain;
    public float moveForce;
    public float moveForceGain;
    public AudioSource audioSource;
    public float minVolumeRange = 100;
    public float maxVolumeRange = 30;


    private Vector3 ghostToPlayer;
    private float distance;

    #endregion

    #region private variables

    private Vector3 direction;
    private Rigidbody2D rb;

    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        maxSpeed += Time.deltaTime * speedGain;
        moveForce += Time.deltaTime * moveForceGain;

        ghostToPlayer = player.transform.position - transform.position;

        direction = ghostToPlayer.normalized;

        distance = ghostToPlayer.magnitude;

        if (distance <= maxVolumeRange)
        {
            audioSource.volume = 1f;
        }
        else if (distance >= minVolumeRange)
        {
            audioSource.volume = 0f;
        }
        else
        {
            audioSource.volume = (minVolumeRange - distance) / minVolumeRange;
        }

        Debug.Log("Distance is: " + distance);
        Debug.Log("volume is: " + audioSource.volume);



    }

    private void FixedUpdate()
    {
        rb.AddForce(direction * moveForce * Time.deltaTime);

        rb.velocity = rb.velocity.normalized * Mathf.Clamp(rb.velocity.magnitude, 0f, maxSpeed);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            GameManager.Instance.DieBecuaseConscience();

        }
    }


}
