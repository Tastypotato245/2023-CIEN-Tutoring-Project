using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_근접 : MonoBehaviour
{
    public Rigidbody2D rb2D;

    public float speed = 2f;
    public int score = 100;

    Vector2 inputVector;

    // Update is called once per frame
    void Update()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        if (target != null)
        {
            inputVector = target.transform.position - transform.position;
        }
        else
        {
            inputVector = Vector2.zero;
        }
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
