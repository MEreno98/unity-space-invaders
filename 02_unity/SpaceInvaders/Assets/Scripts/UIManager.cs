﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	GameObject[] pauseObjects;
	GameObject[] pauseHideObjects;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag("Pause");
		pauseHideObjects = GameObject.FindGameObjectsWithTag("PauseHide");
		hidePaused();
	}
	
	// Update is called once per frame
	void Update () {
		//uses the p button to pause and unpause the game
		if(Input.GetKeyDown(KeyCode.P))
		{
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
			} else if (Time.timeScale == 0){
				Time.timeScale = 1;
				hidePaused();
			}
		}
	}

	//shows objects with ShowOnPause tag
	public void showPaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(true);
		}

		foreach (GameObject g in pauseHideObjects) {
			g.SetActive (false);
		}
	}

	//hides objects with ShowOnPause tag
	public void hidePaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(false);
		}

		foreach (GameObject g in pauseHideObjects) {
			g.SetActive (true);
		}
	}

	public void continuar(){
		if (Time.timeScale == 0){
			Debug.Log ("high");
			Time.timeScale = 1;
			hidePaused();
		}
	}

	public void showMenu(){
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
}
