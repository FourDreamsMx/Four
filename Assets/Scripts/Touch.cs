using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Touch : MonoBehaviour {
	private Vector3 PuntoPantalla; 
	private Vector3 OffSet;
    public Text Monedas;    
    private bool inicio = false;

    // Use this for initialization
    void Start () {
        Monedas = GameObject.FindGameObjectWithTag("Texto").GetComponent<Text>();        
        MonedasTotales._inicio = false;
    }
	
	// Update is called once per frame
	void Update () {        
	}
	void OnMouseDown(){
		OffSet = gameObject.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, PuntoPantalla.z));
	}
	void OnMouseDrag(){
		Vector3 PuntoActual = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, PuntoPantalla.z);
		Vector3 Posicion = Camera.main.ScreenToWorldPoint (PuntoActual) + OffSet;
		transform.position = Posicion;
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        MonedasTotales._inicio = true;
        Debug.Log(GameObject.FindGameObjectsWithTag("Organica").Length + GameObject.FindGameObjectsWithTag("Inorganica").Length);

        if (coll.gameObject.tag.Substring(4) == gameObject.tag)
        {            
            MonedasTotales._monedasTotales++;
            Monedas.text = "Monedas: " + MonedasTotales._monedasTotales;
            if(MonedasTotales._monedasTotales == 10)
                Application.LoadLevel("Menu");

        }
        else
        {
            //Quitar vida
            int vidas = GameObject.FindGameObjectsWithTag("Vida").Length;
            DestroyObject(GameObject.FindGameObjectsWithTag("Vida")[vidas - 1]);

            //Game over
            if(vidas == 1)
            {
                Application.LoadLevel("GameOver");
            }
        }

        DestroyObject(this.gameObject);
    }
}
