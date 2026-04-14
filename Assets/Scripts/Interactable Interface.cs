using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InteractableInterface
{
    public string interactType { get; }
    public string objectName { get; }
    public void interact();
}
