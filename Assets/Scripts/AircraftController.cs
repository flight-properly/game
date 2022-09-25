using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftController : MonoBehaviour {
	public float velocity = 7;
	public float yawSensitivity = 50;
	public float pitchSensitivity = 150;
	public float rollSensitivity = 150;
	public float movementSmoothness = 4;

	private Vector3 currentRotation;

    void Start() {
    }

    void Update() {
		// Horizontal Input
		float horizontalInput = Input.GetAxis("Horizontal");
		// Vertical Input
		float verticalInput = Input.GetAxis("Vertical");
		handle(horizontalInput, verticalInput);
		// Acceleration
		transform.Translate(Vector3.forward * velocity * Time.deltaTime);
    }

	void handle(float horizontalInput, float verticalInput) {
		float pitch = verticalInput * pitchSensitivity;
		float yaw = horizontalInput * yawSensitivity;
		float roll = -horizontalInput * rollSensitivity;
		Vector3 toRotate = new Vector3(pitch, yaw, roll);
		currentRotation = Vector3.Lerp(currentRotation, toRotate, movementSmoothness * Time.deltaTime);
		transform.Rotate(currentRotation * Time.deltaTime);
	}
}
