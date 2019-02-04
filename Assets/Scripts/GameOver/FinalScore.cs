using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

	public GameObject score;

	// Use this for initialization
	void Start () {
		score.GetComponent<Text> ().text = PlayerControl.score.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
