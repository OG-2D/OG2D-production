using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private readonly float speed = 15f;
    public Rigidbody2D rb;
    public int damage = 1;

    // Update is called once per frame
    public void Update() => rb.velocity = transform.right * speed;

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
            enemy.TakeDamage(damage);
        Destroy(gameObject);
    }
}
