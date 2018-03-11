using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour {

	private SadDino colissiondino;
	// Use this for initialization
	void Start () {
		colissiondino = GetComponentInParent<SadDino> ();
	}
	void OnCollisionStay2D(Collision2D collision){  //To elimnate the bug when the in theory the player is falling,make a relationship
		colissiondino.tocandoPiso = true;
		if (collision.gameObject.tag == "plataforma") {
			
			colissiondino.transform.parent = collision.transform;  //Process of tranform the collision in parent
		}
	}	
	void OnCollisionExit2D(Collision2D collision){ //Eliminate the relationship
		colissiondino.tocandoPiso = false;
		if (collision.gameObject.tag == "plataforma") {
			colissiondino.transform.parent = null;
		}
	}	
	// Update is called once per frame
	void Update () {
		
	}
}
