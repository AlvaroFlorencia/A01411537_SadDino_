using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class projectile : MonoBehaviour {

	// Use this for initialization
	float damage=200f;
	public GameObject explosion;  //Particles
	public AudioClip fireSound;   //Audioclip
		void Start () {
		this.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, 5f, 0);//initialize a speed in y

	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.tag == "Player") {
			AudioSource.PlayClipAtPoint (fireSound, transform.position);    //Destroy the projectile without damage
			PuffSmoke ();

			Destroy (gameObject);

		}
		if (collision.gameObject.tag == "diferente") {   //The projectile is destroyed and the "Enemya" function is called to remove the player's life
			
			collision.SendMessage ("Enemya");
			AudioSource.PlayClipAtPoint (fireSound, transform.position);
			PuffSmoke ();
			Destroy (gameObject);



		}
		if (collision.gameObject.tag == "damaged") {//Destroy the projectile with this tag
			AudioSource.PlayClipAtPoint (fireSound, transform.position);
			PuffSmoke ();//The particles are started
			Destroy (gameObject);


		}
		if (collision.gameObject.tag == "plataforma") {//Destroy the projectile  with this tag
			AudioSource.PlayClipAtPoint (fireSound, transform.position);
			PuffSmoke ();//The particles are started
			Destroy (gameObject);
		

		}


	}
	void PuffSmoke() {  //Particles

		GameObject smokePuff = Instantiate (explosion, transform.position, Quaternion.identity);
		ParticleSystem particule = smokePuff.GetComponent<ParticleSystem> (); 
		var particulem = particule.main; 


	}



}
