using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    private float movement;
    private Rigidbody2D body;
    private Transform trans;
    private bool facingRight;
    private bool jump;
    private Animator anim;
    private int speedFactor;
    private CircleCollider2D circleCollider;
    private bool grounded;

    // Use this for initialization
    void Start() {

        body = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
        circleCollider = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
        facingRight = true;
        jump = false;
        grounded = false;
        speedFactor = 1;
    }

    // Update is called once per frame
    void Update() {

        movement = Input.GetAxis("Horizontal");

        if (!jump)
            jump = Input.GetButtonDown("Jump");
    }

    void FixedUpdate() {

        grounded = isGrounded();

        if (jump)
        {
            if (grounded)
            {
                body.velocity = new Vector2(body.velocity.x, 3);
            }
            jump = false;
        }

        if (movement != 0 && grounded)
        {
            if (movement < 0 && facingRight)
                Flip();
            else if (movement > 0 && !facingRight)
                Flip();

            body.velocity = new Vector2(movement * speedFactor, body.velocity.y);
            movement = 0;
        }

        anim.SetFloat("Speed", Mathf.Abs(body.velocity.x));
        anim.SetBool("Grounded", grounded);
        anim.SetBool("FacingRight", facingRight);
    }

    bool isGrounded()
    {
        return Physics2D.Raycast(body.position, Vector2.down, circleCollider.radius + 0.01f);
    }

    void Flip()
    {
        trans.localScale = Vector3.Scale(trans.localScale, new Vector3(-1, 1, 1));
        facingRight = !facingRight;
    }

}
