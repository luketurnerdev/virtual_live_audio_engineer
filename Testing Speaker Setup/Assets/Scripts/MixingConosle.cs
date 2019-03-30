using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixingConosle : MonoBehaviour
{
    //UI Elements//

    
    //External Scripts//

    public FXController fxCont;

    // Mixing Channels //
    public GameObject masterChannel, channel1, channel2, channel3, channel4, channel5, channel6;

    public int channelSelected;

    // Other Objects //
    public GameObject player;
    public GameObject notch1, notch2, notch3, notch4, notch5, notch6, masterNotch;
    public GameObject speaker;
    public AudioMixer foh;
    public GameObject masterClippingLight, clippingLight1, clippingLight2, clippingLight3, clippingLight4, clippingLight5, clippingLight6;

    // Materials //
    public Material fader1Material, fader2Material, fader3Material, fader4Material, fader5Material, fader6Material, masterMaterial, deskMaterial;

    //Lights//

    public GameObject deskLight;

    //Renderers//
    private Renderer masterRend, rend1, rend2, rend3, rend4, rend5, rend6;

    // Bool / Debug //
    public bool isMasterClipping, is1Clipping, is2Clipping, is3Clipping, is4Clipping, is5Clipping, is6Clipping;

    
    private bool isFxPanelActive = false;
    public bool isMixerActive = false;

    //Volume
    public float masterVolume, channel1Volume, channel2Volume, channel3Volume, channel4Volume, channel5Volume, channel6Volume;
    public float volumeAlteration;

    //Keep track of notch position on fader
    public int masterNotchPos, notchPos1, notchPos2, notchPos3, notchPos4, notchPos5, notchPos6;
    



    void Start()
    {
       




        //Assignments //

        //Colliders / Triggers //
        //TODO add colliders when near desk that activates tooltip

        // Rendering //
        masterRend = masterChannel.GetComponent<Renderer>();
        rend1 = channel1.GetComponent<Renderer>();
        rend2 = channel2.GetComponent<Renderer>();
        rend3 = channel3.GetComponent<Renderer>();
        rend4 = channel4.GetComponent<Renderer>();
        rend5 = channel5.GetComponent<Renderer>();
        rend6 = channel6.GetComponent<Renderer>();

        masterNotchPos = 0;
        notchPos1 = 0;
        notchPos2 = 0;
        notchPos3 = 0;
        notchPos4 = 0;
        notchPos5 = 0;
        notchPos6 = 0;

        // Initialize channel at default '100' so that no channel is selected
        channelSelected = 100;

        //Clipping status//

        is1Clipping = false;
        is2Clipping = false;
        is3Clipping = false;
        is4Clipping = false;
        is5Clipping = false;
        is6Clipping = false;
        isMasterClipping = false;

        //Initializing the faders at -80dB:

        // 1. Variable assignment 

        masterVolume = -80f;

        channel1Volume = -80f;
        channel2Volume = -80f;
        channel3Volume = -80f;
        channel4Volume = -80f;
        channel5Volume = -80f;
        channel6Volume = -80f;


        // 2. Actual assignment

        

        //Initalize Fader Colours

        masterRend.material.color = Color.white;
        rend1.material.color = Color.white;
        rend2.material.color = Color.white;
        rend3.material.color = Color.white;
        rend4.material.color = Color.white;
        rend5.material.color = Color.white;
        rend6.material.color = Color.white;

        //Initialize light states

        deskLight.SetActive(false);

    }


    void Update()
    {
        //TODO change this to activate mixer when in range and key pressed
        if (Input.GetKeyDown(KeyCode.Z))
        {
            isMixerActive = !isMixerActive;
        }


        if (isMixerActive)
        {
            //Set colour to indicate active desk
            deskMaterial.SetColor("_Color", Color.green);

            //Turn desk light on

            //Idea: TODO maybe add a flicker animation the first time it is turned on

            deskLight.SetActive(true);

            //Allow keys to be pressed
            KeyPresses();
            ChannelFunctions();


            //Check for clipping//
            SetClippingBools();
            CheckIfClipping();

            //Activate FX Panel with argument channelSelected - 100 is a value that indicates no chnl selected

            if (Input.GetKeyDown(KeyCode.F) && channelSelected != 100)
            {
                //fxCont.FXPanel(channelSelected);
                fxCont.ToggleFXPanel(channelSelected);

            }





        }


        else
        {
            deskMaterial.SetColor("_Color", Color.black);
           
            fxCont.fxPanel.SetActive(false);
            channelSelected = 100;
            SetAllFadersWhite();
            isFxPanelActive = false;
            deskLight.SetActive(false);
        }


        


        



    }




    void SetFaderColor()
    {
        Debug.Log("Function called");

        fader1Material.SetColor("_Color", Color.black);

    }

    void SetAllFadersWhite()
    {
        rend1.material.color = Color.white;
        rend2.material.color = Color.white;
        rend3.material.color = Color.white;
        rend4.material.color = Color.white;
        rend5.material.color = Color.white;
        rend6.material.color = Color.white;
        masterRend.material.color = Color.white;
    }


    //Altering Volume Functions//

    void SetChannelVolume(int channelSelected, float volume)
    {

        switch (channelSelected)
        {
            case 0:
                foh.SetFloat("MasterVol", volume);
                break;

            case 1:
                foh.SetFloat("Channel1Vol", volume);
                break;

            case 2:
                foh.SetFloat("Channel2Vol", volume);
                break;

            case 3:
                foh.SetFloat("Channel3Vol", volume);
                break;

            case 4:
                foh.SetFloat("Channel4Vol", volume);
                break;

            case 5:
                foh.SetFloat("Channel5Vol", volume);
                break;

            case 6:
                foh.SetFloat("Channel6Vol", volume);
                break;

            default:
                print("Default");
                break;
        }

    }
   

    void ChangeChannel(int channel)
    {
        channelSelected = channel;


        if (isFxPanelActive)
        {
            fxCont.SetTitleText(channelSelected);
            
        }
    }

public void UpdateFaderColour(int currentChannel)
    {
        switch (currentChannel)
        {
            //If 1 is pressed, sets channel 1 to cyan and everything else to white
            //etc.

            case 1:

                rend1.material.color = Color.cyan; rend2.material.color = Color.white; rend3.material.color = Color.white; 
                rend4.material.color = Color.white; rend5.material.color = Color.white; rend6.material.color = Color.white; masterRend.material.color = Color.white;
                break;

            case 2:

                rend1.material.color = Color.white; rend2.material.color = Color.cyan; rend3.material.color = Color.white;
                rend4.material.color = Color.white; rend5.material.color = Color.white; rend6.material.color = Color.white; masterRend.material.color = Color.white;
                break;

            case 3:

                rend1.material.color = Color.white; rend2.material.color = Color.white; rend3.material.color = Color.cyan;
                rend4.material.color = Color.white; rend5.material.color = Color.white; rend6.material.color = Color.white; masterRend.material.color = Color.white;
                break;

            case 4:

                rend1.material.color = Color.white; rend2.material.color = Color.white; rend3.material.color = Color.white;
                rend4.material.color = Color.cyan; rend5.material.color = Color.white; rend6.material.color = Color.white; masterRend.material.color = Color.white;
                break;

            case 5:

                rend1.material.color = Color.white; rend2.material.color = Color.white; rend3.material.color = Color.white;
                rend4.material.color = Color.white; rend5.material.color = Color.cyan; rend6.material.color = Color.white; masterRend.material.color = Color.white;
                break;

            case 6:

                rend1.material.color = Color.white; rend2.material.color = Color.white; rend3.material.color = Color.white;
                rend4.material.color = Color.white; rend5.material.color = Color.white; rend6.material.color = Color.cyan; masterRend.material.color = Color.white;
                break;



            case 0:

                rend1.material.color = Color.white; rend2.material.color = Color.white; rend3.material.color = Color.white;
                rend4.material.color = Color.white; rend5.material.color = Color.white; rend6.material.color = Color.white; masterRend.material.color = Color.cyan;
                break;
        }


    }


    public void KeyPresses()
    {

        //Key Presses: 


        // Choosing Channels //

        

        if (Input.GetKey(KeyCode.Alpha1))
        {
            ChangeChannel(1);
            fxCont.UpdateText(1);
            UpdateFaderColour(1);
        }



        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeChannel(2);
            fxCont.UpdateText(2);
            UpdateFaderColour(2);

        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeChannel(3);
            fxCont.UpdateText(3);
            UpdateFaderColour(3);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeChannel(4);
            fxCont.UpdateText(4);
            UpdateFaderColour(4);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ChangeChannel(5);
            fxCont.UpdateText(5);
            UpdateFaderColour(5);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            ChangeChannel(6);
            fxCont.UpdateText(6);
            UpdateFaderColour(6);
        }

        else if (Input.GetKeyDown(KeyCode.M))
        {
            ChangeChannel(0);
            fxCont.UpdateText(0);
            UpdateFaderColour(0);

        }
    }
    public void ChannelFunctions()
    {
        //Channel 1 Functions //


        switch (channelSelected)
        {

            case 1:
                if (Input.GetKey(KeyCode.UpArrow))
                {


                    if (notchPos1 < 100)
                    {
                        //Move the fader position
                        notch1.transform.position = new Vector3(notch1.transform.position.x, notch1.transform.position.y, notch1.transform.position.z + 0.055f);
                        notchPos1 += 1;

                        //Alter the volume
                        channel1Volume += 1f;
                        SetChannelVolume(channelSelected, channel1Volume);



                    }

                    //TODO Figure out why modifying the z value actually changes the x value. ^



                }


                if (Input.GetKey(KeyCode.DownArrow))
                {
                    if (notchPos1 > 0)
                    {
                        notch1.transform.position = new Vector3(notch1.transform.position.x, notch1.transform.position.y, notch1.transform.position.z - 0.055f);
                        notchPos1 -= 1;

                        channel1Volume -= 1f;
                        SetChannelVolume(channelSelected, channel1Volume);
                    }



                }

                break;

            case 2:
                if (Input.GetKey(KeyCode.UpArrow))
                {


                    if (notchPos2 < 100)
                    {
                        //Move the fader position
                        notch2.transform.position = new Vector3(notch2.transform.position.x, notch2.transform.position.y, notch2.transform.position.z + 0.055f);
                        notchPos2 += 1;

                        //Alter the volume
                        channel2Volume += 1f;
                        SetChannelVolume(channelSelected, channel2Volume);


                    }

                    //TODO Figure out why modifying the z value actually changes the x value. ^



                }


                if (Input.GetKey(KeyCode.DownArrow))
                {
                    if (notchPos2 > 0)
                    {
                        notch2.transform.position = new Vector3(notch2.transform.position.x, notch2.transform.position.y, notch2.transform.position.z - 0.055f);
                        notchPos2 -= 1;

                        channel2Volume -= 1f;
                        SetChannelVolume(channelSelected, channel2Volume);
                    }



                }
                break;


            case 3:
                if (Input.GetKey(KeyCode.UpArrow))
                {


                    if (notchPos3 < 100)
                    {
                        //Move the fader position
                        notch3.transform.position = new Vector3(notch3.transform.position.x, notch3.transform.position.y, notch3.transform.position.z + 0.055f);
                        notchPos3 += 1;

                        //Alter the volume
                        channel3Volume += 1f;
                        SetChannelVolume(channelSelected, channel3Volume);


                    }

                    //TODO Figure out why modifying the z value actually changes the x value. ^



                }

                //Turn the fader down //
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    if (notchPos3 > 0)
                    {
                        notch3.transform.position = new Vector3(notch3.transform.position.x, notch3.transform.position.y, notch3.transform.position.z - 0.055f);
                        notchPos3 -= 1;

                        channel3Volume -= 1f;
                        SetChannelVolume(channelSelected, channel3Volume);
                    }



                }
                break;

            case 4:
                
                    if (Input.GetKey(KeyCode.UpArrow))
                    {


                        if (notchPos4 < 100)
                        {
                            //Move the fader position up
                            notch4.transform.position = new Vector3(notch4.transform.position.x, notch4.transform.position.y, notch4.transform.position.z + 0.055f);
                            notchPos4 += 1;

                            //Increase the volume
                            channel4Volume += 1f;
                            SetChannelVolume(channelSelected, channel4Volume);


                        }

                        //TODO Figure out why modifying the z value actually changes the x value. ^



                    }


                    if (Input.GetKey(KeyCode.DownArrow))
                    {
                        if (notchPos4 > 0)
                        {
                            notch4.transform.position = new Vector3(notch4.transform.position.x, notch4.transform.position.y, notch4.transform.position.z - 0.055f);
                            notchPos4 -= 1;

                            channel4Volume -= 1f;
                            SetChannelVolume(channelSelected, channel4Volume);
                        }



                    }
                

                break;

            case 5:

                if (Input.GetKey(KeyCode.UpArrow))
                {


                    if (notchPos5 < 100)
                    {
                        //Move the fader position up
                        notch5.transform.position = new Vector3(notch5.transform.position.x, notch5.transform.position.y, notch5.transform.position.z + 0.055f);
                        notchPos5 += 1;

                        //Increase the volume
                        channel5Volume += 1f;
                        SetChannelVolume(channelSelected, channel5Volume);


                    }

                    //TODO Figure out why modifying the z value actually changes the x value. ^



                }


                if (Input.GetKey(KeyCode.DownArrow))
                {
                    if (notchPos5 > 0)
                    {
                        notch5.transform.position = new Vector3(notch5.transform.position.x, notch5.transform.position.y, notch5.transform.position.z - 0.055f);
                        notchPos5 -= 1;

                        channel5Volume -= 1f;
                        SetChannelVolume(channelSelected, channel5Volume);
                    }



                }


                break;


            case 6:

                if (Input.GetKey(KeyCode.UpArrow))
                {


                    if (notchPos6 < 100)
                    {
                        //Move the fader position up
                        notch6.transform.position = new Vector3(notch6.transform.position.x, notch6.transform.position.y, notch6.transform.position.z + 0.055f);
                        notchPos6 += 1;

                        //Increase the volume
                        channel6Volume += 1f;
                        SetChannelVolume(channelSelected, channel6Volume);


                    }

                    //TODO Figure out why modifying the z value actually changes the x value. ^



                }


                if (Input.GetKey(KeyCode.DownArrow))
                {
                    if (notchPos6 > 0)
                    {
                        notch6.transform.position = new Vector3(notch6.transform.position.x, notch6.transform.position.y, notch6.transform.position.z - 0.055f);
                        notchPos6 -= 1;

                        channel6Volume -= 1f;
                        SetChannelVolume(channelSelected, channel6Volume);
                    }



                }


                break;




            case 0:
                {


                    if (Input.GetKey(KeyCode.UpArrow))
                    {


                        if (masterNotchPos < 100)
                        {
                            //Move the fader position up
                            masterNotch.transform.position = new Vector3(masterNotch.transform.position.x, masterNotch.transform.position.y, masterNotch.transform.position.z + 0.055f);
                            masterNotchPos += 1;

                            //Increase the volume
                            masterVolume += 1f;
                            SetChannelVolume(channelSelected, masterVolume);


                        }

                        //TODO Figure out why modifying the z value actually changes the x value. ^



                    }


                    if (Input.GetKey(KeyCode.DownArrow))
                    {
                        if (masterNotchPos > 0)
                        {
                            masterNotch.transform.position = new Vector3(masterNotch.transform.position.x, masterNotch.transform.position.y, masterNotch.transform.position.z - 0.055f);
                            masterNotchPos -= 1;

                            masterVolume -= 1f;
                            SetChannelVolume(channelSelected, masterVolume);
                        }



                    }






                }
                break;

        }

    }


    void SetClippingBools()
    {
        if (channel1Volume > 0) { is1Clipping = true; } else { is1Clipping = false; }
        if (channel2Volume > 0) { is2Clipping = true; } else { is2Clipping = false; }
        if (channel3Volume > 0) { is3Clipping = true; } else { is3Clipping = false; }
        if (channel4Volume > 0) { is4Clipping = true; } else { is4Clipping = false; }
        if (channel5Volume > 0) { is5Clipping = true; } else { is5Clipping = false; }
        if (channel6Volume > 0) { is6Clipping = true; } else { is6Clipping = false; }
        if (masterVolume > 0) { isMasterClipping = true; } else { isMasterClipping = false; }









    }
    void CheckIfClipping()
    {
        if (isMasterClipping) { masterClippingLight.GetComponent<Renderer>().enabled = true; } else { masterClippingLight.GetComponent<Renderer>().enabled = false; }
        if (is1Clipping) { clippingLight1.GetComponent<Renderer>().enabled = true; } else { clippingLight1.GetComponent<Renderer>().enabled = false; }
        if (is2Clipping) { clippingLight2.GetComponent<Renderer>().enabled = true; } else { clippingLight2.GetComponent<Renderer>().enabled = false; }
        if (is3Clipping) { clippingLight3.GetComponent<Renderer>().enabled = true; } else { clippingLight3.GetComponent<Renderer>().enabled = false; }
        if (is4Clipping) { clippingLight4.GetComponent<Renderer>().enabled = true; } else { clippingLight4.GetComponent<Renderer>().enabled = false; }
        if (is5Clipping) { clippingLight5.GetComponent<Renderer>().enabled = true; } else { clippingLight5.GetComponent<Renderer>().enabled = false; }
        if (is6Clipping) { clippingLight6.GetComponent<Renderer>().enabled = true; } else { clippingLight6.GetComponent<Renderer>().enabled = false; }
    }
    

    
}

