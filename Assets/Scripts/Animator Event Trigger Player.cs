using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimatorEventTrigger : MonoBehaviour
{
    public CameraShake _cameraShake;
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayCameraShake()
    {
        _cameraShake.StartCoroutine(_cameraShake.Shake(0.1f, 0.4f));
    }
    public void IsntShooting()
    {
        Singleton.Instance._player.GetComponent<NewPlayer>().isShooting = false;
    }
    public void Kick_Sound()
    {
        Singleton.Instance._player.GetComponent<NewPlayer>().kick_enemy_damage();
        Singleton.Instance._UI.GetComponent<UI>().audioSource.clip = Singleton.Instance._UI.GetComponent<UI>().Kick_sfx;
        Singleton.Instance._UI.GetComponent<UI>().audioSource.Play();
    }
    public void FootStep()
    {
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.Play();
    }

}
