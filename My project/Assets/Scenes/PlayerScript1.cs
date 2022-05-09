using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript1 : MonoBehaviour
{
    Rigidbody2D player;
    public float speed;
    public float jumpHeight;
    public Transform groundCheck;
    bool isGrounded;
    public float jumpForce = 7f;
    new Animator animation;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        Jump();
        CheckGroun();
        if (Input.GetAxis("Horizontal") == 0 && isGrounded)
            animation.SetInteger("State", 1);
        else
        {
            Flip();
            if (isGrounded)
                animation.SetInteger("State", 2);
        }
    }

    private void FixedUpdate()
    {
        player.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, player.velocity.y);
    }
    void Flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        if (Input.GetAxis("Horizontal") < 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    void CheckGroun()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, 0.1f);
        isGrounded = colliders.Length > 1;
        if (!isGrounded)
            animation.SetInteger("State", 3);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            player.velocity = new Vector2(player.velocity.x, jumpForce);
    }
}
