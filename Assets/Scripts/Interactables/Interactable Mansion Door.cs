using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableMansionDoor : InteractableBase
{
    public override void interact()
    {
        Debug.Log("You open the mansion door and step inside. The adventure begins!");
    }
}
