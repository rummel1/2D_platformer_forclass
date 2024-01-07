using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator playerAnimator;
    public static float moveSpeed = 8f;
    public static float jumpSpeed = 250f, jumpFrequency=0.1f, nextJumpTime;

    bool facingRight = true;

    public bool isGrounded = false;
    public bool doubleJump, doublejumpkont=false;
    //public bool attack = false;
    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        HorizontalMove();
        OnGroundCheck();
        if (playerRB.velocity.x < 0 && facingRight)
        {
            FlipFace();
        }
        else if (playerRB.velocity.x > 0 && !facingRight)
        {
            FlipFace();
        }
        if (Input.GetKeyDown("w") && isGrounded && (nextJumpTime<Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
           Jump();
            doubleJump = true;
            doublejumpkont = false;
            playerAnimator.SetBool("doublejump", doublejumpkont);



        }
        else if (Input.GetKeyDown("w") && doubleJump==true && (nextJumpTime < Time.timeSinceLevelLoad))
        {
            Debug.Log("eren");
            Jump();
            doublejumpkont = true;
            doubleJump = false;
            playerAnimator.SetBool("doublejump", doublejumpkont);
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            

        }
    }
    void HorizontalMove()//sað ve sol hareket
    {
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerRB.velocity.y);
        playerAnimator.SetFloat("playerSpeed", Mathf.Abs(playerRB.velocity.x));
    }
    void FlipFace()//saða sola giderken yüzün nereye bakacaðýný anlayan fonksiyon
        {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
        }
    void Jump()
    {
       playerRB.AddForce(new Vector2(0, jumpSpeed));
                
    }
    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
        playerAnimator.SetBool("isgrounded", isGrounded);
    }
}
