using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPatrolMob : MonoBehaviour
{
    public float speed = 1f;
    public bool moveLeft = true;
    public Transform groundDetect;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.left);
        RaycastHit2D groundInfoDown = Physics2D.Raycast(groundDetect.position, Vector2.down, 0.3f);
        RaycastHit2D groundInfoAhead = Physics2D.Raycast(groundDetect.position, Vector2.left, 0.3f);

        if (!groundInfoDown.collider || (!groundInfoAhead.collider.CompareTag("Player") && groundInfoAhead.collider))
            if (moveLeft)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                moveLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveLeft=true;
            }
    }
}
