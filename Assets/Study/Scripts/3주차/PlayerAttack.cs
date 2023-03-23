using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 이 컴포넌트는 플레이어가 공격을 할 수 있게 하는 기능을 추가합니다.
public class PlayerAttack : MonoBehaviour
{
    public Bullet bullet;
    [Header("다음 총알을 쏠 수 있을 때까지의 간격")]
    public float cooldown = .25f;

    private float timer = 0f;

    void Update()
    {
        // 우리는 스크립트를 작성할 때, Input.GetMouseButton(0) 이라는 문장을 통해 마우스 왼쪽 버튼이 눌렸는지 확인할 수 있어요.
        if (Input.GetMouseButton(0))
        {
            if (timer <= 0)
            {
                // 마우스 왼쪽 버튼이 눌리면 이 부분을 실행해요.
                Shoot();    // 이 부분은 마우스 커서를 향해 총알을 발사해요.
                timer = cooldown;
            }
        }

        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }


    void Shoot()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouseDirection = mousePosition - transform.position;
        Bullet newBullet = Instantiate(bullet);
        newBullet.transform.position = transform.position;
        newBullet.Shoot(mouseDirection.normalized);
    }
}
