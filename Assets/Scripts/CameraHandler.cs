using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour {
	
	public Transform target;
	public float moveSpeed = 8f;
	public float rotateSpeed = 3f;

	void Start() {
	}
 
	// AircraftController에서 포지션 값 업데이트 후 카메라 업데이트
	void LateUpdate() {
		// TODO: hardcoded 값 대신 target 크기 구해서 그 크기 만큼 transform.forward 값에 multiply
		transform.position = Vector3.Lerp(transform.position, target.position + (transform.forward * -100), moveSpeed * Time.deltaTime);
		transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rotateSpeed * Time.deltaTime);
	}
}
