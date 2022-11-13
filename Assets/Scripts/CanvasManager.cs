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
	[SerializeField] private Text timeDisplayText;
	[SerializeField] private Text totalRingsText;
	[SerializeField] private Text currentRingsText;
	[SerializeField] private Text gameOverUIDescriptionText;

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

	public void updateTimeDisplayText(float time) {
		timeDisplayText.text = time.ToString("0.00");
	}

	public void updateTotalRingsText(int totalRingsCount) {
		totalRingsText.text = "/ " + totalRingsCount + " PASSED RINGS";
	}

	public void updateCurrentRingsText(int passedRingsCount) {
		currentRingsText.text = passedRingsCount.ToString();
	}

	public void updateGameOverUIDescriptionText(string text) {
		gameOverUIDescriptionText.text = text;
	}

	void Start() {
	}

	void Update() {
		
	}
}
