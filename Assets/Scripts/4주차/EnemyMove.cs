using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [Header("움직이는 속도")]
    public float speed = 1f;
    [Header("목표로 할 대상")]
    public GameObject target;


    void Start()                                // 이 함수는 게임이 실행될 때, 딱 한번만 실행됩니다.
    {
                                                // 우리는 스크립트를 작성할 때, GameObject.Find("이름") 함수를 통해 "이름"을 이름으로 하는 오브젝트를 찾을 수 있어요.
        target = GameObject.Find("Player");     // 움직일 목표를 "Player"를 이름으로 하는 오브젝트로 정해요.
    }

    void Update()                               // 이 함수는 게임의 매 프레임마다 실행되는 함수입니다.
    {
        MoveToTarget();                         // 이 부분은 오브젝트를 목표로 한 대상에게 움직여요.
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
