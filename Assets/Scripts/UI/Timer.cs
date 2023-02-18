using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text timeInterface;

    private float time = 0.0f;

    public bool isInProgress = false;


    private void FixedUpdate()
    {
        timeInterface.text = string.Format("{0:0.0}", time);
        if (isInProgress)
        {
            time += Time.fixedDeltaTime;
        }
    }
}
