using UnityEngine;
using System.Collections;

public class ControlUI : MonoBehaviour {
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void pasaraJuego(){
		Application.LoadLevel ("escena_principal");
	}

	public void pasaraInicio(){
		Application.LoadLevel ("escena_inicio");
	}

}

