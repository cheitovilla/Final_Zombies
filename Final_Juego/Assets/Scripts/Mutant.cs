using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutant : NPC
{
	// creamos algunas vaariables a necesitar
    public Animator animM;
    GameObject[] obj;

	// Use this for initialization
	void Start () {
        Link_Start();
        animM = GetComponent<Animator>();
        obj = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
	}
	
	// Se actualiza constantemente el metodo de buscar y movimiento
	void Update () {
        Movement();
        Search();
	}

    public override void Link_Start()
    {
        base.Link_Start();
    }

	//Se crean las diferentes colisiones que va tener el mutante con la espada y con el ciudadano
    public void OnCollisionEnter(Collision collM)
    {
		//Lo que sucede si colisiona con la espada del player
        if (collM.gameObject.tag == "Sword")
        {
            animM.SetTrigger("deadMutant");
            Destroy(gameObject, 5);
			FindObjectOfType<Admin> ().KillMutant ();

        }

		//Lo que sucede si colisiona con el ciudadano
        if (collM.gameObject.tag == "Ciudadano")
        {
            animM.SetTrigger("attackMutant");
            Destroy(collM.gameObject, 0.5f);
            FindObjectOfType<Admin>().KillCiudadano();
            
        }
    }

	//Metodo de buscar a ciudadano o heroe
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
                         animM.SetTrigger("attackMutant");
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
