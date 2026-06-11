using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSounds : MonoBehaviour
{
    public AudioSource IdleAudioSource;
    public AudioSource StepAudioSource;
    public AudioClip[] zombie_idles;
    public AudioClip[] zombie_walk;
    private float idleTimer = 0;
    private bool idleplaying = false;   
    public void playIdle()
    {
        IdleAudioSource.clip = zombie_idles[Random.Range(0, zombie_idles.Length)];
        IdleAudioSource.pitch = Random.Range(0.8f, 1.2f);
        IdleAudioSource.Play();
        idleTimer = IdleAudioSource.clip.length + Random.Range(0.5f, 2f);
        idleplaying = true;
    }

    public void playStep()
    {
        StepAudioSource.clip = zombie_walk[Random.Range(0, zombie_walk.Length)];
        StepAudioSource.pitch = Random.Range(0.8f, 1.2f);
        StepAudioSource.Play();
    }

    private void Update()
    {
        if (idleplaying)
        {
            idleTimer -= Time.deltaTime;
            if (idleTimer <= 0)
            {
                idleplaying = false;
            }
        }
        else
        {
            playIdle();
        }
    }
}
