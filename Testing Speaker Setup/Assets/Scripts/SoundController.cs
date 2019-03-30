using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour {


    public AudioMixer MainMix;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            SetEcho();
        }
    }

    public void SetEcho()
    {
        MainMix.SetFloat("Echo", 1500f);
    }


    //MainMix.SetFloat("Echo", 1500f);



}
