using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    float lenght;
    float startPosition;
    public GameObject camera;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        var temp = camera.transform.position.x * (1-parallaxEffect);
        var distantion = camera.transform.position.x * parallaxEffect;
        transform.position = new Vector3(startPosition + distantion, transform.position.y, transform.position.z);
        if (temp > startPosition + lenght)
            startPosition += lenght;
        else if (temp < startPosition - lenght)
            startPosition -= lenght;
    }
}
