using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAnim : MonoBehaviour {

    public Animator anim;
    public ChallengeController cc;
    public GameObject upArrow;

	// Use this for initialization
	void Start ()

    {
        
       


	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!cc.isChallengeComplete)
        {
            Debug.Log("Arrow says challenge incomplete");
            upArrow.SetActive(true);

            anim.Play("ArrowUp");
        }

        else
        {
            Debug.Log("Arrow says challenge complete");
            upArrow.SetActive(false);
        }
    }
}
