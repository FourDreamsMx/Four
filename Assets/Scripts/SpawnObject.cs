using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnObject : MonoBehaviour {

    public GameObject[] Basura;
    private int Ancho = 0;
    private int Alto = 0;
    private int maximoObjetos = 10;
    private int objetos = 0;

    private float x;
    private float y;
    // Use this for initialization
    void Start () {
        
        objetos = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if(objetos < maximoObjetos)
        {            
            StartCoroutine(CreaObjeto());           
            objetos++;
        }

        if (SceneManager.GetActiveScene().name == "Nivel1Basura")
        {            

            if (GameObject.FindGameObjectsWithTag("Organica").Length + GameObject.FindGameObjectsWithTag("Inorganica").Length == 0 && MonedasTotales._inicio)
            {
                if (MonedasTotales._monedasTotales == 10)
                    Application.LoadLevel("Menu");
                else
                    Application.LoadLevel("GameOver");
            }
            else
            {

            }
        }
    }

    void ObtenerPosicion()
    {
        x = Random.Range(-2.53f, 2.53f);
        y = Random.Range(3.90f, -1.0f);
    }

    IEnumerator CreaObjeto()
    {
        yield return new WaitForSeconds(1);
        ObtenerPosicion();
        Instantiate(Basura[Random.Range(0, 5)], new Vector3(x, y, 0), Quaternion.identity);
    }
}
