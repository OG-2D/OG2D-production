using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    readonly float destroyingDelay = 2f;
    readonly float fallStartingTime = 1f;
    void Start() => rb = GetComponent<Rigidbody2D>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke(nameof(CheckFall), 1f);
            Destroy(gameObject, 2f);
        }
    }

    void CheckFall() => rb.isKinematic = false;
}
