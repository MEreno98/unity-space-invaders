using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDisparoCargado : MonoBehaviour {

	private int impactos =  2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate (Vector2.up * 4f * Time.deltaTime);

		// Eliminamos el objeto si se sale de la pantalla
		if (transform.position.y > 10) {
			Destroy (gameObject);
		}	
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.gameObject.tag == "alien") {
			impactos -= 1;

			if (impactos == 0) {
				Destroy (gameObject);
			}
		} else if(coll.gameObject.tag == "disparo"){
			Destroy (coll.gameObject);
		}
	}
}
