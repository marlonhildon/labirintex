using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBehaviors : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		StartCoroutine ("WaitForBlink");
	}

	IEnumerator WaitForBlink() {
		gameObject.GetComponent<Renderer> ().enabled = false;
		yield return new WaitForSeconds (0.1f);
		gameObject.GetComponent<Renderer> ().enabled = true;
		yield return new WaitForSeconds (0.1f);
	}
}
