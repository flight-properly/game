using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftController : MonoBehaviour {

	public float minSpeed = 10.0f;
	public float currentSpeed = 20.0f;
	public float maxSpeed = 50.0f;
	public float yawSensitivity = 50;
	public float pitchSensitivity = 150;
	public float rollSensitivity = 150;
	public float movementSmoothness = 4;
	public float gravity = 5;

	private Vector3 currentRotation;

	void Start() {
	}

	void Update() {
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");
		handle(horizontalInput, verticalInput);
	}

	void handle(float horizontalInput, float verticalInput) {
		float pitch = -verticalInput * pitchSensitivity;
		float yaw = horizontalInput * yawSensitivity;
		float roll = -horizontalInput * rollSensitivity;
		Vector3 toRotate = new Vector3(pitch, yaw, roll);
		currentRotation = Vector3.Lerp(currentRotation, toRotate, movementSmoothness * Time.deltaTime);
		transform.Rotate(currentRotation * Time.deltaTime);

		// 최대 / 최소 속력에 가까워 질 수록 변화율 0에 수렴
		float changeRate = 1;
		if (verticalInput > 0) changeRate = (maxSpeed - currentSpeed) / currentSpeed;
		else changeRate = (currentSpeed - minSpeed) / currentSpeed;
		currentSpeed += verticalInput * changeRate * Time.deltaTime;

		// 피치값에 따른 중력 임의로 추가
		float gravityBasedOnPitch = gravity * Mathf.Sin(transform.eulerAngles.x * Mathf.Deg2Rad);
		currentSpeed += gravityBasedOnPitch * Time.deltaTime;

		// 가속
		transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

		CanvasManager.getInstance().updateVelocityText(currentSpeed);
	}

	private void OnTriggerEnter(Collider other) {
		Debug.Log(other.gameObject.name);
	}
}
