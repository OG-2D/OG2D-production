using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    float speed = 1.5f;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        var position = target.position;
        position.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
    }
}
