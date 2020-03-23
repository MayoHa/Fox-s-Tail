using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    public Transform leftPos, rightPos;
    public float moveTime, waitTime;
    public SpriteRenderer sr;

    private float moveTimeCounter, waitTimeCounter;
    private bool isMoveRight;
    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        isMoveRight = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveTimeCounter = Random.Range(moveTime * 0.75f, moveTime * 1.25f);
        waitTimeCounter = Random.Range(waitTime * 0.75f, waitTime * 1.25f);
        leftPos.parent = null;
        rightPos.parent = null;
    }

    // Update is called once per frame
    private void Update()
    {
        MoveAround();
        //make enemy move more randomly
        if (moveTimeCounter > 0)
        {
            moveTimeCounter -= Time.deltaTime;
        }
        else
        {
            if (waitTimeCounter > 0)
            {
                waitTimeCounter -= Time.deltaTime;
            }
            else
            {
                moveTimeCounter = Random.Range(moveTime * 0.75f, moveTime * 1.25f);
                waitTimeCounter = Random.Range(waitTime * 0.75f, waitTime * 1.25f);
            }
        }

        //Flip X
        if (rb.velocity.x > 0)
        {
            sr.flipX = true;
        }
        else if (rb.velocity.x < 0)
        {
            sr.flipX = false;
        }

        //animation
        anim.SetBool("isMoving", rb.velocity.x != 0);
        if (rb.velocity.x == 0)
        {
            //GetComponent<Rigidbody2D>().bodyType.CompareTo(2);
        }
    }

    //Controll enemy move around
    private void MoveAround()
    {
        if (moveTimeCounter > 0)
        {
            if (isMoveRight)
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                if (transform.position.x > rightPos.position.x)
                {
                    isMoveRight = false;
                }
            }
            else
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                if (transform.position.x < leftPos.position.x)
                {
                    isMoveRight = true;
                }
            }
        }
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }
}