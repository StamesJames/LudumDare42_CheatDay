using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStomachController : MonoBehaviour {

    public float Speed = 10f;
    public float directionChangeRate = 5f;

    private Vector2 startVelocity;
    private Rigidbody2D rb;
    private float nextDirectionChange;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        startVelocity = Random.insideUnitCircle.normalized;
        rb.velocity = startVelocity * Speed;
        nextDirectionChange = Time.time + directionChangeRate;
	}
	
	// Update is called once per frame
	void Update () {
        if (nextDirectionChange <= Time.time)
        {
            rb.velocity = Random.insideUnitCircle.normalized * Speed;
            nextDirectionChange = Time.time + directionChangeRate;

        }
    }
}
