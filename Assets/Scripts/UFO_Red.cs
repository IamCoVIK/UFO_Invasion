using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class UFO_Red : UFO
{
    private int rotations = 0;
    private void RandomRotation()
    {
        int i = Random.Range(0, 100);
        if (i == 0 && rotations <= 3)
        {
            rotations++;

            float angle1 = Random.Range(-20f, 20f);
            float angle2 = Random.Range(-20f, 20f);
            transform.transform.rotation *= Quaternion.Euler(new Vector3(angle1, angle2));

            UpdateMove();
        }
    }

    private void FixedUpdate()
    {
        RandomRotation();
        Move();
        EscapeCheck();
    }
}
