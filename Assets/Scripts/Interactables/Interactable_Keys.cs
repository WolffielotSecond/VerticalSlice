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

    public void On_Picked_Up()
    {
        Debug.Log("Animation");
        Destroy(gameObject);
    }
    public override void interact()
    {
        switch (Type_Of_Key)
        {
            case KeyType.A:
                GameInstanceHolder.instance.gameInstance.Key_A_Picked = true;
                break;
            case KeyType.B:
                GameInstanceHolder.instance.gameInstance.Key_B_Picked = true;
                break;
            case KeyType.C:
                GameInstanceHolder.instance.gameInstance.Key_C_Picked = true;
                break;
        }
        On_Picked_Up();
    }

}
