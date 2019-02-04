using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeBehaviors : MonoBehaviour {

	string horizontalMovement;
	string verticalMovement;
	string verticalMovement2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//	Horizontal
		if (transform.position.x <= -5.91f && gameObject.tag == "horizontal spike") {
			horizontalMovement = "go right";
		} 

		if (transform.position.x >= 3.88f && gameObject.tag == "horizontal spike"){
			horizontalMovement = "go left";
		}

		if (horizontalMovement == "go right") {
			transform.Translate (0, -5 * Time.deltaTime, 0);
		}

		if (horizontalMovement == "go left") {
			transform.Translate (0, 5 * Time.deltaTime, 0);
		}

		//	Vertical
		if (transform.position.z >= -5.24f && gameObject.tag == "vertical spike") {
			verticalMovement = "go down";
		} 

		if (transform.position.z <= -7.9f && gameObject.tag == "vertical spike"){
			verticalMovement = "go up";
		}

		if (verticalMovement == "go up") {
			transform.Translate (0, 4 * Time.deltaTime, 0);
		}

		if (verticalMovement == "go down") {
			transform.Translate (0, -4 * Time.deltaTime, 0);
		}

		//	Vertical 2
		if (transform.position.z >= 4.5 && gameObject.tag == "vertical spike 2") {
			verticalMovement2 = "go down";
		} 

		if (transform.position.z <= -8.34f && gameObject.tag == "vertical spike 2"){
			verticalMovement2 = "go up";
		}

		if (verticalMovement2 == "go up") {
			transform.Translate (0, 3 * Time.deltaTime, 0);
		}

		if (verticalMovement2 == "go down") {
			transform.Translate (0, -3f * Time.deltaTime, 0);
		}

	}
}
