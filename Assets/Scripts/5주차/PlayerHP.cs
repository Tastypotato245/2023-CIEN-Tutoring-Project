using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [Header("현재 체력값")]
    public int hp;
    [Header("초기 체력값")]
    public int maxHP = 5;

    void Start()
    {
        hp = maxHP;
    }

    void Update()
    {
        if (UIManager.Instance != null)
        {
            UIManager.Instance.SetHP(hp, maxHP);
            if (hp <= 0)
            {
                UIManager.Instance.SetGameOver();
            }
        }

        if (hp <= 0)
        {
            // 우리는 Destroy(오브젝트) 함수를 통해, 해당 오브젝트를 파괴할 수 있습니다.
            Destroy(gameObject);
        }
    }
}
