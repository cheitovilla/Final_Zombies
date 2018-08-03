using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Admin Ready, (Cambiar algunas variables)
public class Admin : MonoBehaviour 
{
	//Creamos unas cuantas variables
	public Text cant_ciu;
	public Text cant_enem;
	public Text cant_mutant;
	public Image image;
	public int numNPC;
	public GameObject[] Npcs;
	public static int NumEnemy;
	public static int NumCiudadano;
    public static int NumMutants;
	public int life;
	public float max_img, min_img;

	GameObject zombicito;
	GameObject ciudadanito;
    GameObject mutancito;

    public Image win;
    public Image lose;


	// Use this for initialization
	void Start () 
	{
		//Definimos variables con valores iniciales
        Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		numNPC = Random.Range (10, 20);
		Npcs = new GameObject[numNPC];
		life = 400;
		max_img = life;

		//en este apartado aparece al azar la cantidad de zombies, mutantes y ciudadanos con posicines randon y su respectivo componente
		for (int i = 0; i < numNPC; i++) 
		{
			int kind_npc = Random.Range (1, 4);

			//Componentes de Zombie
			if (kind_npc == 1) 
			{
				 zombicito = Instantiate (Resources.Load ("Zombie", typeof(GameObject))) as GameObject;
				zombicito.AddComponent (typeof(Enemy));
				zombicito.tag = "Zombie";
				zombicito.transform.position = Select_Position();
			
				Npcs [i] = zombicito;
			} 
			//Componentes de Ciudadano
			else if (kind_npc == 2)
			{
				 ciudadanito = Instantiate (Resources.Load ("BlueSuitFree01", typeof(GameObject))) as GameObject;
				ciudadanito.AddComponent (typeof(Ciudadano));
				ciudadanito.tag = "Ciudadano";
				ciudadanito.transform.position = Select_Position();

				Npcs [i] = ciudadanito;
			}

			//Componentes de mutante
            else
            {
                mutancito = Instantiate(Resources.Load("Mutant", typeof(GameObject))) as GameObject;
                mutancito.AddComponent(typeof(Mutant));
                mutancito.tag = "Mutant";
                mutancito.transform.position = Select_Position();
                Npcs[i] = mutancito;
            }


		}

		//contabilizamos cantidad de cada personaje
        Mutant[] mutants = FindObjectsOfType<Mutant>();
        NumMutants = mutants.Length;
		cant_mutant.text = NumMutants.ToString ();

		Enemy[] enemies = FindObjectsOfType<Enemy> ();
		NumEnemy = enemies.Length;
        cant_enem.text = NumEnemy.ToString(); 

		Ciudadano[] ciudadanos = FindObjectsOfType<Ciudadano> ();
		NumCiudadano = ciudadanos.Length;
		cant_ciu.text = NumCiudadano.ToString ();

       

	}
	
	// Update is called once per frame
	void Update () 
	{
		//Lo que sucede cuando el jugador gana	
		if (NumEnemy <=0 && NumMutants <=0) 
		{
            win.gameObject.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
			Time.timeScale = 0;
		}
		//lo que sucede cuando el jugador pierde
		if (life <=0) 
		{
			Cursor.lockState = CursorLockMode.Confined;
            lose.gameObject.SetActive(true);
            Cursor.visible = true;
            Camera.main.transform.SetParent (null);
			Time.timeScale = 0;
		
		}
	}

	//Posicion randon al aparecer los diferentes zombies, mutantes y ciudadanos
	Vector3 Select_Position()
	{
		Vector3 pos = new Vector3();
		pos.x = Random.Range(-20, 20);
		pos.y = 0.5f;
		pos.z = Random.Range(-20, 20);
		return pos;
	}

	//funcion que cuenta los zombies muertos
	public void KillEnemy()
	{
		NumEnemy--;
		cant_enem.text = NumEnemy.ToString ();
	}

	//funcion que cuenta los mutantes muertos
	public void KillMutant()
	{
		NumMutants--;
		cant_mutant.text = NumMutants.ToString ();
	}

	//funcion de perder vida con zombie
	public void LoseLife()
	{
		life -= 30;
		image.fillAmount = (life) / max_img;
	}

	//funcion de perder vida con un mutante
    public void LoseLifeMutant()
    {
        life -= 70;
        image.fillAmount = (life) / max_img;
    }

	//funcion de recuperar vida con el gameobject recolectable de salud
	public void GetLife()
	{
        if (life == 400)
        {
            image.fillAmount = (life) / 1;
        }
		life += 30;
		image.fillAmount = (life) / max_img; 
	}

	//funcion que añade textualmente a zombies cuando estos mismos mata ciudadanos
	public void BornZombie()
    {
		NumEnemy++;
		cant_enem.text = NumEnemy.ToString ();
	}

	//funcion que contabiliza los ciudadnaos mueltos
	public void KillCiudadano()
	{
		Debug.Log ("Ciudadnao muelto");
		Destroy (ciudadanito);
		NumCiudadano--;
		cant_ciu.text = NumCiudadano.ToString ();
	}


}
