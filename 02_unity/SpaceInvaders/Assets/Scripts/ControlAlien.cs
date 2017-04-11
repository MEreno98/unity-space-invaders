using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class ControlAlien : MonoBehaviour
{
	// Conexión al marcador, para poder actualizarlo
	private GameObject marcador;

	// Por defecto, 100 puntos por cada alien
	public int puntos;

	//Vida del alien (Cantidad de impactos)
	public int vida;

	public Sprite[] aliensDañados;

	// Objeto para reproducir la explosión de un alien
	private GameObject efectoExplosion;

	// Use this for initialization
	void Start ()
	{
		// Localizamos el objeto que contiene el marcador
		marcador = GameObject.Find ("Marcador");

		// Objeto para reproducir la explosión de un alien
		efectoExplosion = GameObject.Find ("EfectoExplosion");
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		// Detectar la colisión entre el alien y otros elementos

		// Necesitamos saber contra qué hemos chocado
		if (coll.gameObject.tag == "disparo") {

			//Restar una vida por cada disparo
			vida -= 1;

			// Sonido de explosión
			GetComponent<AudioSource> ().Play ();

		
			if (aliensDañados.Length > 0 & vida != 0) {
				GetComponent<SpriteRenderer> ().sprite = aliensDañados [vida];
			}
				
			// El disparo desaparece (cuidado, si tiene eventos no se ejecutan)
			Destroy (coll.gameObject);

			//Comprobar que alien no tiene vida
			if (vida == 0) {
				
				// Sumar la puntuación al marcador
				marcador.GetComponent<ControlMarcador> ().puntos += puntos;

				// El alien desaparece (no hace falta retraso para la explosión, está en otro objeto)
				efectoExplosion.GetComponent<AudioSource> ().Play ();
				Destroy (gameObject);
			}
				
		} else if (coll.gameObject.tag == "nave") {
			PlayerPrefs.DeleteKey ("marcador");
			SceneManager.LoadScene ("GameOver");

		} else if (coll.gameObject.tag == "dc1" | coll.gameObject.tag == "dc2" ) {
			// Sonido de explosión
			GetComponent<AudioSource> ().Play ();

			// Sumar la puntuación al marcador
			marcador.GetComponent<ControlMarcador> ().puntos += puntos;

			// El alien desaparece (no hace falta retraso para la explosión, está en otro objeto)
			efectoExplosion.GetComponent<AudioSource> ().Play ();
			Destroy (gameObject);

		}
	}
		
}