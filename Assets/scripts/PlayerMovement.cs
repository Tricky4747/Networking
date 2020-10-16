using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    private float moveinput;
    private Rigidbody2D rb;
    private bool facingright = true;
    private bool isgrounded;
    public Transform groundcheck;
    public float checkradius;
    public LayerMask whatisground;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isgrounded == true)
        {
            rb.velocity = Vector2.up * jumpforce;
            anim.SetTrigger("takeoff");
        }
        if (isgrounded == true)
        {
            anim.SetBool("isjumping", false);
        }
        else if (isgrounded == false)
        {
            anim.SetBool("isjumping", true);
        }
    }
    void FixedUpdate()
    {
        moveinput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveinput * speed, rb.velocity.y);
        isgrounded = Physics2D.OverlapCircle(groundcheck.position, checkradius, whatisground);

        if (facingright == false && moveinput > 0)
        {
            flip();
        }
        else if (facingright == true && moveinput < 0)
        {
            flip();
        }
        if (moveinput == 0)
        {
            anim.SetBool("isrunning", false);
        }
        else
        {
            anim.SetBool("isrunning", true);
        }
    }
    void flip()
    {
        facingright = !facingright;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
