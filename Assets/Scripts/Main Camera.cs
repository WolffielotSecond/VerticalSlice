using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject Health;
    public Color FullHealth;
    public Color LowHealth;
    [Header("Dont't Edit")]
    public Renderer Heart_Mat;
    
    public void Start()
    {
        Heart_Mat = Health.GetComponent<Renderer>();
    }
    public void Update()
    {
        Heart_Mat.material.color = Color.Lerp(LowHealth, FullHealth, Singleton.Instance._player.GetComponent<Player_Stats_Handler>().Health / 100f);
    }

    public void SetCameraPos(Transform cameraPos)
    {
        transform.position = cameraPos.position;
        transform.rotation = cameraPos.rotation;
    }
}
