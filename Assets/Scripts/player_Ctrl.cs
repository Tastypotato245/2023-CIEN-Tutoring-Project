using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Ctrl : MonoBehaviour
{
    public int hp = 4;

    [SerializeField] private Rigidbody2D _rigidbody2D;
    public float player_Speed = 5.0f;


    //공격 관련
    [SerializeField] private GameObject bullet_GO;
    private bool is_Attack_Delaying = false;
    public float delay_Time = 1.5f;


    //게임 매니저
    [SerializeField] private GameManager gameManager;

    private void FixedUpdate()
    {
        Move_Check();
        Attack_Check();
    }

    //상하좌우 이동 (w a s d) 
    private void Move_Check()
    {
        Vector2 temp=new Vector2(0,0);

        if (Input.GetKey(KeyCode.W))
            temp += Vector2.up * player_Speed * Time.fixedDeltaTime;
        if (Input.GetKey(KeyCode.A))
            temp += Vector2.left * player_Speed * Time.fixedDeltaTime;
        if (Input.GetKey(KeyCode.S))
            temp += Vector2.down * player_Speed * Time.fixedDeltaTime;
        if (Input.GetKey(KeyCode.D))
            temp += Vector2.right * player_Speed * Time.fixedDeltaTime;

        _rigidbody2D.MovePosition(_rigidbody2D.position + temp);
    }

    private void Attack_Check()
    {
        if (!is_Attack_Delaying && Input.GetMouseButton(0))
        {

            Vector2 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dir = (mousePos - (Vector2)transform.position).normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            GameObject go = Instantiate(bullet_GO, transform.position, Quaternion.Euler(0,0, angle));
            go.GetComponent<bullet>().attack_dir = dir;

            is_Attack_Delaying = true;
            Invoke("DelayTime", delay_Time);
        }
    }

    private void DelayTime()
    {
        is_Attack_Delaying = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster") )
        {
            hp--;
            if (hp == 0)
            {
                gameManager.End_Game();
            }
        }
        if (collision.CompareTag("HpPotion"))
        {
            hp++;
        }
        if (collision.CompareTag("DelayReduction"))
        {
            delay_Time *= 0.95f;
        }
    }

    
}
