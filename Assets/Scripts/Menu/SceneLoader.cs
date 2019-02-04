using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public GameObject loadingCanvas;
	public GameObject menuCanvas;
	public Slider slider;

	AsyncOperation async;

	public void LoadingScreen () {
		StartCoroutine (LoadingCanvasScreen ());
	}

	public void LoadLevel () {
		async.allowSceneActivation = true;
	}

	IEnumerator LoadingCanvasScreen () {
		
		loadingCanvas.SetActive (true);
		menuCanvas.SetActive (false);
		async = SceneManager.LoadSceneAsync (1);
		async.allowSceneActivation = false;

		while (async.isDone == false) {
			slider.value = async.progress;
			if (async.progress == 0.9f) {
				slider.value = 1f;
				GameObject.FindGameObjectWithTag ("PlayButton").GetComponent<Button> ().interactable = true;
			}

			yield return null;
		}
	}

}
