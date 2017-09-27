using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaftyNet : MonoBehaviour {

    public GameObject playerHead;
    public GameObject playerHandLeft;
    public GameObject playerHandRight;
    public GameObject checkPoint;

    public Material faidNet;

    private float fadeNetIn = 4f;

    public float playerDistFromChairCheck1;
  

    public float alphaAmount;

    // Use this for initialization
    void Start () {
        

        faidNet.color = new Color(0, 7, 53, 0);
        playerHead = GameObject.Find("Camera (head)");
        
        //playerHandLeft = GameObject.Find("Controller (left)");
        //playerHandRight = GameObject.Find("Controller (Right)");

    }
	
	// Update is called once per frame
	void Update () {        
        
        playerDistFromChairCheck1 = Vector3.Distance(playerHead.transform.position, this.gameObject.transform.position);


        if (playerDistFromChairCheck1 <= fadeNetIn)
        {
            alphaAmount = fadeNetIn - playerDistFromChairCheck1;

            faidNet.color = new Color(0, 7, 53, alphaAmount);

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
