using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [Header("���� ü�°�")]
    public int hp;
    [Header("�ʱ� ü�°�")]
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
            // �츮�� Destroy(������Ʈ) �Լ��� ����, �ش� ������Ʈ�� �ı��� �� �ֽ��ϴ�.
            Destroy(gameObject);
        }
    }
}
