using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*public class turretScript : MonoBehaviour
{
    public float Range; //дистанция поражения
    public Transform Target;
    bool Detected = false;
    Vector2 Direction;
    public GameObject Gun;
    public GameObject bullet;
    public float FireRate;
    float nextTimeToFire = 0;
    public Transform Shootpoint;
    public float Force;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)transform.position;//напрвление от пушки до цели
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);//инфо о луче 
        if (rayInfo)//если тру значит есть что то
        {
            if (rayInfo.collider.gameObject.tag == "Player")
            {
                if (!Detected)
                    Detected = true;
            }
            else
            {
                if (Detected)
                    Detected = false;
            }
        }
        if (Detected)
        {
            Gun.transform.up = Direction;
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                shoot();
            }
        }
    }
    void shoot()
    {
        GameObject BulletIns = Instantiate(bullet, Shootpoint.position, Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}*/