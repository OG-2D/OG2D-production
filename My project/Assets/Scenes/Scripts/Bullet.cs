using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private readonly float speed = 18f;
    public Rigidbody2D rb;
    public int damage = 1;
    readonly float timeToDisable = 0.6f;

    void Start() => StartCoroutine(SetDisable());

    public void Update() => rb.velocity = transform.right * speed;

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
            enemy.TakeDamage(damage);
        Destroy(gameObject);
    }

    IEnumerator SetDisable()
    {
        yield return new WaitForSeconds(timeToDisable);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StopCoroutine(SetDisable());
        Destroy(gameObject);
    }
}
