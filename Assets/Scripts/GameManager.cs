using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public Ring[] registeredRings;

	private static GameManager instance;

	private GameState state;
	private int totalRingsCount = 0;
	private int ringsPassed = 0;

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

		for (int i = 0; i < totalRingsCount; i++) {
			if (registeredRings[i].hasPassed) ringsPassed += 1;
		}

		if (ringsPassed >= totalRingsCount) OverGame(GameOverCause.COMPLETE);

		CanvasManager.getInstance().updateGameStateText(state.ToString());
	}

	void OverGame(GameOverCause cause) {
		Debug.Log("OverGame called with cause: " + cause);
		switch (cause) {
			case GameOverCause.TIME_OVER:
				break;
			case GameOverCause.CRASH:
				break;
			case GameOverCause.COMPLETE:
				break;
		}

		state = GameState.IDLE;
	}

	enum GameState {
		IDLE,
		RUNNING,
	}

	enum GameOverCause {
		TIME_OVER,
		CRASH,
		COMPLETE,
	}
}
