using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Accord.Math;
using Accord.Statistics.Filters;
using Accord.Math.Optimization.Losses;
using Accord.MachineLearning;
using Accord.MachineLearning.DecisionTrees;
using Accord.MachineLearning.DecisionTrees.Learning;

public class DecisionTreeKeys : MonoBehaviour {

	DataTable keyTable = new DataTable ("Keys earned");		// Criando um DataTable
	Codification codebook;
	DecisionTree tree;

	public static string answer = null;
	public static string firstKeyCollected = null;
	public static string secondKeyCollected = null;
	public static string thirdKeyCollected = null;

	public GameObject exit1;
	public GameObject exit2;

	public static bool firstExitOpen = false, secondExitOpen = false;


	void Start () {
		
		// Adicionando classe e atributos à tabela
		keyTable.Columns.Add ("First key", typeof(string));
		keyTable.Columns.Add ("Second key", typeof(string));
		keyTable.Columns.Add ("Third key", typeof(string));
		keyTable.Columns.Add ("Exit", typeof(string));

		// Adicionando registros à tabela
		keyTable.Rows.Add("Yellow",	"Purple",	"Blue",		"First");
		keyTable.Rows.Add("Yellow", "Blue",		"Purple",	"Second");
		keyTable.Rows.Add("Purple", "Yellow",	"Blue",		"First");
		keyTable.Rows.Add("Purple", "Blue",		"Yellow",	"Second");
		keyTable.Rows.Add("Blue", 	"Purple",	"Yellow",	"First");
		keyTable.Rows.Add("Blue", 	"Yellow",	"Purple",	"Second");

		//	Para ficar menos custoso computacionalmente, o Accord converte as
		//	strings em integer symbols. Para isso, usa-se o codebook
		codebook = new Codification(keyTable);

		// Converterndo os dados da tabela para integer symbols usando o codebook
		DataTable symbols = codebook.Apply(keyTable);
		int[][] inputs = symbols.ToJagged<int> ("First key", "Second key", "Third key");
		int[] outputs = symbols.ToArray<int> ("Exit");

		// Criando o algoritmo ID3
		var id3Learning = new ID3Learning(){
			// Quantidade de instâncias diferentes em cada coluna
			new DecisionVariable("First key", 3),	//	Cada uma possui três instâncias possíveis:
			new DecisionVariable("Second key", 3),	//	1.yellow	2.purple	3.blue
			new DecisionVariable("Third key", 3)
		};

		//	Treinando a árvore
		tree = id3Learning.Learn(inputs, outputs);

		//	Verificando se houve erro no treino da árvore
		double errorTraining = new ZeroOneLoss(outputs).Loss(tree.Decide(inputs));
		Debug.Log ("Tree error? (0 = no, 1 = yes) \n" + errorTraining);
				
	}

	void Update () {

		if (GameOver.reset) {								// Resetando as variáveis caso o jogo seja reiniciado
			answer = null;
			firstKeyCollected = null;
			secondKeyCollected = null;
			thirdKeyCollected = null;
			exit1.GetComponent<MeshRenderer> ().enabled = true;
			exit2.GetComponent<MeshRenderer> ().enabled = true;
			firstExitOpen = false;
			secondExitOpen = false;
			PlayerControl.score = 0;
			CollisionBehaviors.keyCollected = null;

			GameOver.reset = false;
		}


		if (firstKeyCollected != null &&					// Quando as três chaves forem coletadas, a condição será atendida
			secondKeyCollected != null &&
			thirdKeyCollected != null) {

			int[] query = codebook.Transform (new[,] {		//	Tabela cujo valor será tratado
				{"First key",	firstKeyCollected},
				{"Second key",	secondKeyCollected},
				{"Third key",	thirdKeyCollected}

			});

			// Passando a tabela a ser tratada como argumento da árvore treinada | tree.Decide(tabelaParaTratar)
			// O resultado tratado (predicted) será em integer symbol
			int predicted = tree.Decide (query);
			answer = codebook.Revert ("Exit", predicted);		// Traduzindo o integer symbol para string
			Debug.Log (answer);

			if (answer == "First") {
				exit1.GetComponent<MeshRenderer> ().enabled = false;
				firstExitOpen = true;
			} else if (answer == "Second") {
				exit2.GetComponent<MeshRenderer> ().enabled = false;
				secondExitOpen = true;
			}
		}
			
	}

}