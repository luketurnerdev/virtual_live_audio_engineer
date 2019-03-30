using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class FXController : MonoBehaviour
{
    public Text titleText;
    public MixingConosle mc;
    public AudioMixer foh;
    public GameObject fxPanel;
    public GameObject onBoardFX;
    public Slider slider;

    public float reverbFloat;
    public string effectName;

    public Renderer fxRend;

    public Animator anim;

    //Sliders//

    public Slider reverbSlider;

    //Bools//

    public bool isFxPanelActive = false;
    public bool animPlayed = false;

    //Bools - Testing //



    // Use this for initialization
    void Start()
    {
        onBoardFX.SetActive(false);
        anim = onBoardFX.GetComponent<Animator>();
        
    }
    public void WakeUp()
    {
        anim.Play("WakeUp");
    }

    

    // Update is called once per frame
    void FixedUpdate()
    {
        //TODO FIX THIS SO THAT REVERB UPDATES WHEN IT NEEDS TO
        


        slider.onValueChanged.AddListener(delegate { SetReverbFloat(slider.value); });

        if (isFxPanelActive)
        {
            SetReverb(mc.channelSelected, effectName, reverbFloat);
        }




    }

    public void UpdateText(int channelNumber)
    {
        if (isFxPanelActive)
        {
            SetTitleText(channelNumber);
        }
            
    }

    //Open the FX panel for a certain channel that is selected
    public void FXPanel(int channelNumber)
    {

        SetTitleText(channelNumber);
        
        print("Activated FX Panel with argument of " + channelNumber);




       

        

    }

    public void SetReverb(int channelSelected, string effectName, float reverbFloat )
    {
        Debug.Log("SetReverb activated with name " + effectName);
        

        switch (channelSelected)
        {
            case 0:
                //foh.SetFloat("MasterVol", volume);
                break;

            case 1:
                foh.SetFloat("Channel1Reverb", slider.value);
                Debug.Log("case selected");

                break;

            case 2:
                foh.SetFloat("Channel2Reverb", reverbFloat);
                break;

            case 3:
               // foh.SetFloat("Channel3Vol", volume);
                break;

            default:
                print("Dinovs");
                break;
        }

        //foh.SetFloat("channel1Reverb)", value);
    }

    public void SetReverbFloat(float reverbValue)
    {
        //Reverb Slider value stored in temporary float - then used in SetReverb();
        
        //reverbFloat = reverbSlider.value;
        
        print(reverbValue);
        
        
    }

    
    public void SetTitleText(int currentChannel)
    {

        titleText.text = "Channel: " + currentChannel;
    }

    public void ToggleFXPanel(int channelNumber)
    {
        
        SetTitleText(channelNumber);




        if (!isFxPanelActive)
        {
            //Turn FX Panel on
            //fxPanel.SetActive(true);
            isFxPanelActive = true;

            fxRend.material.color = Color.cyan;

            //New method: activating onboardfx animation
            onBoardFX.SetActive(true);

            WakeUp();
            animPlayed = true;
            

        }

        else
        {
            //Turn FX Panel off
           // fxPanel.SetActive(false);
            isFxPanelActive = false;
            fxRend.material.color = Color.white;
            StartCoroutine(Sleep());
            
        }

        

    }



    //Plays the animation, waits a given time then turns off fx panel

    IEnumerator Sleep()
    {
        anim.Play("Sleep");
        yield return new WaitForSeconds(1.25f);
        onBoardFX.SetActive(false);
    }


}
