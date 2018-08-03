using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//enum de las diferentes partes de cuerpo que le gusta a los zombies
public enum BodyParts
{
	Cabeza, Brazos, Piernas, Nalgas, Abdomen
}

public class Enemy : NPC 
{
	//Definioms algunas variables
    public Animator animZ;
    public BodyParts partBody;
	GameObject[] obj;
	public GameObject go;

	// Use this for initialization
	void Start () 
	{
		
        animZ = GetComponent<Animator>(); // animacion zombie
		Link_Start (); // metodo de iniciar
		obj = GameObject.FindObjectsOfType (typeof(GameObject)) as GameObject[];

	}
	
	// Update is called once per frame
	void Update () 
	{
        Movement();
		Search ();
	}


	//metodo de iniciar
	public override void Link_Start()
	{
		base.Link_Start ();
		partBody = (BodyParts)Random.Range (0, 5); // 
        
	}


	//Definimos las diferentes colisiones que va tener el Zombie y que ocurre en cada una de ellas
	public void OnCollisionEnter(Collision collision)
	{
		//Si colisiona con la espada
		if(collision.gameObject.tag == "Sword")
		{
            animZ.SetTrigger("deadZombie");
			Debug.Log("me golpeo la espada");
			FindObjectOfType<Admin>().KillEnemy();
			Destroy(gameObject,1);
		}
		//Si colisiona con un ciudadano
		if (collision.gameObject.tag == "Ciudadano")
		{
            animZ.SetTrigger("attackZombie");
			Ciudadano ciu = collision.gameObject.GetComponent<Ciudadano> ();
			Enemy enem = ciu;
			enem.tag = "Zombie";
            Destroy(collision.gameObject, 0.1f);
			go =  Instantiate (Resources.Load ("Zombie", typeof(GameObject))) as GameObject;
			go.transform.position = this.gameObject.transform.position;
			go.tag = "Zombie";
			go.AddComponent<Enemy> ();
			FindObjectOfType<Admin>().BornZombie();
			FindObjectOfType<Admin>().KillCiudadano();
          

		}

	}


	//Funcion para que el zombie busque ciudadano
	void Search()
	{
		foreach (GameObject go in obj)
		{
			if (go != null)
			{      
				if (go.GetComponent<Hero>() || go.GetComponent<Ciudadano>())
				{
					float dist = Vector3.Distance(go.transform.position, transform.position);

					if (dist < 5f)
					{
                        animZ.SetTrigger("attackZombie");
						Vector3 direccion = go.transform.position - transform.position;
						dist = direccion.magnitude;
						transform.LookAt(go.transform.position);
						transform.position += Vector3.Normalize(go.transform.position - transform.position) * speed * Time.deltaTime;
					}
				}
			}

		}
	}
}
