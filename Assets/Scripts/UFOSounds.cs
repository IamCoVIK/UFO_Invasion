using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOSounds : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [Space]
    [SerializeField] private AudioClip idle;
    [SerializeField] private AudioClip escape;

    private void Start()
    {
        audioSource.clip = idle;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void EscapeSound()
    {
        audioSource.Stop();
        audioSource.clip = escape;
        audioSource.Play();
    }
}
