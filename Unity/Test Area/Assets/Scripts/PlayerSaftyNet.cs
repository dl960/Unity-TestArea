using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaftyNet : MonoBehaviour {

    public GameObject playerHead;
    public GameObject playerHandLeft;
    public GameObject playerHandRight;

    public Material faidNet;

    public float fadeNetIn = 10f;

    private float playerDistFromChair;

    private float alphaAmount;

    // Use this for initialization
    void Start () {
        faidNet.color = new Color(0, 7, 53, 0);
        playerHead = GameObject.Find("Camera (head)");
        playerHandLeft = GameObject.Find("Controller (left)");
        playerHandRight = GameObject.Find("Controller (Right)");

    }
	
	// Update is called once per frame
	void Update () {

       // playerDistFromChair = Vector3.Distance(playerHead.transform.position, this.gameObject.transform.position);

        //work out fade in

        if (Vector3.Distance(transform.position, playerHead.transform.position) <= fadeNetIn)
        {

            faidNet.color = new Color(0, 7, 53, 170);
        }

        if (Vector3.Distance(transform.position, playerHead.transform.position) <= fadeNetIn)
        {

            //change alpha or turn on renderer
        }

        if (Vector3.Distance(transform.position, playerHead.transform.position) <= fadeNetIn)
        {

            //change alpha or turn on renderer
        }
        else
        {
            faidNet.color = new Color(1, 1, 1, 0);
        }

    }
}
