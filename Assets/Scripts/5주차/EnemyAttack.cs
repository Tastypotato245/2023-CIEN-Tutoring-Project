using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("���� ���ݷ�")]
    public int attack = 1;

    private void OnCollisionEnter2D(Collision2D collision)  // �� �Լ��� �ش� ������Ʈ�� Collider2D�� �ٸ� Collider2D�� �浹���� �� ����˴ϴ�.
    {
                                                            // collision.gameObject�� �浹�� ������Ʈ�� ������ �� �ֽ��ϴ�.
        if (collision.gameObject.name == "Player")          // gameObject.name���� �ش� ������Ʈ�� �̸��� ������ �� �ֽ��ϴ�.
        {
            // �츮�� gameObject.GetComponent<������Ʈ �̸�>() �Լ��� ����, �ش� ������Ʈ�� ������Ʈ�� ������ �� �ֽ��ϴ�.
            collision.gameObject.GetComponent<PlayerHP>().hp -= attack;
            Debug.Log("�÷��̾ �¾ҽ��ϴ�! �÷��̾��� ���� ü�� : " + collision.gameObject.GetComponent<PlayerHP>().hp);
        }
    }
}
