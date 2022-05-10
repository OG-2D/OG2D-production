using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerScript1>().RecountHP(-1); // в момент касания снимается 1 жизнь
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x, 10f); // отталкивание персонажа прыжком
        }
    }
}
