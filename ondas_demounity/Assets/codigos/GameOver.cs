using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	int puntaje = 0;

	void Start () {
		puntaje = PlayerPrefs.GetInt ("Puntaje");
	
	}

	void OnGUI()
	{
		GUI.Label (new Rect (Screen.width / 2 - 40, 50, 80, 30), "FIN DEL JUEGO");

		GUI.Label (new Rect (Screen.width / 2 - 40, 300, 80, 30), "Puntaje: " + puntaje);

		if (GUI.Button (new Rect (Screen.width / 2 - 30, 350, 60, 30), "Otra Vez?")) 
		{
			Application.LoadLevel(0);
		}
	}
}
