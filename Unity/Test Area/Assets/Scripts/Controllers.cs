using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controllers : MonoBehaviour {
    //Buttons
    public Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;  
    public Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;   

    //Checking what order the controllers have been added to the game i
    public SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    public SteamVR_TrackedObject trackedObj;

    HashSet<InteractibleObject> objectHoveringOver = new HashSet<InteractibleObject>();

    private InteractibleObject closesObject;
    private InteractibleObject interactingObject;

    // Use this for initialization
    void Start () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }	
	// Update is called once per frame
	void Update () {
		if(controller == null)
        {
            Debug.Log("Controller not initialized");
            return;
        }             
        if (controller.GetPressDown(gripButton) )
        {
            float minDistance = float.MaxValue;
            float distance;
            foreach(InteractibleObject item in objectHoveringOver){
                distance = (item.transform.position - transform.position).sqrMagnitude;
                if(distance< minDistance)
                {
                    minDistance = distance;
                    closesObject = item;
                }
            }
            interactingObject = closesObject;
            closesObject = null;
            if (interactingObject){
                if (interactingObject.IsInteracting())
                {

                    interactingObject.EndInteraction(this);
                }
                interactingObject.BeginInteraction(this);                           
            }
        }
        if (controller.GetPressUp(gripButton) && interactingObject !=null )
        {
            interactingObject.EndInteraction(this);
        }   
    }
    private void OnTriggerEnter(Collider collider)
    {
        InteractibleObject collidedObject = collider.GetComponent<InteractibleObject>();
        if (collidedObject)
        {
            objectHoveringOver.Add(collidedObject);
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        InteractibleObject collidedObject = collider.GetComponent<InteractibleObject>();
        if (collidedObject)
        {
            objectHoveringOver.Remove(collidedObject);
        }
    }

   
}
