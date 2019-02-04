using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public void MudarCena(string nomeCena){
		SceneManager.LoadScene (nomeCena);
	}

	public void QuitGame(){
		Application.Quit ();
	}
}