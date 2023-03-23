using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeltaTimeChecker : MonoBehaviour
{
    [Header("몇 초 동안 측정할 것인지 정합니다.")]
    public float time = 3f;

    private float timer;
    private float value;
    private float dValue;
    private bool isEnd = false;

    private void Start()
    {
        timer = 0f;
        value = 0f;
        dValue = 0f;
    }

    void Update()
    {
        if (timer < time)
        {
            value += 1;
            dValue += 1 * Time.deltaTime;
            timer += Time.deltaTime;
        }
        else
        {
            if(isEnd == false)
            {
                isEnd = true;
                Debug.Log(
                    timer + " 초가 지났습니다.\n" +
                    "DeltaTime을 사용한 측정값은 " + dValue + "입니다. DeltaTime을 사용하지 않은 측정값은 " + value + " 입니다.");
            }
        }
    }
}
