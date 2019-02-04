using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

	public static int score = 0;
	public GameObject scoreText, exitText, yellowKeyImage, purpleKeyImage, blueKeyImage;

	Vector3 playerPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	void Update () {

		// Controles
		if (Input.GetKey("up")) {
			transform.Translate (0, 0, 3.5f * Time.deltaTime);
		}

		if (Input.GetKey("down")) {
			transform.Translate (0, 0, -3.5f * Time.deltaTime);
		}

		if (Input.GetKey("left")) {
			transform.Translate (-3.5f * Time.deltaTime, 0, 0);
		}

		if (Input.GetKey("right")) {
			transform.Translate (3.5f * Time.deltaTime, 0, 0);
		}
			
		scoreText.GetComponent<Text> ().text = score.ToString ();

		switch (CollisionBehaviors.keyCollected) {

		case "Yellow":
			yellowKeyImage.GetComponent<Image> ().enabled = true;
			CollisionBehaviors.keyCollected = null;
			break;
		case "Purple":
			purpleKeyImage.GetComponent<Image> ().enabled = true;
			CollisionBehaviors.keyCollected = null;
			break;
		case "Blue":
			blueKeyImage.GetComponent<Image> ().enabled = true;
			CollisionBehaviors.keyCollected = null;
			break;
		}

		if (yellowKeyImage.GetComponent<Image> ().enabled &&
		    purpleKeyImage.GetComponent<Image> ().enabled &&
		    blueKeyImage.GetComponent<Image> ().enabled) {

			exitText.GetComponent<Text> ().enabled = true;
		}

		if (Input.GetKeyDown ("escape")) {
			Application.Quit ();
		}

	}

}
