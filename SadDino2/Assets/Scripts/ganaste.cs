using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ganaste : MonoBehaviour {
	private LevelManager levelManager;
	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();  //Find the level manager
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision){             //If the player's tags is detected, it is changed to the scene
		if(collision.gameObject.CompareTag("diferente")){
			levelManager.LoadLevel("Ganaste");
		}
		if(collision.gameObject.CompareTag("Player")){
			levelManager.LoadLevel("Ganaste");
		}





	}
}
