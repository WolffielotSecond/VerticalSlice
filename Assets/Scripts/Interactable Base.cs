using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractableBase : MonoBehaviour, InteractableInterface
{

    enum InteractableType
    {
        Item, //钥匙，ammo，药
        Terminal, //门
        Portal_in, //房子出入口的门
        Portal_out //房子出入口的门
    }
    [SerializeField] private InteractableType _type;
    public TextMeshPro interactionText;
    private string _InteractionName => _type switch
    {
        InteractableType.Item => "Pick Up",
        InteractableType.Terminal => "Interact",
        InteractableType.Portal_in => "Enter",
        InteractableType.Portal_out => "Leave",
        _ => "Unknown"
    };
    public string interactableName;
    public string interactType => _InteractionName;
    public string objectName => interactableName;
    
    public virtual void interact() 
    {
        Debug.Log("idk");
    }
    private Collider _collider;
    private void Awake()
    {
        _collider = GetComponent<Collider>();
        interactionText.SetText(interactType);
        interactionText.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<InteractionRelated>().setCurrentInteractable(this);
            interactionText.enabled = true;
            Debug.Log("Enter");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<InteractionRelated>().clearCurrentInteractable();
            interactionText.enabled = false;
            Debug.Log("Exit");
        }
    }
}
