using UnityEngine;
using System.Collections;

public class HUDJuego : MonoBehaviour {

	float puntajeJugador = 0;

	void Update () {
		puntajeJugador += Time.deltaTime;
	}

	public void incrementarPuntaje(int cantidad)
	{
		puntajeJugador += cantidad;
	}

	void OnDisable ()
	{
		PlayerPrefs.SetInt("Puntaje", (int)(puntajeJugador * 100));
	}

	void OnGUI()
	{
		GUI.Label (new Rect (10, 10, 100, 30), "Puntaje: " + (int)(puntajeJugador * 100));
	}
}
