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

    [HideInInspector]
    public bool isInput;//判断是否接受输入

    [Tooltip("受伤回退在X、Y的力分量")]
    public float knockBackForceX, knockBackForceY;

    [Tooltip("游戏结束时走路的速度")]
    public float MoveOutSpeed;

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
        isInput = true;
        isKnockBack = false;
        knockBackCounter = knockBackLength;
    }

    // Update is called once per frame
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(checkIsGroundPoint.position, .2f, ground);

        if (!PauseController.instance.isPaused && isInput)
        {
            //{
            if (!isKnockBack)
            {
                //Move left and right
                rb.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), rb.velocity.y);

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
                        MusicController.instance.PlayAudio(10);
                    }
                    else
                    {
                        if (canDoubleJump)
                        {
                            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                            MusicController.instance.PlayAudio(10);
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

            //FullDown
            PlayerFulDown.instance.DealFullDownDied();
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

    //When the level Completed ,the Player run along the road
    public void LevelEndRun()
    {
        rb.velocity = new Vector2(MoveOutSpeed, rb.velocity.y);
    }
}