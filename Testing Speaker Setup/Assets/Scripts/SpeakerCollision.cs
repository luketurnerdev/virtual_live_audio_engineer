using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerCollision : MonoBehaviour {

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
            Debug.Log("Player detected");
        }

    }
}
