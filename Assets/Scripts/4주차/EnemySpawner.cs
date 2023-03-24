using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("������ ������Ʈ")]
    public GameObject spawnableObject;
    [Header("������Ʈ�� ������ ����")]
    public float spawnInterval = 5f;

    private float timer = 0f;
    void Update()
    {
        // �츮�� ��ũ��Ʈ�� �ۼ��� ��, Instantiate(������Ʈ) �Լ��� ���� ������Ʈ�� ������ �� �־��.
        // Instantiate �Լ��� ���� ���� ���°� �ִµ�, ���⼭ ����� �Լ��� Instantiate(������Ʈ, ��ġ, ȸ����) �Դϴ�.
        // �� ������ �Լ��� �ش� ������Ʈ�� �ش� ��ġ�� �ش� ȸ�������� �����մϴ�.
        if(timer <= 0f)
        {
            timer = spawnInterval;
            Instantiate(spawnableObject, transform.position, Quaternion.identity);
        }
        timer -= Time.deltaTime;
    }
}
