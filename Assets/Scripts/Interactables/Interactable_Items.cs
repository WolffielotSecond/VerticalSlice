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
    // Start is called before the first frame update
    void Start()
    {
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

    public override void interact()
    {
        
    }
}
