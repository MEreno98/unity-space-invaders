using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonControl : MonoBehaviour {


	public void showMenu(){

		if (Time.timeScale == 0) {
			Time.timeScale = 1;
		}
			
		PlayerPrefs.DeleteKey("nJug");
		SceneManager.LoadScene ("Menu");
	}

	public void play1Player(){
		PlayerPrefs.SetInt("nJug",1);
		SceneManager.LoadScene ("Nivel1");
	}

	public void play2Players(){
		PlayerPrefs.SetInt("nJug",2);
		SceneManager.LoadScene ("Nivel1");
	}

	public void continuar(){
		if (Time.timeScale == 0) {
			Time.timeScale = 1;
		}
			

	
	}
}
