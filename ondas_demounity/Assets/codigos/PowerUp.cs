using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	HUDJuego hud;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			hud = GameObject.Find("Main Camera").GetComponent<HUDJuego>();
			hud.incrementarPuntaje(10);
			Destroy (this.gameObject);
		}
	}
}
