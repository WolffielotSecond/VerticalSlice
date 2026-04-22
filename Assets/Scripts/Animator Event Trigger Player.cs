using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEventTrigger : MonoBehaviour
{
    public CameraShake _cameraShake;
    public void PlayCameraShake()
    {
        _cameraShake.StartCoroutine(_cameraShake.Shake(0.15f, 0.4f));
    }
}
