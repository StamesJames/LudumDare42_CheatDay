using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {


    #region public variables

    public float jumpForce = 100f;
    public float walkForce = 100f;
    public float walkDrag = 0.001f;
    public float eatingRate = 10f;
    public float poopAmount = 10f;
    public float lowJumpGravity = 0.8f;
    public float highFallingGravity = 1.25f;
    public LayerMask whatIsGround;
    public LayerMask whatIsFood;
    public Transform groundCheck;
    public Transform poopSpawn;
    public GameObject actionButton;
    public GameObject stomachMenu;
    public GameObject mainCamera;
    public GameObject stomachSpawnPoint;
    public GameObject poopObject;
    public Slider progressBar;
    public Vector3 stomachMenuOffset;
    public float maxSpeed = 10f;
    public float jumpSpeedThreshhold = 0.25f;

    [HideInInspector]
    public bool stomachMenuActive;
    #endregion

    #region not implemented
    [HideInInspector]
    public float runForce;
    #endregion

    #region privat variables
    private Rigidbody2D rb;
    private bool grounded;
    private bool inputActive = true;
    private bool jump;
    private bool stomachMode = false;
    private bool stomachMenuInput;
    private bool eatingInput;
    private bool stopEatingInput;
    private bool eating;
    private bool infrontFood;
    private float horizontalInput;
    private CharacterMover mover;
    private Food currentFood;
    private bool facingRight = true;


    #endregion

    #region Animator
    private Animator anim;

    private int hashHorizontalSpeed = Animator.StringToHash("HorizontalSpeed");
    private int hashVerticalSpeed = Animator.StringToHash("VerticalSpeed");
    private int hashEating = Animator.StringToHash("Eating");
    private int hashLanding = Animator.StringToHash("Landing");
    private int hashPoop = Animator.StringToHash("Poop");
    private int hashPoopDenied = Animator.StringToHash("PoopDenied");
    #endregion

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        mover = GetComponent<CharacterMover>();
        anim = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (!stomachMenuActive)
        {
            if (Input.GetButton("Jump") && rb.velocity.y > jumpSpeedThreshhold)
            {
                rb.gravityScale = lowJumpGravity;
            }
            else if (rb.velocity.y < jumpSpeedThreshhold)
            {
                rb.gravityScale = highFallingGravity;
            }
            else
            {
                rb.gravityScale = 1f;
            }

            if (!eating)
            {
            horizontalInput = Input.GetAxis("Horizontal");

            }
            else
            {
                horizontalInput = 0f;
            }

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }

            if (Input.GetButtonDown("Poop") && !eating)
            {
                Poop();
            }

            if (Input.GetButtonDown("Stomach"))
            {
                stomachMenuActive = true;
                if (currentFood != null)
                {
                    currentFood.StopEating();
                    progressBar.value = currentFood.GetCurrentProgress();
                }
            }

            if (facingRight && horizontalInput < 0)
            {
                Flip();
            }
            else if (!facingRight && horizontalInput > 0)
            {
                Flip();
            }

            anim.SetBool(hashEating, eating);

        }
        else if (stomachMenuActive)
        {
            horizontalInput = 0f;

            if (rb.velocity.y < jumpSpeedThreshhold)
            {
                rb.gravityScale = highFallingGravity;
            }
            else
            {
                rb.gravityScale = 1f;
            }

            if (Input.GetButtonDown("Stomach"))
            {
                stomachMenuActive = false;
            }

            anim.SetBool(hashEating, false);
        }

        if (!grounded && Physics2D.Linecast(groundCheck.position, groundCheck.position, whatIsGround))
        {
            anim.SetTrigger(hashLanding);
            grounded = true;
        }
        else
        {
            grounded = Physics2D.Linecast(groundCheck.position, groundCheck.position, whatIsGround);
        }

        stomachMenuInput = Input.GetButtonDown("Stomach");
        stopEatingInput = Input.GetButtonUp("Eating");
        eatingInput = Input.GetButton("Eating");
        anim.SetFloat(hashHorizontalSpeed, Mathf.Abs(rb.velocity.x));
        anim.SetFloat(hashVerticalSpeed, rb.velocity.y);


	}

    private void FixedUpdate()
    {


        if (!stomachMenuActive)
        {

            if (!eating)
            {
                mover.Walk(horizontalInput * walkForce);
            }

            if (jump && grounded && !eating)
            {
                mover.Jump(jumpForce);
                jump = false;
            }

            if (eatingInput && infrontFood)
            {
                eating = true;
                actionButton.SetActive(false);
                progressBar.gameObject.SetActive(true);
                progressBar.value = currentFood.GetCurrentProgress(); 
                if (currentFood.EatMe(eatingRate * Time.deltaTime))
                {
                    Instantiate(currentFood.stomachObject, stomachSpawnPoint.transform);
                    Destroy(currentFood.gameObject);
                    Debug.Log("fertig gegessen");
                }
            }
            else
            {
                if (progressBar.gameObject.activeSelf)
                {
                    progressBar.gameObject.SetActive(false);
                }
                eating = false;
            }

            if (stopEatingInput && currentFood != null)
            {
                currentFood.StopEating();
            }

            if (infrontFood)
            {
                if (!actionButton.activeSelf && !eating)
                {
                    actionButton.SetActive(true);
                }
            }

        }
        else if (stomachMenuActive)
        {

        }

        if (Mathf.Abs(horizontalInput) < 0.1f)
        {
            rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, walkDrag * Time.deltaTime), rb.velocity.y);
        }
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), rb.velocity.y);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Equals("Food"))
        {
            infrontFood = true;
        }

        if (currentFood == null)
        {
            currentFood = collision.gameObject.GetComponent<Food>();
        }
        else if ((currentFood.transform.position - transform.position).magnitude > (collision.transform.position - transform.position).magnitude)
        {
            currentFood = collision.gameObject.GetComponent<Food>();
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("Food"))
        {
            infrontFood = false;
        }

        if (currentFood != null && currentFood == collision.GetComponent<Food>())
        {
            currentFood.StopEating();
            actionButton.SetActive(false);
            currentFood = null;
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void Poop()
    {
        if (GutManager.Instance.IsEmpty())
        {
            anim.SetTrigger(hashPoopDenied);
        }
        else
        {
            anim.SetTrigger(hashPoop);
            Instantiate(poopObject, poopSpawn.position, Quaternion.identity);
            GutManager.Instance.Poop(poopAmount);
        }
    }

}

