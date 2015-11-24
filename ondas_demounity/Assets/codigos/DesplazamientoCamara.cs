using UnityEngine;
using System.Collections;

public class DesplazamientoCamara : MonoBehaviour {

	public Transform jugador;

	void Update()
	{
		transform.position = new Vector3 (jugador.position.x + 6, 0, -10);
		}
}
