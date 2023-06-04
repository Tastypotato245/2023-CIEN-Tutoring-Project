using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb2D;
    public Bullet_Player bullet;

    //속성(변수) vs 기능(함수)

    public GameObject aimObject;
    public Transform firePos;

    public float speed = 5f;
    public float attackDelay = 0f;

    private int hp;
    public int HP
    {
        get
        {
            return hp;
        }
        set
        {
            if(value < hp)
            {
                AudioManager.Instance.PlaySFX("playerhit");
            }
            hp = value;
            UIManager_World.Instance.SetUI_HP(hp, maxHP);
            if(hp <= 0)
            {
                GameManager.Instance.IsGameOver = true;
                gameObject.SetActive(false);
            }
            if(hp > maxHP)
            {
                hp = maxHP;
            }
        }
    }

    public int maxHP = 5;

    Vector2 inputVector;
    Vector2 aimVector;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.GameState)
        {
            inputVector = new Vector2(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical"));

            if(inputVector.sqrMagnitude > 0)
            {
                animator.SetFloat("dirX", inputVector.x);
                animator.SetFloat("dirY", inputVector.y);
                animator.SetFloat("speed", inputVector.sqrMagnitude);
            }
            else
            {
                animator.SetFloat("speed", 0);
            }

            aimVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            aimObject.transform.rotation = Quaternion.Euler(0, 0, 
                Vector2.Angle(Vector2.right, aimVector) * (aimVector.y > 0 ? 1 : -1));

            if (Input.GetMouseButton(0) && attackDelay <= 0f)
            {
                Shoot(aimVector);
                attackDelay = 0.5f;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameManager.Instance.GameState = false;
            }

            if (attackDelay >= 0f)
            {
                attackDelay -= Time.deltaTime;
            }
        }
    }

    void Shoot(Vector2 direction)
    {
        Bullet_Player newBullet = Instantiate(bullet);
        newBullet.transform.position = firePos.position;
        newBullet.Shoot(direction);
    }

    private void FixedUpdate()
    {
        if (inputVector.sqrMagnitude > 0)
        {
            rb2D.velocity = inputVector.normalized * speed;
        }
        else
        {
            rb2D.velocity = Vector2.zero;
        }
    }
}
