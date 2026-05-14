using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum DoorSet
{
    Room_A,
    Room_B,
    Room_C
}

public class InteractableMansionDoor : InteractableBase
{
    [SerializeField] private string _sceneName = "Mansion";
    [SerializeField] private bool isRoom = false;
    [SerializeField] private DoorSet Which_Door;

    private void load_Inventory_Stats()
    {
        Singleton.Instance._player.GetComponent<Player_Stats_Handler>().loadStats();
    }
    public override void interact()
    {
        load_Inventory_Stats();
        if (isRoom)
        {
            switch (Which_Door)
            {
                case DoorSet.Room_A:
                    if (GameInstanceHolder.instance.gameInstance.Room_A_Unlocked)
                    {
                        Singleton.Instance._player.GetComponent<Player_Stats_Handler>().loadStats();
                        UnityEngine.SceneManagement.SceneManager.LoadScene(_sceneName, LoadSceneMode.Single);
                    }
                    else
                    {
                        Debug.Log("Room A is locked.");
                    }
                    break;
                case DoorSet.Room_B:
                    if (GameInstanceHolder.instance.gameInstance.Room_B_Unlocked)
                    {
                        Singleton.Instance._player.GetComponent<Player_Stats_Handler>().loadStats();
                        UnityEngine.SceneManagement.SceneManager.LoadScene(_sceneName, LoadSceneMode.Single);
                    }
                    break;
                case DoorSet.Room_C:
                    if (GameInstanceHolder.instance.gameInstance.Room_C_Unlocked)
                    {
                        Singleton.Instance._player.GetComponent<Player_Stats_Handler>().loadStats();
                        UnityEngine.SceneManagement.SceneManager.LoadScene(_sceneName, LoadSceneMode.Single);
                    }
                    break;
            }
        }
        else
        {
            Singleton.Instance._player.GetComponent<Player_Stats_Handler>().loadStats();
            UnityEngine.SceneManagement.SceneManager.LoadScene(_sceneName, LoadSceneMode.Single);
        }
        
           
    }
}
