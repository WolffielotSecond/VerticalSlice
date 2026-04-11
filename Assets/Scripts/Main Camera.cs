using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public void SetCameraPos(Transform cameraPos)
    {
        transform.position = cameraPos.position;
        transform.rotation = cameraPos.rotation;
    }
}
