using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class UI : MonoBehaviour
{
    [Header("UI Assets")]
    public Sprite hasHatchet;
    public Sprite hasPistol;
    public Sprite NoHatchet;
    public Sprite NoPistol;
    [Space]
    [Header("UI Elements")]
    public GameObject HatchetIndicator;
    public GameObject PistolIndicator;
    public TMP_Text Loaded_Ammo;
    public TMP_Text Carried_Ammo;

    private void SetStats()
    {
        PistolIndicator.GetComponent<Image>().sprite =
            GameInstanceHolder.instance.gameInstance.hasGun ? hasPistol : NoPistol;

        HatchetIndicator.GetComponent<Image>().sprite =
            GameInstanceHolder.instance.gameInstance.hasHatchet ? hasHatchet : NoHatchet;
        Loaded_Ammo.text = GameInstanceHolder.instance.gameInstance.ammoLoaded.ToString();
        Carried_Ammo.text = GameInstanceHolder.instance.gameInstance.ammoCarried.ToString();
    }
    private void Start()
    {
        SetStats();
    }
}

