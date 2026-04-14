using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionRelated : MonoBehaviour
{
    public InteractableBase currentInteractable;

    public void setCurrentInteractable(InteractableBase interactable)
    {
        currentInteractable = interactable;
    }
    public void clearCurrentInteractable()
    {
        currentInteractable = null;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.interact();
        }
    }
}
