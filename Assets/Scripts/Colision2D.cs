using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision2D : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log(coll.gameObject.tag);
        GameObject.DestroyObject(GameObject.FindGameObjectWithTag("Player"));
    }
        

}
