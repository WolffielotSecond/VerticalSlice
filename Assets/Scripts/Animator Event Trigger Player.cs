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
    public void IsntShooting()
    {
        Singleton.Instance._player.GetComponent<NewPlayer>().isShooting = false;
    }
    public void Kick_Sound()
    {
        Singleton.Instance._UI.GetComponent<UI>().audioSource.clip = Singleton.Instance._UI.GetComponent<UI>().Kick_sfx;
        Singleton.Instance._UI.GetComponent<UI>().audioSource.Play();
    }
    public void FootStep()
    {
        
        Singleton.Instance._UI.GetComponent<UI>().audioSource.clip = Singleton.Instance._UI.GetComponent<UI>().footStep_sfx;
        Singleton.Instance._UI.GetComponent<UI>().audioSource.pitch = Random.Range(0.8f, 1.2f);
        Singleton.Instance._UI.GetComponent<UI>().audioSource.Play();
    }

}
