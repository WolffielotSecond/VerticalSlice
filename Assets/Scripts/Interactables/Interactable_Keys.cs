using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyType
{
    A,
    B,
    C
}


public class Interactable_Keys : InteractableBase
{

    [Header("Key Room")]
    public KeyType Type_Of_Key = KeyType.A;
    public Sprite KeyIcon;
    public string KeyName;
    public GameObject Key_Prefab;

    public void On_Picked_Up()
    {
        Singleton.Instance._UI.GetComponent<UI>().pickupIcon.sprite = KeyIcon;
        Singleton.Instance._UI.GetComponent<UI>().pickupItemName.text = KeyName;
        Singleton.Instance._UI.GetComponent<UI>().OpenMenu();
        Singleton.Instance._UI.GetComponent<UI>().Key = Key_Prefab;
    }
    public override void interact()
    {
        switch (Type_Of_Key)
        {
            case KeyType.A:
                //GameInstanceHolder.instance.gameInstance.Key_A_Picked = true;
                Singleton.Instance._player.GetComponent<Player_Stats_Handler>().hasKeyA = true;
                break;
            case KeyType.B:
                //GameInstanceHolder.instance.gameInstance.Key_B_Picked = true;
                Singleton.Instance._player.GetComponent<Player_Stats_Handler>().hasKeyB = true;
                break;
            case KeyType.C:
                //GameInstanceHolder.instance.gameInstance.Key_C_Picked = true;
                Singleton.Instance._player.GetComponent<Player_Stats_Handler>().hasKeyC = true;
                break;
        }
        On_Picked_Up();
    }

}
