using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats_Handler : MonoBehaviour
{
    [Header("Player Stats Don't Modify")]
    public float Health = 100;
    
    public int medkits = 0;
    public int ammo = 0;
    public int ammoLoaded = 0;

    public bool hasPistol = false;
    public bool hasHatchet = false;

    public bool hasKeyA = true;
    public bool hasKeyB = false;
    public bool hasKeyC = false;

    public bool RoomAUnlocked = false;
    public bool RoomBUnlocked = false;
    public bool RoomCUnlocked = false;

    public bool HasArtifact = false;

    public void loadStats()
    {
        GameInstanceHolder.instance.gameInstance.Health = Health;
        GameInstanceHolder.instance.gameInstance.hasGun = hasPistol;
        GameInstanceHolder.instance.gameInstance.hasHatchet = hasHatchet;
        GameInstanceHolder.instance.gameInstance.ammoCarried = ammo;
        GameInstanceHolder.instance.gameInstance.ammoLoaded = ammoLoaded;
        GameInstanceHolder.instance.gameInstance.medkitsCarried = medkits;
        GameInstanceHolder.instance.gameInstance.Key_A_Picked = hasKeyA;
        GameInstanceHolder.instance.gameInstance.Key_B_Picked = hasKeyB;
        GameInstanceHolder.instance.gameInstance.Key_C_Picked = hasKeyC;
        GameInstanceHolder.instance.gameInstance.Room_A_Unlocked = RoomAUnlocked;
        GameInstanceHolder.instance.gameInstance.Room_B_Unlocked = RoomBUnlocked;
        GameInstanceHolder.instance.gameInstance.Room_C_Unlocked = RoomCUnlocked;
        GameInstanceHolder.instance.gameInstance.Game_Completed = HasArtifact;
    }

    public void loadStatsFromInstance()
    {
        Health = GameInstanceHolder.instance.gameInstance.Health;
        hasPistol = GameInstanceHolder.instance.gameInstance.hasGun;
        hasHatchet = GameInstanceHolder.instance.gameInstance.hasHatchet;
        ammo = GameInstanceHolder.instance.gameInstance.ammoCarried;
        ammoLoaded = GameInstanceHolder.instance.gameInstance.ammoLoaded;
        medkits = GameInstanceHolder.instance.gameInstance.medkitsCarried;
        hasKeyA = GameInstanceHolder.instance.gameInstance.Key_A_Picked;
        hasKeyB = GameInstanceHolder.instance.gameInstance.Key_B_Picked;
        hasKeyC = GameInstanceHolder.instance.gameInstance.Key_C_Picked;
        RoomAUnlocked = GameInstanceHolder.instance.gameInstance.Room_A_Unlocked;
        RoomBUnlocked = GameInstanceHolder.instance.gameInstance.Room_B_Unlocked;
        RoomCUnlocked = GameInstanceHolder.instance.gameInstance.Room_C_Unlocked;
        HasArtifact = GameInstanceHolder.instance.gameInstance.Game_Completed;
    }

    private void Start()
    {
        loadStatsFromInstance();
    }
}
