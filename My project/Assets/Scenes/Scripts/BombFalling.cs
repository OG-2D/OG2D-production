using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFalling : MonoBehaviour
{
    float speedFalling = 6f;
    float timeToDisable = 8f;
    // Start is called before the first frame update
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

}
