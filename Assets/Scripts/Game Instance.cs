using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ExitRoom
{
    Outside,
    Room_A,
    Room_B,
    Room_C
}

[CreateAssetMenu(menuName = "Game Instance")]
public class GameInstance : ScriptableObject
{
    public ExitRoom CurrentExitRoom;
    public bool Room_A_Unlocked = true;
    public bool Room_B_Unlocked;
    public bool Room_C_Unlocked;
    public bool Key_A_Picked;
    public bool Key_B_Picked;
    public bool Key_C_Picked;
    public bool Game_Completed;
}
