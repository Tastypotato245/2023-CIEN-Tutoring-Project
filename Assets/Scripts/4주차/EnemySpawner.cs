using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("생성할 오브젝트")]
    public GameObject spawnableObject;
    [Header("오브젝트를 생성할 간격")]
    public float spawnInterval = 5f;

    private float timer = 0f;
    void Update()
    {
        // 우리는 스크립트를 작성할 때, Instantiate(오브젝트) 함수를 통해 오브젝트를 복제할 수 있어요.
        // Instantiate 함수는 여러 가지 형태가 있는데, 여기서 사용한 함수는 Instantiate(오브젝트, 위치, 회전값) 입니다.
        // 이 형태의 함수는 해당 오브젝트를 해당 위치에 해당 회전값으로 복제합니다.
        if(timer <= 0f)
        {
            timer = spawnInterval;
            Instantiate(spawnableObject, transform.position, Quaternion.identity);
        }
        timer -= Time.deltaTime;
    }
}
