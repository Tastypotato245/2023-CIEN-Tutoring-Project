using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// �� ������Ʈ�� �÷��̾ ������ �� �ְ� �ϴ� ����� �߰��մϴ�.
// ������Ʈ�� �ش� ������Ʈ�� � ����� �߰��ϴ� ����Դϴ�.
public class PlayerMove : MonoBehaviour
{
    [Header("�����̴� �ӵ�")]
    public float speed = 5f;

    void Update()           // �� �Լ��� ������ �� �����Ӹ��� ����Ǵ� �Լ��Դϴ�.
    {
        // �츮�� ��ũ��Ʈ�� �ۼ��� ��, Input.GetKey(KeyCode.[Ű]) ��� ������ ���� �ش� Ű�� �����ִ��� Ȯ���� �� �־��.
        if (Input.GetKey(KeyCode.W))
        {
            // W Ű�� ������ �� �κ��� �����ؿ�.
            MoveObjectToUp();       // �� �κ��� ������Ʈ�� ���� ��������.
        }
        if (Input.GetKey(KeyCode.S))
        {
            // S Ű�� ������ �� �κ��� �����ؿ�.
            MoveObjectToDown();     // �� �κ��� ������Ʈ�� �Ʒ��� ��������.
        }
        if (Input.GetKey(KeyCode.A))
        {
            // A Ű�� ������ �� �κ��� �����ؿ�.
            MoveObjectToLeft();     // �� �κ��� ������Ʈ�� �������� ��������.
        }
        if (Input.GetKey(KeyCode.D))
        {
            // D Ű�� ������ �� �κ��� �����ؿ�.
            MoveObjectToRight();    // �� �κ��� ������Ʈ�� ���������� ��������.
        }
    }

    private void MoveObjectToLeft()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.left);
    }

    private void MoveObjectToRight()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.right);
    }

    private void MoveObjectToUp()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.up);
    }

    private void MoveObjectToDown()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.down);
    }

}
