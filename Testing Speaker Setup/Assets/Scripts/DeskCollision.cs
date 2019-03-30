using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskCollision : MonoBehaviour {

    public GameObject mainScript;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            //activate script
            Debug.Log("Desk Collision");
        }
    }
}
