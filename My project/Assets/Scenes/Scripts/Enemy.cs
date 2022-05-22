using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 2;
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerScript1>().RecountHP(-1); // в момент касания снимается 1 жизнь
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x, 10f); // отталкивание персонажа прыжком
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GetComponent<Animator>().SetBool("death", true);
        Invoke(nameof(Destroy), 0.8f);
        //Destroy(gameObject);
    }

    void Destroy() => Destroy(gameObject);
}
