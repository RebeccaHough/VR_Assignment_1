using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatScript : MonoBehaviour {
    Animator anim;
    public Text startBoatPrompt;
    private bool playerAtObject, boatIsStationary;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        startBoatPrompt.enabled = false;
        playerAtObject = false;
        boatIsStationary = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if player in trigger && b is pressed && boat is stationary
        if (playerAtObject && Input.GetKeyDown("b") && boatIsStationary)
        {
            anim.SetTrigger("StartBoat");
            anim.enabled = true;
            boatIsStationary = false;
            //hide start boat prompt text
            startBoatPrompt.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //show start boat prompt text
        if (boatIsStationary)
        {
            startBoatPrompt.enabled = true;
        }
        playerAtObject = true;
    }

    private void OnTriggerExit(Collider other)
    {
        //hide start boat prompt text regardless if the boat is moving or not
        startBoatPrompt.enabled = false;
        playerAtObject = false;
    }

    private void onAnimationEnd()
    {
        //pause animation
        anim.enabled = false;
        boatIsStationary = true;
        if (playerAtObject)
        {
            startBoatPrompt.enabled = true;
        }
    }
}
