using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator playerAnimator;
    public static float moveSpeed = 8f;
    public static float jumpSpeed = 223f, jumpFrequency=0f, nextJumpTime;

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
        if (DialogueManager.Instance.isDialogueActive)
        {
            playerRB.constraints = RigidbodyConstraints2D.FreezeRotation;
            playerRB.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
        else
        {
            playerRB.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
            playerRB.constraints = RigidbodyConstraints2D.FreezeRotation;
        }


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
        if (Input.GetKeyDown("w") && isGrounded)
        {
            Jump();
            doubleJump = true;
            doublejumpkont = false;
            playerAnimator.SetBool("doublejump", doublejumpkont);
            
        }
        else if (Input.GetKeyDown("w") && doubleJump==true)
        {
            Jump();
            doublejumpkont = true;
            doubleJump = false;
            playerAnimator.SetBool("doublejump", doublejumpkont);
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
        }
    }
    void HorizontalMove()
    {
        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerRB.velocity.y);
        playerAnimator.SetFloat("playerSpeed", Mathf.Abs(playerRB.velocity.x));
    }
    void FlipFace()
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
