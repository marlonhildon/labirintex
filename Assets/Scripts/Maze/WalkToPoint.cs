using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkToPoint : MonoBehaviour {

	public Transform goal;
	public NavMeshAgent agent;
	public bool autoWalk = false;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {		
		agent.destination = goal.position;
	}

}
