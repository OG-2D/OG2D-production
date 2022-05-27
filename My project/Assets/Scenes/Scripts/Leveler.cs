using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leveler : MonoBehaviour
{
    public bool isDown = false;
    public Transform levelerUp;

    public void DownLeveler()
    {
        isDown = true;
        Destroy(gameObject);
    }
}
