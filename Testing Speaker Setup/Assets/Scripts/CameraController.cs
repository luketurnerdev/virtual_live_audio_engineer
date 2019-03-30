using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject mainCam, deskCam, FPC;
    public MixingConosle mc;
    public bool isConsoleActive = false;

    public float newXPos, newYPos, newZPos;
    public float increment;

    


	// Use this for initialization
	void Start () {
        //newXPos = Mathf.Clamp(deskCam.transform.position.x, 67.00f, 86.7f);
        increment = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (mc.isMixerActive == true)
        {
            isConsoleActive = true;
            MoveCamera();
        }

        else 
        {
            isConsoleActive = false;
        }



        if (isConsoleActive)
        {
            deskCam.SetActive(true);
            mainCam.SetActive(false);
            

        }

        else
        {
            deskCam.SetActive(false);
            mainCam.SetActive(true);
        }
    }




    void MoveCamera()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Moves camera to the right

            deskCam.transform.position = new Vector3(Mathf.Clamp(deskCam.transform.position.x, -3.5f, 3.5f)+increment, deskCam.transform.position.y, deskCam.transform.position.z);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Moves camera to the left

            deskCam.transform.position = new Vector3(Mathf.Clamp(deskCam.transform.position.x, -3.5f, 3.5f) - increment, deskCam.transform.position.y, deskCam.transform.position.z);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Moves camera up

            deskCam.transform.position = new Vector3(deskCam.transform.position.x, deskCam.transform.position.y, (Mathf.Clamp(deskCam.transform.position.z, -60.5f, -53f) + increment));
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //Moves camera down

            deskCam.transform.position = new Vector3(deskCam.transform.position.x, deskCam.transform.position.y, (Mathf.Clamp(deskCam.transform.position.z, -60.5f, -53f) - increment));
        }



    }
}
