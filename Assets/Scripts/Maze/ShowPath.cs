using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPath : MonoBehaviour {

	void Update () {
		
		var nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
		var line = this.GetComponent<LineRenderer>();
		var path = nav.path;

		line.positionCount = path.corners.Length;

		for (int i = 0; i < path.corners.Length - 1; i++)
		{
			Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
		}

	}
		
}
