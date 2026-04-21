using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableMansionDoor : InteractableBase
{
    [SerializeField] private string _sceneName = "Mansion";
    public override void interact()
    {
         //open new scene
         UnityEngine.SceneManagement.SceneManager.LoadScene(_sceneName, LoadSceneMode.Single);
    }
}
