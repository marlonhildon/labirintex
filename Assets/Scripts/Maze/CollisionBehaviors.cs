using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class CollisionBehaviors : MonoBehaviour {

	public GameObject portalDest1, portalDest2, portalDest3, portalDest4;
	public static string keyCollected = null;

	int keyOrder = 0;

	// Para haver colisão desse tipo:
	// 1.Ambos devem ter colliders (box, sphere, etc)
	// 2.Apenas um deles deve ter Rigid Body
	// 3.Apenas um deles deve estar marcado como Is trigger

	void OnTriggerEnter(Collider otherObject) {
		
		switch (otherObject.tag) {

		case "point":			// Colisão com os pontos (esferas amarelas)
			PlayerControl.score += 50;
			GameObject.FindGameObjectWithTag ("point").GetComponent<AudioSource> ().Play ();
			Destroy (otherObject.gameObject);
			break;
		
		case "Yellow":			// Colisão com as chaves (cubos que giram)
		case "Purple":
		case "Blue":
			keyCollected = otherObject.tag;
			StartCoroutine (WaitAndDestroy(otherObject));
			break;
				
		case "portal 1":		// Colisão com os portais (retângulos azuis piscantes)
		case "portal 2":
		case "portal 3":
		case "portal 4":
			TeleportPlayer (otherObject);
			break;

		case "horizontal spike":		// Colisão com os espinhos vermelhos
		case "vertical spike":
		case "vertical spike 2":
		case "sentinel":
			SceneManager.LoadScene ("GameOver");
			break;

		case "Exit1":
			if (DecisionTreeKeys.firstExitOpen) {
				SceneManager.LoadScene ("GameOver");
			}
			break;

		case "Exit2":
			if (DecisionTreeKeys.secondExitOpen) {
				SceneManager.LoadScene ("GameOver");
			}
			break;
		}

	}

	//	A chave estava sendo destruída mais rápido que a engine pudesse executar o som
	//	da colisão. Então é necessário esperar alguns décimos antes de destruí-la

	IEnumerator WaitAndDestroy (Collider keyCollided) {

		keyOrder++;

		switch (keyOrder) {
		case 1:
			DecisionTreeKeys.firstKeyCollected = keyCollided.tag;
			break;
		case 2:
			DecisionTreeKeys.secondKeyCollected = keyCollided.tag;
			break;
		case 3:
			DecisionTreeKeys.thirdKeyCollected = keyCollided.tag;
			break;
		}

		PlayerControl.score += 500;
		GameObject.FindGameObjectWithTag (keyCollided.tag).GetComponent<AudioSource> ().Play ();
		GameObject.FindGameObjectWithTag (keyCollided.tag).GetComponent<Renderer>().enabled = false;

		yield return new WaitForSeconds (0.3f);
		Destroy (keyCollided.gameObject);
	}

	//	O NavMeshAgent é desabilitado e habilitado porque ao teleportar o player, estavam acontecendo
	//	bugs - o jogador ficava preso na malha do NavMesh

	void TeleportPlayer (Collider teleportCollided) {

		GameObject.FindGameObjectWithTag (teleportCollided.tag).GetComponent<AudioSource> ().Play ();
		GameObject.FindGameObjectWithTag ("Player").GetComponent<NavMeshAgent> ().enabled = false;

		if (teleportCollided.tag == "portal 1") {transform.position = portalDest3.transform.position;}
		if (teleportCollided.tag == "portal 2") {transform.position = portalDest4.transform.position;}
		if (teleportCollided.tag == "portal 3") {transform.position = portalDest1.transform.position;}
		if (teleportCollided.tag == "portal 4") {transform.position = portalDest2.transform.position;}

		GameObject.FindGameObjectWithTag ("Player").GetComponent<NavMeshAgent> ().enabled = true;
	}

}
