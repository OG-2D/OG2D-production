using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpened = false;
    public Transform closedDoor;
    public Sprite openedDoor;

    public void UnLock()
    {
        isOpened = true;
        GetComponent<SpriteRenderer>().sprite = openedDoor;
    }
}
