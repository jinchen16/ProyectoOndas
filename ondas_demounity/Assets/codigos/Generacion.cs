using UnityEngine;
using System.Collections;

public class Generacion : MonoBehaviour {

	public GameObject[] obj;
	public float generacionMin = 1f;
	public float generacionMax = 2f;

	void Start () {
		Generar();
	}
	
	void Generar()
	{
		Instantiate(obj[Random.Range(0,obj.GetLength(0))], transform.position, Quaternion.identity);
		Invoke ("Generar", Random.Range (generacionMin, generacionMax));
	}
}
