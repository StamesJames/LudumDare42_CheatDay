using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour {


    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    public void Jump(float force)
    {
        rb.AddForce(transform.up * force);
    }

    public void Walk(float force)
    {
        rb.AddForce(transform.right * force);
    }
}
