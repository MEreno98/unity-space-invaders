using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorNaves : MonoBehaviour {

	public Rigidbody2D nave1;
	public Rigidbody2D nave2;

	// Use this for initialization
	void Start () {
		int nJug = 0;

		if (PlayerPrefs.HasKey ("nJug")) {
			nJug = PlayerPrefs.GetInt("nJug");
		}

		Debug.Log (nJug);

		if (nJug == 1) {
			modoUnJug1();
		} else if (nJug == 2) {
			modoUnJug2();
		}

	}

	// Update is called once per frame
	void Update () {

	}

	void modoUnJug1(){
		Rigidbody2D d = (Rigidbody2D)Instantiate (nave1, nave1.transform.position, nave1.transform.rotation);
		d.transform.position = new Vector2(0f, d.transform.position.y);
	}

	void modoUnJug2(){
		Rigidbody2D d1 = (Rigidbody2D)Instantiate (nave1, nave1.transform.position, nave1.transform.rotation);
		Rigidbody2D d2 = (Rigidbody2D)Instantiate (nave2, nave2.transform.position, nave2.transform.rotation);
		Physics2D.IgnoreCollision (d1.GetComponent<Collider2D> (), d2.GetComponent<Collider2D> ());
	}
}
