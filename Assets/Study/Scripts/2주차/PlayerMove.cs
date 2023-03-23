using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 이 컴포넌트는 플레이어가 움직일 수 있게 하는 기능을 추가합니다.
// 컴포넌트는 해당 오브젝트에 어떤 기능을 추가하는 요소입니다.
public class PlayerMove : MonoBehaviour
{
    [Header("움직이는 속도")]
    public float speed = 5f;

    void Update()           // 이 함수는 게임의 매 프레임마다 실행되는 함수입니다.
    {
        // 우리는 스크립트를 작성할 때, Input.GetKey(KeyCode.[키]) 라는 문장을 통해 해당 키가 눌려있는지 확인할 수 있어요.
        if (Input.GetKey(KeyCode.W))
        {
            // W 키를 누르면 이 부분을 실행해요.
            MoveObjectToUp();       // 이 부분은 오브젝트를 위로 움직여요.
        }
        if (Input.GetKey(KeyCode.S))
        {
            // S 키를 누르면 이 부분을 실행해요.
            MoveObjectToDown();     // 이 부분은 오브젝트를 아래로 움직여요.
        }
        if (Input.GetKey(KeyCode.A))
        {
            // A 키를 누르면 이 부분을 실행해요.
            MoveObjectToLeft();     // 이 부분은 오브젝트를 왼쪽으로 움직여요.
        }
        if (Input.GetKey(KeyCode.D))
        {
            // D 키를 누르면 이 부분을 실행해요.
            MoveObjectToRight();    // 이 부분은 오브젝트를 오른쪽으로 움직여요.
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
