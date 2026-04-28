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
    }

    private void Start()
    {
        loadStatsFromInstance();
    }
}
