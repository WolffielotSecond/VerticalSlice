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
    [Header("若勾了房间无需编辑")]
    [SerializeField] private string _sceneName = "Mansion";
    [Space]
    [Header("For Rooms")]
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
                    GameInstanceHolder.instance.gameInstance.CurrentExitRoom = ExitRoom.Room_A;
                    UnityEngine.SceneManagement.SceneManager.LoadScene("House Interior", LoadSceneMode.Single);
                    break;
                case DoorSet.Room_B:
                    GameInstanceHolder.instance.gameInstance.CurrentExitRoom = ExitRoom.Room_B;
                    UnityEngine.SceneManagement.SceneManager.LoadScene("House Interior", LoadSceneMode.Single);
                    break;
                case DoorSet.Room_C:
                    GameInstanceHolder.instance.gameInstance.CurrentExitRoom = ExitRoom.Room_C;
                    UnityEngine.SceneManagement.SceneManager.LoadScene("House Interior", LoadSceneMode.Single);
                    break;
            }
        }
        else
        {
            GameInstanceHolder.instance.gameInstance.CurrentExitRoom = ExitRoom.Outside;
            Singleton.Instance._player.GetComponent<Player_Stats_Handler>().loadStats();
            UnityEngine.SceneManagement.SceneManager.LoadScene(_sceneName, LoadSceneMode.Single);
        }
        
           
    }
}
