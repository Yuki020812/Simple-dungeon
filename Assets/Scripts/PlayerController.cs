using BehaviorDesigner.Runtime.Tasks.Unity.UnityInput;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rd;
    private Animator anim;
    private BoxCollider2D coll;
    public float runSpeed;
    public float jumpForce;
    public float fallMultiplier;
    public float lowJumpMultiplier;
    [Header("CD的UI组件")] 
    public float dashTime;//dash时长
    private float dashTimeLeft;//冲锋剩余时间
    private float lashDash = -10f;//上一次dash时间点
    public float dashCoolDown;
    public float dashSpeed;
    private float faceDirection;
    public LayerMask Ground;
    PlayerAttack playerAttack;
    private bool isGround = true;
    private bool isDashing;
    private bool isOneWayPlatform = false;
    private bool falling = false;
    private int jumpAmount;
    private int maxJumpAmount;

    public int Damage = 1;

    private void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        playerAttack = GetComponentInChildren<PlayerAttack>();
        jumpAmount = 0;
        maxJumpAmount = 2;
    }

    private void Update()
    {
        if (GameController.isGameAlive)
        {
            CheckGround();
            Flip();
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (Time.time >= (lashDash + dashCoolDown))
                {
                    ReadyToDash();
                }
            }
            Jump();
            ChangeAnimator();
        }
    }


    private void FixedUpdate()
    {
        Run();
        Dash();
    }

    void Flip()
    {
        bool isPlayerHasSpeedX = Mathf.Abs(rd.velocity.x) > Mathf.Epsilon;
        if (isPlayerHasSpeedX)
        {
            if (rd.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0,0,0);
            }

            if (rd.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0,180,0);
            }
        }
    }
    
    void Run()
    {
        float moveDir = Input.GetAxis("Horizontal"); 
        faceDirection = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("Speed",Mathf.Abs( moveDir));
        // if (faceDirection != 0)
        // {
        //     transform.localScale = new Vector2(faceDirection, 1);
        // }
        rd.velocity = new Vector2 (moveDir*runSpeed*Time.deltaTime, rd.velocity.y);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.C)&&!Input.GetKey(KeyCode.DownArrow))
        {
            if (jumpAmount == 0 )
            {
                jumpAmount++;
                //isGround = false;
                anim.SetBool("Ground", isGround);
                rd.velocity = new Vector2(rd.velocity.x, jumpForce * Time.deltaTime);
                rd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            else if(jumpAmount >0  && jumpAmount<maxJumpAmount)
            {
                jumpAmount++;
                //isGround = false;
                anim.SetBool("Ground", isGround);
                //rd.velocity = new Vector2(rd.velocity.x, jumpForce * Time.deltaTime);
                rd.velocity = new Vector2(rd.velocity.x, 0);
                rd.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
            }
        }
        if (rd.velocity.y < 0)
        {
            rd.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rd.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rd.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void CheckGround()
    {
        isGround = coll.IsTouchingLayers(LayerMask.GetMask("Ground"))||
                            coll.IsTouchingLayers(LayerMask.GetMask("OneWayPlatform"));
        isOneWayPlatform =  coll.IsTouchingLayers(LayerMask.GetMask("OneWayPlatform"));
    }

    void Dash()
    {
        if (isDashing)
        {
            if (dashTimeLeft > 0)
            {
                if (rd.velocity.y > 0 && !isGround)
                {
                    rd.velocity = new Vector2(dashSpeed*faceDirection,jumpForce);
                }

                rd.velocity = new Vector2(dashSpeed * faceDirection, rd.velocity.y);

                dashTimeLeft -= Time.deltaTime;

                ShadowPool.instance.GetFormPool();
                
            }

            if (dashTimeLeft <= 0)
            {
                isDashing = false;
                if (!isGround)
                {
                    rd.velocity = new Vector2(dashSpeed * faceDirection, jumpAmount);
                }
            }
        }
    }

    void ReadyToDash()
    {
        isDashing = true;
        
        dashTimeLeft = dashTime;

        lashDash = Time.time;
    }
    
    void Attack()
    {
        playerAttack.AttackHitBox.enabled = true;
    }

    void ExitAttack()
    {
        playerAttack.ExitAttack();
    }

    void ChangeAnimator()
    {
        anim.SetFloat("VerticalSpeed", rd.velocity.y);
        //if (coll.IsTouchingLayers(Ground)==false&&rd.velocity.y<0)
        //{
        //    falling = true;
        //}
        if (!isGround && rd.velocity.y < 0)
        {
            falling = true;
        }
        //if (coll.IsTouchingLayers(Ground) && falling)
        //{
        //    jumpAmount = 0;
        //    falling=false;
        //    isGround = true;
        //    anim.SetBool("Ground", isGround);
        //}
        if (isGround && falling)
        {
            jumpAmount = 0;
            falling = false;
            isGround = true;
            anim.SetBool("Ground", isGround);
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Enemy"))
    //    {
    //        collision.GetComponent<Enemy>().TakeDamage(Damage);
    //    }
    //}
}