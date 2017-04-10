using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControlNave : MonoBehaviour
{

	// Velocidad a la que se desplaza la nave (medido en u/s)
	private float velocidad = 20f;

	// Fuerza de lanzamiento del disparo
	private float fuerza = 0.5f;
	private float fuerzaSec = 10f;

	// Acceso al prefab del disparo
	public Rigidbody2D disparoPrinc;
	public Rigidbody2D disparoSec;
	public Rigidbody2D nave1;
	public Rigidbody2D nave2;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Calculamos la anchura visible de la cámara en pantalla
		float distanciaHorizontal = Camera.main.orthographicSize * Screen.width / Screen.height;

		// Calculamos el límite izquierdo y el derecho de la pantalla
		float limiteIzq = -1.0f * distanciaHorizontal;
		float limiteDer = 1.0f * distanciaHorizontal;

		// Nave Jug1 Tecla: Izquierda
		if (Input.GetKey (KeyCode.LeftArrow)) {

			// Nos movemos a la izquierda hasta llegar al límite para entrar por el otro lado
			if (nave1.transform.position.x > limiteIzq) {
				nave1.transform.Translate (Vector2.left * velocidad * Time.deltaTime);
			} else {
				nave1.transform.position = new Vector2 (limiteDer, nave1.transform.position.y);			
			}
		}

		// Nave Jug1 Tecla: Derecha
		if (Input.GetKey (KeyCode.RightArrow)) {

			// Nos movemos a la derecha hasta llegar al límite para entrar por el otro lado
			if (nave1.transform.position.x < limiteDer) {
				transform.Translate (Vector2.right * velocidad * Time.deltaTime);
			} else {
				nave1.transform.position = new Vector2 (limiteIzq, nave1.transform.position.y);			
			}
		}

		// Nave Jug1 Disparo
		if (Input.GetKeyDown (KeyCode.Space)) {
			disparar (nave1);
		}

		//Nave Jug2 Disparo cargado
		if(Input.GetKeyUp(KeyCode.LeftAlt)){
			if (GameObject.Find ("DisparoSec(Clone)") == null) {
				dispararCargado (nave1);
			}
		}

		// Nave Jug2 Tecla: Izquierda
		if (Input.GetKey (KeyCode.A)) {

			// Nos movemos a la izquierda hasta llegar al límite para entrar por el otro lado
			if (nave2.transform.position.x > limiteIzq) {
				nave2.transform.Translate (Vector2.left * velocidad * Time.deltaTime);
			} else {
				nave2.transform.position = new Vector2 (limiteDer, nave2.transform.position.y);			
			}
		}

		// Nave Jug2 Tecla: Derecha
		if (Input.GetKey (KeyCode.D)) {

			// Nos movemos a la derecha hasta llegar al límite para entrar por el otro lado
			if (nave2.transform.position.x < limiteDer) {
				transform.Translate (Vector2.right * velocidad * Time.deltaTime);
			} else {
				nave2.transform.position = new Vector2 (limiteIzq, nave2.transform.position.y);			
			}
		}

		// Nave Jug2 Disparo
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			disparar (nave2);
		}

		//Nave Jug2 Disparo cargado
		if(Input.GetKeyUp(KeyCode.F)){
			if (GameObject.Find ("Disparo_blueSec(Clone)") == null) {
				dispararCargado (nave2);
			}
		}

	}

	void disparar (Rigidbody2D nave)
	{
		// Hacemos copias del prefab del disparo y las lanzamos
		Rigidbody2D d = (Rigidbody2D)Instantiate (disparoPrinc, nave.transform.position, nave.transform.rotation);

		// Desactivar la gravedad para este objeto, si no, ¡se cae!
		d.gravityScale = 0;

		// Posición de partida, en la punta de la nave
		d.transform.Translate (Vector2.up * 0.8f);

		// Lanzarlo
		d.AddForce (Vector2.up * fuerza, ForceMode2D.Impulse);	
	}

	void dispararCargado(Rigidbody2D nave){
		// Hacemos copias del prefab del disparo y las lanzamos
		Rigidbody2D d = (Rigidbody2D)Instantiate (disparoSec, nave.transform.position, nave.transform.rotation);


		// Desactivar la gravedad para este objeto, si no, ¡se cae!
		d.gravityScale = 0;


		// Posición de partida, en la punta de la nave
		d.transform.Translate (Vector2.up * 1.5f);

		// Lanzarlo
		d.AddForce (Vector2.up * fuerzaSec, ForceMode2D.Impulse);	
	}

}
