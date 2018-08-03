using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Player : MonoBehaviour 
{
	//Definimos algunas variables
	public float speedx2 = 4f;
    public Animator anim;
	public float moveSpeed = 2f;
	public float turnSpeed = 100f;
	public GameObject dead;

	// Inicializamos
	void Start () {
		anim = GetComponent<Animator> ();
		anim.SetTrigger ("idle");
	}
	
	// Aqui se reproducen algunas animaciones del heroe cuando avanza
	void Update () 
	{

		if (Input.GetKey (KeyCode.W)) 
		{
			anim.SetTrigger ("moving");
			transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
		}
		else if (Input.GetKey (KeyCode.S)) 
		{
			transform.Translate (-Vector3.forward * moveSpeed * Time.deltaTime);
			anim.SetTrigger ("movingdown");
		}
		else if (Input.GetKey (KeyCode.A)) 
		{
			transform.Rotate (Vector3.up, -turnSpeed * Time.deltaTime);
		}
		else if (Input.GetKey (KeyCode.D)) 
		{
			transform.Rotate (Vector3.up, turnSpeed * Time.deltaTime);
		}
		else if (Input.GetButtonDown("Fire1")) 
		{
			anim.SetTrigger ("Attack");
		//	dead.gameObject.SetActive (true);
		} 
		else
		{
			anim.SetTrigger ("idle");	
			//dead.gameObject.SetActive (false);
		}

		//Si presiona shift camina mas rapido
		if (Input.GetKey(KeyCode.LeftShift)) 
		{
			if (Input.GetKey (KeyCode.W)) 
			{
				anim.SetTrigger ("moving");
				transform.Translate (Vector3.forward * speedx2 * Time.deltaTime);
			}
			else if (Input.GetKey (KeyCode.S)) 
			{
				transform.Translate (-Vector3.forward * speedx2 * Time.deltaTime);
				anim.SetTrigger ("movingdown");
			}
		}
	}
}
