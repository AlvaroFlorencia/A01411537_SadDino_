using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour {
	public Transform dino;
	public Vector3 offset;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float Vectorx = Mathf.Clamp (dino.position.x, -7.1f, 210f); //limited to the scene
		transform.position = new Vector3 (Vectorx + offset.x, dino.position.y + offset.y+2f, offset.z); //Follow the player
	}
}
