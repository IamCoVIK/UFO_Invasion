using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSounds : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip intro;
    [SerializeField] private AudioClip idle;
    [SerializeField] private AudioClip spawn;
    [SerializeField] private AudioSource audioSource1;

    private bool spawned = false;

    private void Start()
    {
        audioSource.clip = intro;
        audioSource.Play();
        spawned = true;
        audioSource1.loop = false;
    }

    private void Update()
    {
        if (spawned)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = idle;
                audioSource.Play();
                audioSource.loop = true;
            }
        }
    }

    public void SpawnedUFO()
    {
        audioSource1.Play();
    }
}
