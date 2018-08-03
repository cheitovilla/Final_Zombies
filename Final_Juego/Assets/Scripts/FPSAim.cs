using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class FPSAim : MonoBehaviour 
{
	float mouseX;
	float mouseY;

	
	// Update is called once per frame
	void Update () {
		//Movimiento del mouse
		mouseX += Input.GetAxis("Mouse X");
		
		//la rotacion
		transform.eulerAngles = new Vector3(0, mouseX, 0);
	}
}
