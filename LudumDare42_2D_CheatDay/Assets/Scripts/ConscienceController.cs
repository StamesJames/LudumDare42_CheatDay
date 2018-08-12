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

    #endregion

    #region private variables

    private Vector3 direction;
    private Rigidbody2D rb;

    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        maxSpeed += Time.deltaTime * speedGain;
        moveForce += Time.deltaTime * moveForceGain;
        direction = ( player.transform.position - transform.position).normalized;
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
