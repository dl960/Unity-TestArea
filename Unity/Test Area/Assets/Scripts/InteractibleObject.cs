using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleObject : MonoBehaviour {

    public Rigidbody rigidbody;
    private bool currentlyInteracting;

    //Stuff for object manipulation
    private float velocityFactor = 20000f;
    private Vector3 posDelta;
    private float rotationFactor = 600f;
    private Quaternion rotationDelta;
    private float angle;
    private Vector3 axis;

    private Controllers attachedController;
    private Transform interactionPoint;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        interactionPoint = new GameObject().transform;
        velocityFactor /= rigidbody.mass;
        //try taking this out to make the rotations /w no delay
        rotationFactor /= rigidbody.mass;
	}	
	// Do i need FIXED UPDATE for rigidbodu manipulation? (CHECK WHEN GAME GETS MORE FULL OF CONTENT)
	void Update () {
		if(attachedController && currentlyInteracting)
        {
            posDelta = attachedController.transform.position - interactionPoint.position;
            this.rigidbody.velocity = posDelta * velocityFactor * Time.fixedDeltaTime;

            rotationDelta = attachedController.transform.rotation * Quaternion.Inverse(interactionPoint.rotation);
            rotationDelta.ToAngleAxis(out angle, out axis);

            if(angle > 180){
                angle -= 360;
            }
            this.rigidbody.angularVelocity = (Time.fixedDeltaTime * angle * axis);
        }
	}
    public void BeginInteraction(Controllers controller)
    {
        attachedController = controller;
        interactionPoint.position = controller.transform.position;
        interactionPoint.rotation = controller.transform.rotation;
        interactionPoint.SetParent(transform, true);

        currentlyInteracting = true;
    }
    public void EndInteraction(Controllers controller)
    {
       if(controller == attachedController)
        {
            attachedController = null;
            currentlyInteracting = false;
        }
    }
    public bool IsInteracting()
    {
        return currentlyInteracting;
    }
}
