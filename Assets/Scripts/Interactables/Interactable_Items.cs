using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Artifact,
    Hatchet,
    Gun,
    Medkit,
    Ammo,
    Return_To_Base
}

public class Interactable_Items : InteractableBase
{
    [Header("Item Type")]
    public ItemType itemType;
    [Header("Self Reference")]
    public GameObject prefab;
    [Header("UI Stats")]
    public Sprite ItemIcon;
    public string ItemName;
    [Header("For Ammo")]
    public int AmmoAmount = 4;
    
    // Start is called before the first frame update
    void Start()
    {
        if (itemType == ItemType.Return_To_Base)
        {
            interactionText.SetText("Return To Base");
        }
        else
        {
            interactionText.SetText("Pick Up");
        }
                switch (itemType)
                {
                    case ItemType.Artifact:
                        if (GameInstanceHolder.instance.gameInstance.Game_Completed)
                        {
                            Destroy(prefab);
                        }
                        break;
                    case ItemType.Hatchet:
                        if (GameInstanceHolder.instance.gameInstance.hasHatchet)
                        {
                            Destroy(prefab);
                        }
                        break;
                    case ItemType.Gun:
                        if (GameInstanceHolder.instance.gameInstance.hasGun)
                        {
                            Destroy(prefab);
                        }
                        break;
                }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void On_Picked_Up()
    {
        Singleton.Instance._UI.GetComponent<UI>().pickupIcon.sprite = ItemIcon;
        Singleton.Instance._UI.GetComponent<UI>().pickupItemName.text = ItemName;
        Singleton.Instance._UI.GetComponent<UI>().OpenMenu();
        Singleton.Instance._UI.GetComponent<UI>().Key = prefab;
    }

    public override void interact()
    {
        switch (itemType)
        {
            case ItemType.Artifact:

                Singleton.Instance._player.GetComponent<Player_Stats_Handler>().HasArtifact = true;
                On_Picked_Up();
                break;
            case ItemType.Hatchet:

                Singleton.Instance._player.GetComponent<Player_Stats_Handler>().hasHatchet = true;
                On_Picked_Up();
                break;
            case ItemType.Gun:

                Singleton.Instance._player.GetComponent<Player_Stats_Handler>().hasPistol = true;
                On_Picked_Up();
                break;
            case ItemType.Medkit:
                Singleton.Instance._player.GetComponent<Player_Stats_Handler>().medkits += 1;
                On_Picked_Up();
                //Heal player
                break;
            case ItemType.Ammo:
                Singleton.Instance._player.GetComponent<Player_Stats_Handler>().ammo += AmmoAmount;
                On_Picked_Up();
                break;
            case ItemType.Return_To_Base:
                if (Singleton.Instance._player.GetComponent<Player_Stats_Handler>().HasArtifact)
                {
                    Debug.Log("You have returned to base with the artifact! You win!");
                }
                else
                {
                    Debug.Log("You need the artifact to return to base!");  
                }
                break;
        }
    }
}
