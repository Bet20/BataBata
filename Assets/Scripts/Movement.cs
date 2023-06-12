using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
	// Start is called before the first frame update
	private enum RocketPositionState {
		Left,
		Up,
		Forward,
		Right,
	}


	Rigidbody _rb;
	public float force = 0.5f;
	public float jump_force = 20f;
	private bool is_grounded = true;
	public float vert_input;
	public float hor_input;
	public Transform cam;
	public Rocket_Behavior Rocket;
	public Transform left_rocket;
	public Transform right_rocket;
	private RocketPositionState rocket_curr_state;
	private float fuel = 100f;
	public  float curr_fuel = 100f;
	private float fuel_regain_ratio = 0.01f;
	public Scrollbar fuel_ui;
	public AudioSource sound_track_main;
	public AudioSource sound_track_interactive;
	public float velocity;
	private float timer;
	private Vector3 lastPosition;
	private float friction = 0.3f;
	[SerializeField] GameObject cubeInFront;
	public Collider col;

	 float ZoomAmount  = 0; //With Positive and negative values
	float field_of_view = 28f;
	float initial_cam_time = 0.05f;
	public float volume;
	public PlayManager playManager;
	private bool ended = false;
	void ZoomInCamera() {
		if(cam.GetComponent<Camera>().fieldOfView > field_of_view) {
			cam.GetComponent<Camera>().fieldOfView -= initial_cam_time;
			initial_cam_time += 0.01f;
		}
	}

	void Start()
	{
		_rb = GetComponent<Rigidbody>();
		_rb.maxAngularVelocity = 50;

	}

	Vector3 _offset;


	private void FixedUpdate() {
		if (Time.timeScale == 1 && !ended) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		velocity = (transform.position - lastPosition). magnitude / Time. deltaTime;
		lastPosition = transform.position;
		volume = Mathf.Min(velocity, 60)/60;
		sound_track_interactive.volume = volume;

		ZoomInCamera();
		Vector3 cam_for = cam.forward;
		Vector3 cam_right = cam.right;

		float vert_input = Input.GetAxisRaw("Vertical") * 100;
		float hor_input = Input.GetAxisRaw("Horizontal") * 100;
		float v_force = vert_input * force * Time.deltaTime;
		float h_force = hor_input *  force *Time.deltaTime;
		_rb.AddTorque( new Vector3(cam_for.z * v_force, 0, cam_for.x * v_force * -1) );
		_rb.AddTorque( new Vector3(cam_right.z * h_force, 0, cam_right.x * h_force * - 1) );

			// transform.Rotate(0, h_force, 0);
			// cubeInFront.transform.LookAt(this.transform.position);
			// _rb.AddTorque( new Vector3(0,  0, cam_right.y * h_force) );
			
		if ((Input.GetKeyDown(KeyCode.Space) || Input.GetAxisRaw("Fire1") == 1) && (is_grounded) )
		{
			is_grounded = false;
			_rb.AddForce(Vector3.up * jump_force * (Mathf.Min((velocity / 10) + 1, 2) ), ForceMode.Impulse);
		}

		if (Input.GetAxisRaw("Brake") > 0) {
			_rb.angularVelocity = Vector3.Lerp(_rb.angularVelocity, Vector3.zero, 0.4f);
			// _rb.GetComponent<PhysicMaterial>().dynamicFriction = 0;
			// _rb.GetComponent<PhysicMaterial>().staticFriction = 0;
			// Rocket.RocketFireStop();
		}

	}

	private void RotateRocket() {
		switch (rocket_curr_state) {
			case RocketPositionState.Up:

//				Rocket.transform.rotation = Quaternion.Lerp(Rocket.transform.rotation, Quaternion.AngleAxis(-90, new Vector3(0,0,1)), 0.9f);
				break;
			case RocketPositionState.Forward:
				Rocket.FaceForward();
//				Rocket.transform.rotation = Quaternion.Lerp(Rocket.transform.rotation, Quaternion.AngleAxis(0, new Vector3(0,0,1)), 0.9f);
			break;
		}
	}

	private void CheckMissileRotation() {
		// if(Input.GetKeyDown(KeyCode.Q) && (rocket_curr_state != RocketPositionState.Forward)) {
		// 	rocket_curr_state = RocketPositionState.Forward;
		// 	RotateRocket();
		// }
		if(Input.GetKey(KeyCode.Q)) {
			Rocket.FaceUpward();
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "DeathCollider" && !ended) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
		}
		is_grounded = true;
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "End") {
			ended = true;
			playManager.EndRace();
			_rb.AddExplosionForce(2000, Vector3.zero, 200, 10, ForceMode.Impulse);
			col.enabled = false;
		}
		// print(ended);
	}
}
