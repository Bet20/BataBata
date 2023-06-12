using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballRightArm : MonoBehaviour
{
    public float force = 100f;
    public Transform rotator;

    void Start()
    {
        
    }

    public void Shoot() {
        Debug.Log("Shoot");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) {
            Shoot();
        }
    }

    private void OnCollisionEnter(Collision other) {
        Vector3 contact_point = other.contacts[0].normal;
        Debug.Log(other);

        other.rigidbody.AddForceAtPosition(contact_point*force, contact_point, ForceMode.Impulse);
    }
}
