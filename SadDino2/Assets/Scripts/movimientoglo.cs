using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoglo : MonoBehaviour {

	public GameObject projectile;
	public Transform puntero;
	public float Speed;
	private Vector3 inicio,final;

	public float shotsPerSeconds = 0.5f;
	public float projectileSpeed = 10f;
	public AudioClip fireSound;                
  
	private Rigidbody2D rigidbody;
	// Use this for initialization
	void Start () {
		puntero.parent = null; //To elimante the "follow"
		inicio=transform.position; //Indicate the beginning
		final = puntero.position;//Indicate the end
		rigidbody = GetComponent<Rigidbody2D> ();	

	}


	void Fire () {

		GameObject missile = Instantiate (projectile, transform.position, Quaternion.identity) as GameObject; //Insantiate the missile
		rigidbody = missile.gameObject.GetComponent<Rigidbody2D> (); //Detect the rigidbody
		rigidbody.velocity = new Vector2 (0, -projectileSpeed); //initialize the velocity
		AudioSource.PlayClipAtPoint (fireSound, transform.position);//Play the audioclip
	}
	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.tag == "Player") { //If the tag is "Player" the enemy is destroyed

			Destroy (gameObject);
		}
		if (collision.gameObject.tag == "diferente") { //If the tag is "diferente" the function "Enemya" is called to remove life of the player
	
			collision.SendMessage ("Enemya");

		}
	}
	void FixedUpdate ()
	{
		float time2 = Speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, puntero.position, time2);//Indicates the movement
		if (transform.position == puntero.position) { //If the position of this object is the same as that of the pointer
			if (puntero.position == inicio) {//If the pointer is in the beginning
				puntero.position = final; //Change the position to follow, to the position "final"

				transform.localScale = new Vector3 (1f,1f, 1f);
			} else {
				puntero.position = inicio; //If not ,change the position to follow, to the position "beginning"
				transform.localScale = new Vector3 (-1f,1f, 1f);
			}
		}
	}
	// Update is called once per frame
	void Update () {

		float probability = shotsPerSeconds * Time.deltaTime; //Initialize the probability


		if (Random.value < probability) { //If the random value is less than the probability,then fire
			Fire ();
		}

	}
}
