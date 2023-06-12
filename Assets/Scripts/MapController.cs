using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
	public float max_rotation = 10f;
	public float ver_in;
	public float hor_in;
    public float lerp_multiplier = 0.5f; 

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		ver_in = Input.GetAxisRaw("Vertical") * max_rotation;
		hor_in = Input.GetAxisRaw("Horizontal") * max_rotation;
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(ver_in, 0, -hor_in)), lerp_multiplier);
		// transform.Rotate(new Vector3(1,0,0) * ver_in * rotation_multiplier, Space.World);
		// transform.Rotate(new Vector3(0,0,1)  * hor_in * rotation_multiplier, Space.World);
	}
}
