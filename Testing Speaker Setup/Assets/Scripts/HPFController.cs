using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class HPFController : MonoBehaviour {
    public AudioMixer foh;
    public GameObject hpf1, hpf2, hpf3, hpf4, hpf5, hpf6;
    public MixingConosle mc;
    private float hpfAmount;

    bool HPF1Active, HPF2Active, HPF3Active, HPF4Active, HPF5Active, HPF6Active = false;

    private Renderer rend1, rend2, rend3, rend4, rend5, rend6;




	// Use this for initialization
	void Start ()
    {
        hpfAmount = 10;

        rend1 = hpf1.GetComponent<Renderer>();
        rend2 = hpf2.GetComponent<Renderer>();
        rend3 = hpf3.GetComponent<Renderer>();
        rend4 = hpf4.GetComponent<Renderer>();
        rend5 = hpf5.GetComponent<Renderer>();
        rend6 = hpf6.GetComponent<Renderer>();

    }
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.H))
        {

            ToggleHPF(mc.channelSelected, hpfAmount);

            




        }
    }

    public void ToggleHPF(int currentChannel, float amount)
    {
        switch (currentChannel)
        {
            case 1:
                if (!HPF1Active)
                {
                    hpfAmount = 100;
                    foh.SetFloat("HPF1", hpfAmount);
                    HPF1Active = true;
                    rend1.material.color = Color.yellow;
                }

                else
                {
                    hpfAmount = 10;
                    foh.SetFloat("HPF1", hpfAmount);
                    HPF1Active = false;
                    rend1.material.color = Color.white;
                }
                
                break;


            case 2:
                if (!HPF2Active)
                {
                    hpfAmount = 100;
                    foh.SetFloat("HPF2", hpfAmount);
                    HPF2Active = true;
                    rend2.material.color = Color.yellow;
                }

                else
                {
                    hpfAmount = 10;
                    foh.SetFloat("HPF2", hpfAmount);
                    HPF2Active = false;
                    rend2.material.color = Color.white;
                }

                break;

            case 3:
                if (!HPF3Active)
                {
                    hpfAmount = 100;
                    foh.SetFloat("HPF3", hpfAmount);
                    HPF3Active = true;
                    rend3.material.color = Color.yellow;
                }

                else
                {
                    hpfAmount = 10;
                    foh.SetFloat("HPF3", hpfAmount);
                    HPF3Active = false;
                    rend3.material.color = Color.white;
                }

                break;

            case 4:
                if (!HPF4Active)
                {
                    hpfAmount = 100;
                    foh.SetFloat("HPF4", hpfAmount);
                    HPF4Active = true;
                    rend4.material.color = Color.yellow;
                }

                else
                {
                    hpfAmount = 10;
                    foh.SetFloat("HPF4", hpfAmount);
                    HPF4Active = false;
                    rend4.material.color = Color.white;
                }

                break;

            case 5:
                if (!HPF5Active)
                {
                    hpfAmount = 100;
                    foh.SetFloat("HPF5", hpfAmount);
                    HPF5Active = true;
                    rend5.material.color = Color.yellow;
                }

                else
                {
                    hpfAmount = 10;
                    foh.SetFloat("HPF5", hpfAmount);
                    HPF5Active = false;
                    rend5.material.color = Color.white;
                }

                break;

            case 6:
                if (!HPF6Active)
                {
                    hpfAmount = 100;
                    foh.SetFloat("HPF6", hpfAmount);
                    HPF6Active = true;
                    rend6.material.color = Color.yellow;
                }

                else
                {
                    hpfAmount = 10;
                    foh.SetFloat("HPF6", hpfAmount);
                    HPF6Active = false;
                    rend6.material.color = Color.white;
                }

                break;

        }
    }
}
