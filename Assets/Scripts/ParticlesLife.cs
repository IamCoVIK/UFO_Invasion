using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesLife : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;

    private void Update()
    {
        if (!particles.IsAlive(false))
        {
            Destroy(gameObject);
        }
    }
}
