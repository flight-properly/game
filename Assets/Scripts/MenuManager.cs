using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

	[SerializeField]
	private GameObject clickSound;

	public void playGame()
	{
		Debug.Log("playGame");
		StartCoroutine(waitAndLoadScene(SceneManager.GetActiveScene().buildIndex + 1));
	}

	public void howTo()
	{
		Debug.Log("howTo");
		StartCoroutine(waitAndLoadScene(SceneManager.GetActiveScene().buildIndex + 2));
	}

	public void mainMenu()
	{
		Debug.Log("mainMenu");
		StartCoroutine(waitAndLoadScene(0));
	}

	public void quitGame()
	{
		Debug.Log("quitGame");
		Application.Quit(0);
	}

	private IEnumerator waitAndLoadScene(int sceneIdx)
	{
		yield return new WaitForSeconds(clickSound.GetComponent<AudioSource>().clip.length);
		SceneManager.LoadScene(sceneIdx);
	}
}
