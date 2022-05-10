using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPatrolMob : MonoBehaviour
{
    public float speed = 1f;
    public bool moveLeft = true;
    public Transform groundDetect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.left);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetect.position, Vector2.down, 0.3f);

        if (!groundInfo.collider)
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
