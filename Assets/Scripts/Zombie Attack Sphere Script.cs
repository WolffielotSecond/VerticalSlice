using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackSphereScript : MonoBehaviour
{

    public GameObject player_ref;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player_ref = other.gameObject;
            Debug.Log("Enter");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player_ref = null;
            Debug.Log("Leave");
        }
    }
}
