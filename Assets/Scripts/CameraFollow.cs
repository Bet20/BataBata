using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform transform_player;
	private ArrayList CameraPerspective;

	public float controllerSensitivity = 0.5f;
	public float mouseSensitivity = 1f;
	private float currentYaw = 0f;
	private float currentPitch = 0f;
	private int currentCameraPerspective = 2;
	private Vector3 offset;

	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		var offset_a = new Vector3(0, 3f, -8f);
		offset = offset_a;
		var offset_b = new Vector3(0, 10f, -18f);
		var offset_c = new Vector3(0, 12f, -20f);
		CameraPerspective = new ArrayList();
		CameraPerspective.Add(offset_a);
		CameraPerspective.Add(offset_b);		
		CameraPerspective.Add(offset_c);
	}
	// Update is called once per frame
	void Update()
	{
		transform.position = Vector3.Lerp(transform.position, transform_player.position + offset, 0.1f);
		// Get mouse movement
		float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
		float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;


		float controllerX = Input.GetAxis("RightStickX") * controllerSensitivity;
        float controllerY = Input.GetAxis("RightStickY") * controllerSensitivity;

		// Update camera angles based on mouse movement
		currentYaw += mouseX + controllerX;
		currentPitch -= mouseY - controllerY;
		currentPitch = Mathf.Clamp(currentPitch, -20f, 40f); // Limit pitch angle to prevent camera flipping

		// Update camera position and rotation
		UpdateCameraPosition();
		UpdateCameraRotation();

		if (Input.GetKeyDown(KeyCode.C)) {
			currentCameraPerspective = (currentCameraPerspective + 1) % 3;
			Debug.Log(currentCameraPerspective);
			offset = (Vector3) CameraPerspective[currentCameraPerspective];
		}
	}

	void UpdateCameraPosition()
	{
		Vector3 _offset = Quaternion.Euler(currentPitch, currentYaw, 0f) * offset;
		transform.position = transform_player.position + _offset;
	}

	void UpdateCameraRotation()
	{
		transform.LookAt(transform_player.position);
	}
}
