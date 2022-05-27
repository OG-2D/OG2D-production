using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPatrolMob : MonoBehaviour
{
    public Transform start;
    public Transform finish;
    public float speed;
    private readonly float waitTime = 0.5f;
    bool canGo = true;

    void Start() => gameObject.transform.position = new Vector3(start.position.x, finish.position.y, transform.position.z);

    void Update()
    {
        if (canGo)
            transform.position = Vector3.MoveTowards(transform.position, start.position, speed * Time.deltaTime);
        if (transform.position == start.position)
        {
            (finish, start) = (start, finish);
            canGo = false;
            StartCoroutine(WaitingOnControlPoint());
        }
    }

    IEnumerator WaitingOnControlPoint()
    {
        yield return new WaitForSeconds(waitTime);
        transform.eulerAngles = transform.rotation.y == 0 ? new Vector3(0, transform.rotation.y + 180, 0) : Vector3.zero;
        canGo = true;
    }
}
