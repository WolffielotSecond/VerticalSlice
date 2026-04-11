using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    [Header("»úÎ»")]
    [SerializeField] private Transform cameraPos;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Singleton.Instance._mainCamera.GetComponent<MainCamera>().SetCameraPos(cameraPos);
            Debug.Log("Trigger");
        }
    }
}
