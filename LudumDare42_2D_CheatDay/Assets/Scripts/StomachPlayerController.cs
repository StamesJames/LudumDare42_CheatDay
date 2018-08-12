using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StomachPlayerController : MonoBehaviour
{

    #region public variables

    public PlayerController player;
    public float damage;
    public float attackRadius;
    public float speed;
    public LayerMask attackLayer;

    #endregion

    #region private variables

    private float horizontalInput;
    private float verticlInput;
    private bool attackInput;

    #endregion


    #region Animator

    private Animator anim;

    private int hashSpeed = Animator.StringToHash("Speed");
    private int hashAttack = Animator.StringToHash("Attack");

    #endregion

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticlInput = Input.GetAxisRaw("Vertical");

        if ( player.stomachMenuActive && Input.GetButtonDown("Jump"))
        {
            Attack(damage);
        }

        anim.SetFloat(hashSpeed, Mathf.Max(Mathf.Abs(horizontalInput),Mathf.Abs(verticlInput)));

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        
    }

    private void FixedUpdate()
    {
        if (player.stomachMenuActive)
        {
        transform.Translate(new Vector2(horizontalInput, verticlInput).normalized * speed * Time.deltaTime);
        }
    }

    private void Attack(float damage)
    {
        anim.SetTrigger(hashAttack);

        Collider2D[] targetColliders = Physics2D.OverlapCircleAll(transform.position, attackRadius, attackLayer);
        StomachAttackables target;

        foreach (Collider2D item in targetColliders)
        {
            target = item.GetComponent<StomachAttackables>();

            target.takeDamage(damage);

        }
    }

    private float CalculateDamage(Transform targetTransform)
    {
        float distance = (transform.position - targetTransform.position).magnitude;

        if (distance > attackRadius)
        {
            return 0f;
        }

        float calcDamage = damage * ((attackRadius - distance) / attackRadius) ;

        return Mathf.Max(0f, calcDamage);

    }

}
