using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHiding : MonoBehaviour
{
    private Rigidbody2D rb;
    private float dirX;
    private SpriteRenderer rend;
    private bool canHide = false;
    private bool hiding = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();

    }
    private void Update()
    {
        if (canHide && Input.GetKeyDown("z"))
        {
            Physics2D.IgnoreLayerCollision(8, 9, true);
            rend.sortingOrder = 0;
            hiding = true;
        }

        else
        {
            Physics2D.IgnoreLayerCollision(8, 9, false);
            rend.sortingOrder = 2;
            hiding = false;
        }
    }
    private void FixedUpdate()
    {
        if (!hiding)
            rb.velocity = new Vector2(dirX, rb.velocity.y);
        else
            rb.velocity = Vector2.zero;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Bush"))
        {
            canHide = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Bush"))
        {
            canHide = false;
        }
    }
}