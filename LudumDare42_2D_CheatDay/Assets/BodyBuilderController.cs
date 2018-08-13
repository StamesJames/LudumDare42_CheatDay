using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyBuilderController : MonoBehaviour {

    public bool walking=true;
    public bool eating=false;
    public bool pow=false;
    public float speed = 10f;
    public GameObject cupcace;
    public GameObject bigPlayer;
    public float eatTime = 4f;
    public AudioBodyBuilder audioPlayer;

    private Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponentInChildren<Animator>();
        audioPlayer.OhYeah();
        Time.timeScale = 1f;
	}
	
	// Update is called once per frame
	void Update () {

        if (walking)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
            anim.SetBool("walking", true);
        }

        if (eating)
        {
            anim.SetBool("eating", true);
            if (eatTime <=0)
            {
                eating = false;
                pow = true;
            }
            else
            {
                eatTime -= Time.deltaTime;
            }
        }

        if (pow)
        {
            audioPlayer.Pow();
            bigPlayer.SetActive(true);
            Destroy(cupcace);
            Destroy(gameObject);
        }

        

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Food"))
        {
            walking = false;
            eating = true;
        }
    }
}
