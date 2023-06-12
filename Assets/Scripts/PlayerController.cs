using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
public float moveSpeed = 5f; // Speed at which the ball moves
    public float rotationSpeed = 5f; // Speed at which the ball rotates
    public float mouseSensitivity = 2f; // Sensitivity of mouse movement

    private Rigidbody rb;
    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Lock cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Get mouse movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the ball left/right based on mouse movement
        transform.Rotate(Vector3.up * mouseX);

        // Rotate the camera up/down based on mouse movement
        Camera.main.transform.Rotate(Vector3.left * mouseY);
    }

    void FixedUpdate()
    {
        if (movement != Vector3.zero)
        {
            // Rotate the ball towards the movement direction
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime);
        }

        // Move the ball
        rb.AddForce(rb.position + transform.forward * moveSpeed);
    }
}
