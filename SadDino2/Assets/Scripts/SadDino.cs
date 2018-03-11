using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SadDino : MonoBehaviour {
	public float speed = 2.0f;
	public float maxSpeed=5.0f;
	private Rigidbody2D rigidbody;
	public bool tocandoPiso;
	public bool telarana;
	public bool ataque;
	public GameObject projectile;
	private SpriteRenderer sprite;
	public int vida=6;
	private LevelManager levelManager;
	public float projectileSpeed;
	public Animator animator;
	public float brinco =7.0f;
	public float firingRate = 0.2f;
	public Text vidas;
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D> ();
		sprite =GetComponent<SpriteRenderer> ();
		levelManager = FindObjectOfType<LevelManager>(); 

	}
	
	// Update is called once per frame
	void Update () {
		if (vida == 0) {
			levelManager.LoadLevel("Eliminado");
		}
		else if(vida == 1){
			vidas.text="♥";
		}
		else if(vida == 2){
			vidas.text="♥♥";
		}
		else if(vida ==3){
			vidas.text="♥♥♥";
		}
		animator=GetComponent<Animator>();
		animator.SetFloat ("Speed", Mathf.Abs(rigidbody.velocity.x));
		animator.SetBool ("piso", tocandoPiso);
		animator.SetBool ("Disparando", ataque);
		animator.SetBool ("tela", telarana);

	}
	void FixedUpdate(){
		
	 float a= Input.GetAxis("Horizontal");
		float b= Input.GetAxis("Vertical");//Saved 1 to -1 in the horizontal moves
		rigidbody.AddForce(Vector2.right*speed*a);
		if (rigidbody.velocity.x > maxSpeed) {
			rigidbody.velocity = new Vector2 (maxSpeed, rigidbody.velocity.y);
		} 
		if (rigidbody.velocity.x < -maxSpeed) {
			rigidbody.velocity = new Vector2 (-maxSpeed, rigidbody.velocity.y);
		} 
		if (a > 0f) {
			transform.localScale = new Vector3 (1f,1f, 1f);
		}
		if (a <0f) {
			transform.localScale = new Vector3 (-1, 1, 1f);
		}
		if (b > 0f && tocandoPiso==true) {
			tocandoPiso = false;
			rigidbody.AddForce (Vector2.up * brinco, ForceMode2D.Impulse);
		}
		if (b <0f) {
			tocandoPiso = true;
		}
		if (Input.GetKey (KeyCode.Space)) {

			ataque = true;
			rigidbody.tag="Player";
		
		} else {
			ataque = false;
			rigidbody.tag="diferente";
		}




	}
	public void Enemya(){
		vida--;

		rigidbody.AddForce(Vector2.up*speed*20f);
		rigidbody.velocity = new Vector2 (maxSpeed, rigidbody.velocity.y);





	}



		
	}