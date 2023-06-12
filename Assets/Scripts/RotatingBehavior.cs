using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingBehavior : MonoBehaviour
{
    [Range(-1, 1)]
    public int direction = 1;
    public float speed = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f,0f,direction * speed));
    }
}
