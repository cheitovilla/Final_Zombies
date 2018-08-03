using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NPC Ready

//un enum para los estado de juego
public enum States_Game
{
	Idle, Moving, Rotating, Attack
};

public class NPC : MonoBehaviour 
{
    
	//Definimos algunas variables
	bool start = false;
	int years = 0;
	public float speed = 0f;
	States_Game state;
	Vector3 rotation;


	// Lo que sucede en cada frame
	void Update ()
	{
		if (!start)
		{
			Link_Start();
			start = true;            
		}
		StartCoroutine(SelectState());
	}

	//el inicializador
	public virtual void Link_Start()
	{
		Select_Years ();
		speed = ((100f - years) / 50f);
		StartCoroutine(SelectState());
	}


	//Metodo de movimiento, rotar y attacar
	public void Movement()
	{
		if(state == States_Game.Moving)
		{
			transform.position += transform.forward * speed * Time.deltaTime;
           // animZ.SetTrigger("walkZombie");
		}
		if (state == States_Game.Rotating)
		{
			transform.eulerAngles += rotation;
          //  animZ.SetTrigger("idleZombie");
		}
		if (state == States_Game.Attack)
		{
          //  animZ.SetTrigger("attackZombie");
		}
	}

	//Metodo y Rango de edad para los ciudadanos
	public void Select_Years()
	{
		 years = Random.Range(15, 101);
	}

	//corrutina para cambiar estados de juegos cada x cantidad de segundos
	IEnumerator SelectState()
	{
		yield return new WaitForSeconds(3);
		state = (States_Game)Random.Range(0, 3);
		StartCoroutine(SelectState());
		rotation.y = Random.Range(-1, 2);
	}

	//funcion para retornar la edad
	public int Get_Years()
	{
		return years;
	}
}
