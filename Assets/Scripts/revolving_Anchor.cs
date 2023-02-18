using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class revolving_Anchor : MonoBehaviour
{
    public float speed = 1;

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, speed);
    }
}