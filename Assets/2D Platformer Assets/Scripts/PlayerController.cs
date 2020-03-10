using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed;
    public float jumpSpeed;
    public float forceBackAll;

    [Tooltip("受伤回退状态时间")]
    public float knockBackLength;

    public Transform checkIsGroundPoint;
    public LayerMask ground;
    public bool isKnockBack;

    [Tooltip("受伤回退在X、Y的力分量")]
    public float knockBackForceX, knockBackForceY;

    private bool isGrounded;
    private bool canDoubleJump;

    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer rd;
    private float knockBackCounter;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rd = GetComponent<SpriteRenderer>();
        isKnockBack = false;
        knockBackCounter = knockBackLength;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!isKnockBack)
        {
            //Move left and right
            rb.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), rb.velocity.y);

            isGrounded = Physics2D.OverlapCircle(checkIsGroundPoint.position, .2f, ground);

            if (isGrounded)
            {
                canDoubleJump = true;
            }

            //Jump
            if (Input.GetButtonDown("Jump"))
            {
                if (isGrounded)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                }
                else
                {
                    if (canDoubleJump)
                    {
                        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                        canDoubleJump = false;
                    }
                }
            }

            //Flip
            if (rb.velocity.x > 0)
            {
                rd.flipX = false;
            }
            else if (rb.velocity.x < 0)
            {
                rd.flipX = true;
            }
        }
        else
        {
            ForceBack();
            knockBackCounter -= Time.deltaTime;
            if (knockBackCounter < 0)
            {
                isKnockBack = false;
                knockBackCounter = knockBackLength;
            }
        }

        //Animation
        anim.SetFloat("MoveSpeed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("IsGround", isGrounded);
        anim.SetBool("IsHurt", isKnockBack);
    }

    //take the player back when he is hurt
    public void ForceBack()
    {
        if (knockBackCounter == knockBackLength)
            rb.velocity = forceBackAll * (-rb.velocity.normalized + new Vector2(knockBackForceX, knockBackForceY));
    }
}