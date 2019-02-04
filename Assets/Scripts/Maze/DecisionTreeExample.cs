using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Accord.Statistics.Filters;
using Accord.Math;
using Accord.MachineLearning.DecisionTrees.Learning;
using Accord.MachineLearning.DecisionTrees;
using Accord.Math.Optimization.Losses;
using Accord.MachineLearning;
using System;
using System.Data;

public class DecisionTreeExample : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
		// In this example, we will learn a decision tree directly from integer
		// matrices that define the inputs and outputs of our learning problem.

		int[][] inputs =	// Tabela de valores lógicos (1 é verdadeiro e 0 é falso)
		{
			new int[] { 1, 0 },
			new int[] { 0, 1 },
			new int[] { 0, 0 },
			new int[] { 1, 1 },
		};

		int[] outputs = 	// Operação AND
		{
			0, 0, 0, 1
		};

		int[][] exampleData =
		{
			new int[] { 1, 1 },
			new int[] { 0, 0 },
			new int[] { 1, 0 },
			new int[] { 0, 1 },
		};

		// Create an ID3 learning algorithm
		ID3Learning teacher = new ID3Learning();

		// Learn a decision tree for the XOR problem
		var tree = teacher.Learn(inputs, outputs);

		// Compute the error in the learning
		double error = new ZeroOneLoss(outputs).Loss(tree.Decide(inputs));
		Debug.Log("Houve erro?" + error);

		// The tree can now be queried for new examples:
		int[] predicted = tree.Decide(exampleData); // A saída será { 1, 0, 0, 0 }

		for (int i=0; i < predicted.Length; i++){
			Debug.Log(predicted[i]);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
