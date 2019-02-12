using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Openable : MonoBehaviour
{
    Animator anim;
    protected Text openPrompt, closePrompt;
    protected BoxCollider boxTrigger;
    protected bool playerAtObject, objectIsOpen;
    protected string trigger;

    // Set up trigger and open/close prompt texts
    public abstract void setup();
    // Optional logic for modfying the size/orentation of a box collider after it has been animated
    public virtual void modifyBoxCollider() { }

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        boxTrigger = GetComponent<BoxCollider>();
        setup();
        openPrompt.enabled = false;
        closePrompt.enabled = false;
        playerAtObject = false;
        objectIsOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if player in trigger && e is pressed && object is closed
        if (playerAtObject && Input.GetKeyDown("e") && !objectIsOpen)
        {
            //open object
            anim.SetTrigger(trigger);
            anim.enabled = true;
            objectIsOpen = true;
            //hide open prompt text
            openPrompt.enabled = false;
            closePrompt.enabled = true;

            modifyBoxCollider();
        }
        //if player in trigger && e is pressed && object is open
        else if (playerAtObject && Input.GetKeyDown("e") && objectIsOpen)
        {
            //close object (by continuing animation)
            anim.enabled = true;
            objectIsOpen = false;
            //hide close prompt text
            closePrompt.enabled = false;
            openPrompt.enabled = true;

            modifyBoxCollider();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //show open/close prompt text
        if (!objectIsOpen)
        {
            openPrompt.enabled = true;
        }
        else
        {
            closePrompt.enabled = true;
        }
        playerAtObject = true;
    }

    private void OnTriggerExit(Collider other)
    {
        //hide open/close prompt text
        if (!objectIsOpen)
        {
            openPrompt.enabled = false;
        }
        else
        {
            closePrompt.enabled = false;
        }
        playerAtObject = false;
    }

    private void pauseAnimationEvent()
    {
        //pause animation
        anim.enabled = false;
    }
}