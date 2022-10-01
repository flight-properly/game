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
	[SerializeField] private Text stallDisplayText;
	[SerializeField] private Text gameStateText;

	public void updateSpeedMeterText(float speed) {
		speedMeterText.text = "Speed: " + speed;
	}

	public void updateThrottleMeterText(float throttle) {
		throttleMeterText.text = "Throttle: " + throttle;
	}

	public void updateStallDisplayText(bool isStall) {
		stallDisplayText.text = "Stall: " + isStall;
	}

	public void updateGameStateText(string gameState) {
		gameStateText.text = "GameState: " + gameState;
	}

	void Start() {
		
	}

	void Update() {
		
	}
}
