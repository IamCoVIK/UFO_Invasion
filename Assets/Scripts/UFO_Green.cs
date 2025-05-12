using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO_Green : UFO
{
    private void FixedUpdate()
    {
        Move();
        EscapeCheck();
    }
}
