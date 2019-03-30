using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderController : MonoBehaviour {

    public AudioMixer foh;
    public Slider slider;
    public FXController fxCont;

	// Use this for initialization
	void Start ()
    {
        

    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //slider.onValueChanged.AddListener(delegate { fxCont.SetReverbFloat(); });
        


    }

    public void ValueChangedCheck()
    {
        Debug.Log(slider.value);
    }
}
