using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("총알의 속도입니다.")]
    public float speed = 8f;
    [Header("이만큼 시간이 지나면 총알이 사라져요.")]
    public float timer = 5f;

    public void Shoot(Vector2 direction)
    {
        StartCoroutine(MoveRoutine(direction));
    }

    IEnumerator MoveRoutine(Vector2 direction)
    {
        float deltaTime = 0;
        while (deltaTime < timer)
        {
            deltaTime += Time.deltaTime;
            transform.Translate(speed * Time.deltaTime * direction);
            yield return null;
        }
        Destroy(gameObject);
    }
}
