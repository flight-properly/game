using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public float timeLimit = 30;

	private static GameManager instance;
	private GameState state;

	public Ring[] registeredRings;
	private int totalRingsCount = 0;
	private int passedRingsCount = 0;
	private float timeElapsed = 0;

	[Header("Pause")]
	[SerializeField]
	private bool isPaused = false;
	private bool showUI = true;
	[SerializeField]
	private GameObject[] shouldHideObjects;
	[SerializeField]
	private GameObject pauseUI;
	[SerializeField]
	private GameObject gameOverUI;

	public static GameManager getInstance() {
		return instance ?? FindObjectOfType<GameManager>();
	}

	void Start() {
		state = GameState.RUNNING;
		totalRingsCount = registeredRings.Length;
		gameOverUI.SetActive(false);
		pauseUI.SetActive(isPaused);
		CanvasManager.getInstance().updateTotalRingsText(totalRingsCount);
		Debug.Log("totalRingsCount: " + totalRingsCount);
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape) && state == GameState.RUNNING) toggleGamePause();
		if (state == GameState.IDLE || isPaused) return;

		timeElapsed += Time.deltaTime;
		// Ring이 등록된 순서대로 통과해야하기에 (passedRingsCount + 1)번째 이후 Ring들의 경우 이미 통과하였더라도 hasPassed를 false로 변경하여 ignore
		for (int i = passedRingsCount + 1; i < totalRingsCount; i++) registeredRings[i].hasPassed = false;
		if (registeredRings[passedRingsCount].hasPassed) registeredRings[passedRingsCount++].gameObject.SetActive(false); 

		// 게임 오버 확인 순서
		// 반드시 TimeLimit 조건 확인 후 링 조건 확인
		if (timeElapsed >= timeLimit) overGame(GameOverCause.TIME_OVER);
		if (passedRingsCount >= totalRingsCount) overGame(GameOverCause.COMPLETE);

		if (state == GameState.RUNNING) {
			CanvasManager.getInstance().updateGameStateText(state.ToString());
			CanvasManager.getInstance().updateTimeDisplayText(timeElapsed);
			CanvasManager.getInstance().updateCurrentRingsText(passedRingsCount);
		}
	}

	void overGame(GameOverCause cause) {
		Debug.Log("overGame called with cause: " + cause);
		toggleUI();
		gameOverUI.SetActive(true);
		string desc = "";
		switch (cause) {
			case GameOverCause.TIME_OVER:
				desc = "제한 시간을 초과하였습니다.";
				break;
			case GameOverCause.COMPLETE:
				desc = "모든 목표를 완료하였습니다.";
				break;
		}

		CanvasManager.getInstance().updateGameOverUIDescriptionText(desc);
		AircraftController.getInstance().setControllable(false);
		state = GameState.IDLE;
	}

	void toggleGamePause() {
		isPaused = !isPaused;
		toggleUI();
		pauseUI.SetActive(isPaused);
		Time.timeScale = isPaused ? 0f : 1f;
	}

	void toggleUI() {
		showUI = !showUI;
		foreach(GameObject obj in shouldHideObjects) obj.SetActive(showUI);
	}

	public Vector3 getLatestRingPosition() {
		return passedRingsCount > 0 ? registeredRings[passedRingsCount - 1].transform.position : Vector3.zero;
	}

	public int getPassedRingsCount() {
		return passedRingsCount;
	}

	public int getTotalRingsCount() {
		Debug.Log("getTotalRingsCount called" + totalRingsCount);
		return totalRingsCount;
	}

	public bool isGameRunning() {
		return state == GameState.RUNNING;
	}

	enum GameState {
		IDLE,
		RUNNING,
	}

	enum GameOverCause {
		TIME_OVER,
		COMPLETE,
	}
}
