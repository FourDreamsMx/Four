using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cambionivel : MonoBehaviour {
	public float tiempo = 1.0f;
	public string nombrenivel;
	// Use this for initialization
	void Start () {
		StartCoroutine (Wait ());
	}
	
	// Update is called once per frame
	void Update () {
		 
	}

	void Cambiar(){
		Application.LoadLevel (nombrenivel);
	}

	IEnumerator Wait(){
		
		yield return new WaitForSeconds (tiempo);
		Cambiar ();
			
	}
}
