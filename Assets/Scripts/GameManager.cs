using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Ring[] registeredRings;
	public float timeLimit = 30;

	private static GameManager instance;

	private GameState state;
	private int totalRingsCount = 0;
	private int passedRingsCount = 0;
	private float timeElapsed = 0;

	public static GameManager getInstance() {
		return instance ?? FindObjectOfType<GameManager>();
	}

	void Start() {
		state = GameState.RUNNING;
		totalRingsCount = registeredRings.Length;
		Debug.Log("totalRingsCount: " + totalRingsCount);
	}

	void Update() {
		if (state == GameState.IDLE) return;

		timeElapsed += Time.deltaTime;
		for (int i = passedRingsCount; i < totalRingsCount; i++) {
			if (registeredRings[i].hasPassed) {
				passedRingsCount += 1;
				registeredRings[i].gameObject.SetActive(false);
			}
		}

		// 게임 오버 확인 순서
		// 반드시 TimeLimit 조건 확인 후 링 조건 확인
		if (timeElapsed >= timeLimit) overGame(GameOverCause.TIME_OVER);
		if (passedRingsCount >= totalRingsCount) overGame(GameOverCause.COMPLETE);

		CanvasManager.getInstance().updateGameStateText(state.ToString());
		CanvasManager.getInstance().updateTimeDisplayText(timeElapsed);
		CanvasManager.getInstance().updateRingsCountDisplayText(passedRingsCount, totalRingsCount);
	}

	void overGame(GameOverCause cause) {
		Debug.Log("overGame called with cause: " + cause);
		switch (cause) {
			case GameOverCause.TIME_OVER:
				break;
			case GameOverCause.COMPLETE:
				break;
		}

		AircraftController.getInstance().setControllable(false);
		state = GameState.IDLE;
	}

	public Vector3 getLatestRingPosition() {
		return passedRingsCount > 0 ? registeredRings[passedRingsCount - 1].transform.position : Vector3.zero;
	}

	public int getPassedRingsCount() {
		return passedRingsCount;
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
