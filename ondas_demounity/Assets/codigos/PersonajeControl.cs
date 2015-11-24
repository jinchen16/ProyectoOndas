using UnityEngine;

[RequireComponent(typeof(Personaje))]
public class PersonajeControl : MonoBehaviour 
{
	private Personaje personaje;
    private bool salto;
	AudioSource as_personaje;
	public AudioClip ac_jump;


	void Awake()
	{
		personaje = GetComponent<Personaje>();
		as_personaje = gameObject.GetComponent<AudioSource>();
	}

    void Update ()
    {
		if (Input.GetButtonDown("Jump")){
			salto = true;
			as_personaje.PlayOneShot(ac_jump);
		} 
    }

	void FixedUpdate()
	{
	    float h = Input.GetAxis("Horizontal");
		personaje.Move( 1, false , salto );
		salto = false;
	}
}
