using UnityEngine;

[RequireComponent(typeof(Personaje))]
public class PersonajeControl : MonoBehaviour 
{
	private Personaje personaje;
    private bool salto;


	void Awake()
	{
		personaje = GetComponent<Personaje>();
	}

    void Update ()
    {
	    if (Input.GetButtonDown("Jump")) salto = true;
    }

	void FixedUpdate()
	{
	    float h = Input.GetAxis("Horizontal");
		personaje.Move( 1, false , salto );
		salto = false;
	}
}
