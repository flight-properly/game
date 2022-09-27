using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {

	private static CanvasManager instance;

	public static CanvasManager getInstance() {
		return instance ?? FindObjectOfType<CanvasManager>();
	}

	[SerializeField] private Text velocityText;

	public void updateVelocityText(float velocity) {
		velocityText.text = "Velocity: " + velocity + "m/s";
	}

	void Start() {
		
	}

	void Update() {
		
	}
}
