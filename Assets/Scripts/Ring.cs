using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour {

	public bool hasPassed = false;

	void Start() {
		
	}

	void Update() {
		
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			Debug.Log("Trigger: " + other.tag);
			hasPassed = true;
		}
	}
}
