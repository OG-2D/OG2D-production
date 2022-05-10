using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPatrolMob : MonoBehaviour
{
    public Transform start;
    public Transform finish;
    private readonly float speed = 4f;
    private readonly float waitTime = 0.5f;
    bool canGo = true;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(start.position.x, finish.position.y, transform.position.z);
    }

    // Update is called once per frame
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
        canGo = true;
    }
}
