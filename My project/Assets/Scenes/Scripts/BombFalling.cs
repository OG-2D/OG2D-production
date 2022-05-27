using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFalling : MonoBehaviour
{
    readonly float speedFalling = 6f;
    readonly float timeToDisable = 6f;
    void Start() => StartCoroutine(SetDisable());

    // Update is called once per frame
    void Update() => transform.Translate(speedFalling * Time.deltaTime * Vector2.down);

    IEnumerator SetDisable()
    {
        yield return new WaitForSeconds(timeToDisable);
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StopCoroutine(SetDisable());
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerScript1 player = collision.GetComponent<PlayerScript1>();
        Enemy enemy = collision.GetComponent<Enemy>();
        if (player != null)
        {
            player.RecountHP(-1);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(collision.gameObject.GetComponent<Rigidbody2D>().velocity.x, 5f);
            Destroy(gameObject);
        }
        else if (enemy == null)
            Destroy(gameObject);
    }
}
