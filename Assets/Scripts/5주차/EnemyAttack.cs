using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("적의 공격력")]
    public int attack = 1;

    private void OnCollisionEnter2D(Collision2D collision)  // 이 함수는 해당 오브젝트의 Collider2D에 다른 Collider2D가 충돌했을 때 실행됩니다.
    {
                                                            // collision.gameObject로 충돌한 오브젝트를 가져올 수 있습니다.
        if (collision.gameObject.name == "Player")          // gameObject.name으로 해당 오브젝트의 이름을 가져올 수 있습니다.
        {
            // 우리는 gameObject.GetComponent<컴포넌트 이름>() 함수를 통해, 해당 오브젝트의 컴포넌트를 가져올 수 있습니다.
            collision.gameObject.GetComponent<PlayerHP>().hp -= attack;
            Debug.Log("플레이어가 맞았습니다! 플레이어의 남은 체력 : " + collision.gameObject.GetComponent<PlayerHP>().hp);
        }
    }
}
