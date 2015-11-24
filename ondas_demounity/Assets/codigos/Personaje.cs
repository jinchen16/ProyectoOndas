using UnityEngine;

public class Personaje : MonoBehaviour 
{
	bool facingRight = true;
	[SerializeField] float velocidadMax = 10f;
	[SerializeField] float fuerzaSalto = 700f;
	[Range(0, 1)]
	[SerializeField] float velocidadAgacharse = .36f;			// Cantidad de la velocidad maxima, que corresponde a agacharse. 1 = 100%
	[SerializeField] bool airControl = false;			// Control mientras esta en el aire
	[SerializeField] LayerMask queEsTierra;			// Determina que es de la escena y que es del personaje
	Transform comprobadorSuelo;	
	float radioAterrizado = .2f;							// Radio para determinar si esta aterrizado o no.
	bool aterrizado = false;								// Ha aterrizado o no el jugador
	Transform comprobadorTecho;	
	float radioTecho = .01f;							// Radio para comprobar si ha superado la altura de la pantalla
	Animator anim;										// Componente animator del jugador
	bool dobleSalto = false;

    void Awake()
	{
		comprobadorSuelo = transform.Find("comprobadorSuelo");
		comprobadorTecho = transform.Find("comprobadorTecho");
		anim = GetComponent<Animator>();
	}


	void FixedUpdate()
	{
		// El jugador esta aterrizado si el circulo de comprobarSuelo colisiona con cualquier cosa que sea tierra (escena)
		aterrizado = Physics2D.OverlapCircle(comprobadorSuelo.position, radioAterrizado, queEsTierra);
		anim.SetBool("Ground", aterrizado);

		anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);

		if (aterrizado)
						dobleSalto = false;
	}


	public void Move(float move, bool crouch, bool jump)
	{


		// si esta agachado mirar si se puede parar
		if(!crouch && anim.GetBool("Crouch"))
		{
			// si esta en el techo y no puede pararse, entoinces se agacha
			if( Physics2D.OverlapCircle(comprobadorTecho.position, radioTecho, queEsTierra))
				crouch = true;
		}

		// agacha o no agacha en el animator
		anim.SetBool("Crouch", crouch);

		if(aterrizado || airControl)
		{
			// Reduce the speed if crouching by the velocidadAgacharse multiplier
			move = (crouch ? move * velocidadAgacharse : move);

			// La velocidad del animator pasa a ser igual a la totalidad de la velocidad horizontal.
			anim.SetFloat("Speed", Mathf.Abs(move));

			// mueve al personaje
			GetComponent<Rigidbody2D>().velocity = new Vector2(move * velocidadMax, GetComponent<Rigidbody2D>().velocity.y);
			
			// si la entrada está moviendo el jugador a la derecha y el jugador se enfrenta a la izquierda
			if(move > 0 && !facingRight)
				Flip();

			// si la entrada está moviendo el jugador a la izquierda y el jugador se enfrenta a la derecha 
			else if(move < 0 && facingRight)
				Flip();
		}
	
        if ((aterrizado || !dobleSalto) && jump) {
            anim.SetBool("Ground", false);
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, fuerzaSalto));

			if(!aterrizado)
				dobleSalto = true;
        }
	}

	
	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
