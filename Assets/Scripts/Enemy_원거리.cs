using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_원거리 : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public Collider2D attackArea;
    public ContactFilter2D attackFilter;

    public Bullet_Enemy bullet;

    public float speed = 2f;
    public float attackDelay = 0f;
    public int score = 100;

    Vector2 inputVector;

    // Update is called once per frame
    void Update()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        if (target != null)
        {
            inputVector = target.transform.position - transform.position;
            List<Collider2D> results = new List<Collider2D>();
            if (Physics2D.OverlapCollider(attackArea, attackFilter, results) > 1)
            {
                for (int i = 0; i < results.Count; i++)
                {
                    if (results[i].CompareTag("Player"))
                    {
                        // 총알을 쏜다.
                        if (attackDelay <= 0f)
                        {
                            Shoot(results[i].transform.position - transform.position);
                            attackDelay = 2f;
                        }
                        inputVector = Vector2.zero;
                    }
                }
            }
        }
        else
        {
            inputVector = Vector2.zero;
        }

        if (attackDelay >= 0f)
        {
            attackDelay -= Time.deltaTime;
        }
    }

    void Shoot(Vector2 direction)
    {
        Bullet_Enemy newBullet = Instantiate(bullet);
        newBullet.transform.position = transform.position;
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

    public void Dead()
    {
        GameManager.Instance.Score += score * GameManager.Instance.Stage;
        AudioManager.Instance.PlaySFX("enemydie", transform.position);
    }
}
