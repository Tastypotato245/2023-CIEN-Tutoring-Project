using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [Header("�����̴� �ӵ�")]
    public float speed = 1f;
    [Header("��ǥ�� �� ���")]
    public GameObject target;


    void Start()                                // �� �Լ��� ������ ����� ��, �� �ѹ��� ����˴ϴ�.
    {
                                                // �츮�� ��ũ��Ʈ�� �ۼ��� ��, GameObject.Find("�̸�") �Լ��� ���� "�̸�"�� �̸����� �ϴ� ������Ʈ�� ã�� �� �־��.
        target = GameObject.Find("Player");     // ������ ��ǥ�� "Player"�� �̸����� �ϴ� ������Ʈ�� ���ؿ�.
    }

    void Update()                               // �� �Լ��� ������ �� �����Ӹ��� ����Ǵ� �Լ��Դϴ�.
    {
        MoveToTarget();                         // �� �κ��� ������Ʈ�� ��ǥ�� �� ��󿡰� ��������.
    }

    void MoveToTarget()
    {
        if (target != null)
        {
            Vector2 direction = (target.transform.position - transform.position).normalized;
            transform.Translate(speed * Time.deltaTime * direction);
        }
    }

}
