using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public bool isOpened = false;
    public Transform closedDoor;
    public Sprite openedDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnLock()
    {
        isOpened = true;
        GetComponent<SpriteRenderer>().sprite = openedDoor;
    }
}
