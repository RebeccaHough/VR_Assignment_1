using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlindScript : Openable {

    public Text openBlindPrompt, closeBlindPrompt;

    public override void modifyBoxCollider()
    {
        //rotate box by 90 degrees by swapping x and z
        Vector3 tempSize = boxTrigger.size;

        //move center of box collider over to original position
        Vector3 tempCenter = boxTrigger.center;
        if (objectIsOpen)
        {
            boxTrigger.size = new Vector3(tempSize.x, 15, tempSize.z);
            boxTrigger.center = new Vector3(tempCenter.x, -7.5f, tempCenter.z);
        }
        else
        {
            boxTrigger.size = new Vector3(tempSize.x, 1.0f, tempSize.z);
            boxTrigger.center = new Vector3(tempCenter.x, 0.0f, tempCenter.z);
        }
    }

    public override void setup()
    {
        openPrompt = openBlindPrompt;
        closePrompt = closeBlindPrompt;
        trigger = "OpenBlinds";
    }
}