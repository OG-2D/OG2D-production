using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rd;
    [Range(0,10f)]public float speed = 5f;
    [Range(0, 15f)] public float jumpHeight = 10f;
    public Transform groundCheck;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        CheckGroun();
    }

    private void FixedUpdate()
    {
        rd.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rd.velocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            rd.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
    }

    void Flip()
    {
        transform.localRotation = Input.GetAxis("Horizontal") > 0 ? Quaternion.Euler(0, 0, 0) : Quaternion.Euler(0, 180, 0);
    }

    void CheckGroun()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position,0.2f);
        isGrounded = colliders.Length > 1;
    }
}
