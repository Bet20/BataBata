using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_Behavior : MonoBehaviour
{
    public Transform finishLine;
    private float speed = 1.0f;
    private float rotation_rate = 00.05f;
    public float RotationAmount;
    private Vector3 targetDir;
    public void RocketFireStart() {
        RotationAmount += rotation_rate;
    }

    public void RocketFireStop() {
        RotationAmount = 0;
    }

    public void FaceUpward() {
        transform.rotation = Quaternion.Euler(-90,0,0);
    }

    public void FaceForward() {
        transform.Rotate(new Vector3(0,0,1) * -90, Space.Self);
    }
    void Start()
    {   
        RotationAmount = rotation_rate;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDir = finishLine.position - transform.position;
        targetDir.y = 0;
        //Vector3 lookDir = Vector3.RotateTowards(transform.forward, targetDir, speed * Time.deltaTime, 0.0f);
        var rotation = Quaternion.LookRotation(targetDir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed);

        transform.Rotate(new Vector3(0,0,1) * RotationAmount, Space.Self);
    }
}
