using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBomberMob : MonoBehaviour
{
    public GameObject bomb;
    public Transform bombingPoint;
    public float bombingPeriod = 4f;
    // Start is called before the first frame update
    void Start()
    {
        bombingPoint.transform.position = new Vector3 (transform.position.x, transform.position.y - 1f, transform.position.z);
        StartCoroutine(Bombing());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Bombing()
    {
        yield return new WaitForSeconds(bombingPeriod);
        Instantiate(bomb, bombingPoint.transform.position, transform.rotation);
        StartCoroutine(Bombing());
    }
}
