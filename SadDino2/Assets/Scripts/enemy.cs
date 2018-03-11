using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
	public float maxSpeed = 1f;
	public float speed = 1;
	private Rigidbody2D rigidbody;
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D> ();	
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	void FixedUpdate(){
		rigidbody.AddForce (Vector2.right * speed); //Add force to move the enemy
		float xmspeed = Mathf.Clamp (rigidbody.velocity.x, - maxSpeed, maxSpeed); //Limit the speed with the max speed
		rigidbody.velocity = new Vector2 (xmspeed, rigidbody.velocity.y);////Reset with the maxspeed

		if (rigidbody.velocity.x >- 0.01f && rigidbody.velocity.x < 0.01f) { //eliminate bugs in the animator with the "idle" animation
			speed = -speed;
			rigidbody.velocity = new Vector2 (speed, rigidbody.velocity.y); //Reset the speed

		}
		if (speed> 0) {
			transform.localScale = new Vector3 (1f,1f, 1f);  //If the speed is postive the local scale in x is postive 
		}
		else if (speed <0) {
			transform.localScale = new Vector3 (-1f, 1f, 1f); //If the speed is postive the local scale in x is negative
		}
	
	}
	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.tag == "Player") { //If the tag is "Player" the enemy is destroyed
			
			Destroy (gameObject);
		}
		if (collision.gameObject.tag == "diferente") {  //If the tag is "diferente" the function "Enemya" is called to remove life of the player
			
			collision.SendMessage ("Enemya");


		}

	
	}

}
