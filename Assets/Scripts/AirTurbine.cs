using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirTurbine : MonoBehaviour
{
    public int force = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other) {
        other.GetComponent<Rigidbody>().AddForce(Vector3.up * force, ForceMode.Impulse);
    }

}
