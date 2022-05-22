using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPlatfotm : MonoBehaviour
{
    public Transform[] points;
    public float speed = 1f;
    int i = 1;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(points[0].position.x, points[0].position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float posX = transform.position.x;
            float posY = transform.position.y;
            float colX = collision.gameObject.transform.position.x;
            float colY = collision.gameObject.transform.position.y;
            float colZ = collision.gameObject.transform.position.z;
            transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);

            collision.gameObject.transform.position = new Vector3(colX + transform.position.x - posX, colY + transform.position.y - posY, colZ);//для того чтобы двигаться вместе с пл-ой

            if (transform.position == points[i].position)
            {
                if (i < points.Length - 1)
                    i++;
                else
                    i = 0;
            }
        }
    }

    
}
