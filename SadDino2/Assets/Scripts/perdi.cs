using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perdi : MonoBehaviour {

	private LevelManager levelManager;
	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>(); 
	}

	// Update is called once per frame
	void Update () {


	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.CompareTag("diferente")){ //If this player's tag is detected, it is changed to the scene "Eliminado"
			levelManager.LoadLevel("Eliminado");
		}
		if(collision.gameObject.CompareTag("Player")){ //If this player's tag is detected, it is changed to the scene "Eliminado"
			levelManager.LoadLevel("Eliminado");
		}





	}
}
