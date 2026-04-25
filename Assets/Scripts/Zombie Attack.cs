using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class ZombieAttack : MonoBehaviour
{
    public void Attack()
    {
        if (Singleton.Instance._player.GetComponent<NewPlayer>().GetParrying())
        {
            Variables.Object(gameObject).Set("IsStunned", true);
            Singleton.Instance._player.GetComponent<NewPlayer>().DoCameraShake();
        }
        else
        {
            Debug.Log("Player has been hit");
        }
    }
}
