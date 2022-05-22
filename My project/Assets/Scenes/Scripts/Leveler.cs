using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leveler : MonoBehaviour
{
    public bool isDown = false;
    public Transform levelerUp;
    public Sprite levelerDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DownLeveler()
    {
        isDown = true;
        GetComponent<SpriteRenderer>().sprite = levelerDown;
    }
}
