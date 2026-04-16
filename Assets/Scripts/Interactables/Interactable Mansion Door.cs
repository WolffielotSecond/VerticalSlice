using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableMansionDoor : InteractableBase
{
    [SerializeField] private string _sceneName = "Mansion";
    public override void interact()
    {
         //open new scene
         UnityEngine.SceneManagement.SceneManager.LoadScene(_sceneName);
    }
}
