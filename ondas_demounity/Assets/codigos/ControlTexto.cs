using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlTexto : MonoBehaviour {

	int puntaje = 0;
	public Text texto;

	// Use this for initialization
	void Start () {
		puntaje = PlayerPrefs.GetInt ("Puntaje");
		texto.text = "Puntaje: " + puntaje;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
