using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Hero listo
public class Hero : MonoBehaviour 
{
	//El objeto a recolectar
    GameObject vida;

	//asignamos componente al posedor del script
	void Start () {
		this.gameObject.tag = "Player";
		this.gameObject.AddComponent<FPSAim> ();
	}

	//Definimos colisiones del heroe
	private void OnCollisionEnter(Collision collision)
	{
		//Lo que sucede si colisiona con un zombie
		if (collision.gameObject.tag == "Zombie")
		{
			FindObjectOfType<Admin>().LoseLife();
		}

		//Lo que sucede si colisiona con un mutante
		else if (collision.gameObject.tag == "Mutant") 
		{
			FindObjectOfType<Admin> ().LoseLifeMutant ();	

		}

		//Lo que sucede si colisiona con un ciudadano
		else if (collision.gameObject.tag == "Ciudadano")
		{
			int years = collision.gameObject.GetComponent<Ciudadano>().Get_Years();
			Debug.Log("Hola soy  " + collision.gameObject.GetComponent<Ciudadano>().names + " y tengo " + years + " años." );
		}

		//Lo que sucede si colisiona con el gameobject de vida
		else if (collision.gameObject.tag == "lifeUp") 
		{
			FindObjectOfType<Admin> ().GetLife ();
			Destroy (collision.gameObject);
            vida = Instantiate(Resources.Load("Life", typeof(GameObject))) as GameObject;
            vida.transform.position = new Vector3(Random.Range(-25, 25), 1f, Random.Range(-25, 25));
            vida.tag = "lifeUp";
            
        }

	}
}
