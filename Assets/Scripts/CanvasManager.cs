using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {

	private static CanvasManager instance;

	public static CanvasManager getInstance() {
		return instance ?? FindObjectOfType<CanvasManager>();
	}

	[SerializeField] private Text speedMeterText;
	[SerializeField] private Text throttleMeterText;
	[SerializeField] private Text isStallText;

	public void updateSpeedMeterText(float speed) {
		speedMeterText.text = "Speed: " + speed;
	}

	public void updateThrottleMeterText(float throttle) {
		throttleMeterText.text = "Throttle: " + throttle;
	}

	public void updateIsStallText(bool isStall) {
		isStallText.text = "Stall: " + isStall;
	}

	void Start() {
		
	}

	void Update() {
		
	}
}
