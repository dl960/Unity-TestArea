using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calibration : MonoBehaviour {

    private Controllers controller;

    private Vector3 chairLocation;
    public GameObject chair;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (controller.controller.GetPressDown(controller.gripButton)){
            chairLocation = controller.controller.transform.pos;
            CalibrateChair();
        }
    }

    private void CalibrateChair()
    {
        chair.transform.position = chairLocation;

        if (controller.controller.GetPressDown(controller.triggerButton) && chair.transform.position == chairLocation)
        {
            Debug.Log("Chair calibrated");
            //Add other calibration stuff ie cockpit
        }
    }
}
