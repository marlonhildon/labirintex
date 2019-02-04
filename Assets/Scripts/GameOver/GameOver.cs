using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public static bool reset = false;

	public void Retry () {
		reset = true;
		SceneManager.LoadScene ("Maze");
	}

	public void QuitGame () {
		Application.Quit ();
	}

}