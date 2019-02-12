using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : Openable {

    public Text openDoorPrompt, closeDoorPrompt;

    public override void modifyBoxCollider()
    {
        //rotate box by 90 degrees by swapping x and z
        Vector3 tempSize = boxTrigger.size;
        boxTrigger.size = new Vector3(tempSize.z, tempSize.y, tempSize.x);

        //move center of box collider over to original position
        Vector3 tempCenter = boxTrigger.center;
        if (objectIsOpen)
        {
            boxTrigger.center = new Vector3(tempCenter.x, tempCenter.y, tempCenter.z - (tempCenter.z / 2));
        }
        else
        {
            boxTrigger.center = new Vector3(tempCenter.x, tempCenter.y, tempCenter.z + (tempCenter.z / 2));
        }
    }

    public override void setup()
    {
        openPrompt = openDoorPrompt;
        closePrompt = closeDoorPrompt;
        trigger = "OpenDoor";
    }
}
