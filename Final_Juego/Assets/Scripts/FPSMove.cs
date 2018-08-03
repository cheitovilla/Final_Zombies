using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMove : MonoBehaviour 
{
	float speed = 2f;//variable para la velocidad
	// Use this for initialization

	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.W))
		{
			transform.position += transform.forward * speed*Time.deltaTime ;
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.position -= transform.forward * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.A))
		{
			transform.position -= transform.right * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.position += transform.right * speed * Time.deltaTime;
		}
	}
}
