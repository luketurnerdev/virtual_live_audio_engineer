using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System.Collections.Generic;

public class ChallengeController : MonoBehaviour
{

    //Script starts by stating the problem e.g.,:

    //The vocals are too soft, turn them up until the singer is happy (indicated by icon?) or maybe green thumbs up on the desk..

    //Then The challenge is marked as complete once the volume parameter is met



    //Imports//

        //May need to use IEnumerator for the time limit aspect


    public AudioMixer foh;






    //Public Vars//

    public string challengeName;
    public float challengeTimeLimit;

    //Challenge 1
    public float currentVolume;
    public float goalVolume;
    //Challenge 2
    float currentReverb;
    public float goalReverb;
    string reverbType;
    
    public float faderLocation;
    public int currentChallenge;
    public GameObject upArrow;

    //Booleans

    public bool isChallengeComplete = false;
    bool challenge1Activated = false;
    bool challenge2Activated = false;






    // Use this for initialization
    void Start ()
    {
        currentChallenge = 1;
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        bool result = foh.GetFloat("Channel1Vol", out currentVolume);
    }

    void Update ()
    {
        if (Input.GetKey(KeyCode.S))
        {
            StartChallenge(currentChallenge);
        }



        if (challenge1Activated)
        

        {

            upArrow.SetActive(true);
            Debug.Log("ChallengeActivated");
            Challenge1(currentVolume, goalVolume);



        }

        else
        {
            upArrow.SetActive(false);
        }

        


    }

    public void StartChallenge(int currentChallenge)
    {
        switch (currentChallenge)
        {
            case 1:
                goalVolume = 0.00f;
                challenge1Activated = true;
                break;

            default:
                Debug.Log("default");
                break;
        }
    }

    public void Challenge1(float volume, float goal)
    {
        

        //Check if current has met goal.

        if (currentVolume == goalVolume)
        {
            isChallengeComplete = true;
            GameObject winNotch = (GameObject)Instantiate(Resources.Load("winNotch"), transform.position, transform.rotation) ;
            
            
            currentChallenge++;
            //ActivateNextChallenge();

            //TODO - ADD ActivateNextChallenge, and make it so that the challenge is satisfied between a particular range - not exactly equal to 0 

            challenge1Activated = false;


            print(isChallengeComplete);
            //Visual indication to the user goes here
        }
    }

    public void Challenge2()
    {
        //Check if current has met goal.

        if (currentReverb == goalReverb)
        {
            isChallengeComplete = true;
            currentChallenge++;
            //ActivateNextChallenge();

            //TODO - ADD ActivateNextChallenge, and make it so that the challenge is satisfied between a particular range - not exactly equal to 0 

            challenge2Activated = false;


            print(isChallengeComplete);
            //Visual indication to the user goes here
            //Thumbs up on desk?
        }

    }


}
