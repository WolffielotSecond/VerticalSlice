using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstanceHolder : MonoBehaviour
{
    public GameInstance gameInstance;
    public static GameInstanceHolder instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ResetGame()
    {
        gameInstance.Room_A_Unlocked = false;
        gameInstance.Room_B_Unlocked = false;
        gameInstance.Room_C_Unlocked = false;
        gameInstance.Key_A_Picked = false;
        gameInstance.Key_B_Picked = false;
        gameInstance.Key_C_Picked = false;
        gameInstance.Game_Completed = false;
        gameInstance.hasHatchet = false;
        gameInstance.hasGun = false;
        gameInstance.ammoLoaded = 0;
        gameInstance.ammoCarried = 0;
        gameInstance.medkitsCarried = 0;
        gameInstance.Health = 100f;
    }
}
