using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int timer;
    void Start()
    {
        timer = 0;
        UIManager.Instance.SetTimer(timer);
        Invoke(nameof(AddTimer), 1f);
    }

    void AddTimer()
    {
        timer+=1;
        UIManager.Instance.SetTimer(timer);
        Invoke(nameof(AddTimer), 1f);
    }
}
