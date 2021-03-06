using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("Player") && health > 0)
        {
            collision.gameObject.GetComponent<PlayerScript1>().RecountHP(-1); // ? ?????? ??????? ????????? 1 ?????
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x, 10f); // ???????????? ????????? ???????
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Die();
    }

    void Die()
    {
        GetComponent<Animator>().SetBool("death", true);
        Invoke(nameof(Destroy), 0.8f);
    }

    void Destroy() => Destroy(gameObject);
}
