using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour {
	
	public Transform target;

    void Start() {
        transform.position = target.position;
		Debug.Log(GetComponent<Rigidbody>());
    }

    void Update() {
		transform.LookAt(target);
		// TODO: hardcoded 값 대신 target 크기 구해서 그 크기 만큼 transform.forward 값에 multiply
        transform.position = target.position + (transform.forward * -100);
    }
}
