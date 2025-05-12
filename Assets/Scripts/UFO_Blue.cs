using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UFO_Blue : UFO
{
    [SerializeField] private Transform shield;

    private void ShieldRotation()
    {
        float y = Random.Range(-90f, 90f);
        float z = Random.Range(-45f, 45f);

        shield.rotation *= Quaternion.Euler(0, y, z);
    }

    private void Awake()
    {
        ShieldRotation();
    }

    private void FixedUpdate()
    {
        Move();
        EscapeCheck();
    }
}
