using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Ciudadano Ready

//Un enum con 20 nombres random
public enum NameCiudadanos
{
	mateo, juan, lucas, marcos, fredy, abraham, elkin, krillin, hitler, maria, judas, el_pirilo, vegeta77, elrubiosomg, justin, 
	magia_nrega, josejuaquin, willian, jhon, mario
}
	

public class Ciudadano : NPC 
{

	public NameCiudadanos names;

	// Use this for initialization
	void Start () 
	{
		Link_Start ();
		Select_Name ();
	}
	
	// se actualiza cada frame el movimiento de los presentes en la escena
	void Update () 
	{
		Movement ();
	}

	//funcion para seleccionar nombre randon de los ciudadanos
	void Select_Name()
	{
		names = (NameCiudadanos)Random.Range (0, 20);
	}


	public static implicit operator Enemy(Ciudadano ciudadano)
	{
		Enemy enemi = ciudadano.gameObject.AddComponent<Enemy> ();
		Destroy (ciudadano);
		return enemi;
	}

}
