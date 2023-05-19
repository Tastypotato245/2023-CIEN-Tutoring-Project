using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Player : MonoBehaviour
{
    public void Shoot(Vector2 direction)
    {
        StartCoroutine(Routine(direction.normalized, 5f));
    }

    IEnumerator Routine(Vector2 direction, float speed)
    {
        float timer = 0f;
        while (timer < 3f)
        {
            transform.Translate(speed * Time.deltaTime * direction);
            timer += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            
            if (collision.GetComponent<Enemy_����>())
            {
                collision.GetComponent<Enemy_����>().Dead();
            }
            if (collision.GetComponent<Enemy_���Ÿ�>())
            {
                collision.GetComponent<Enemy_���Ÿ�>().Dead();
            }
            Destroy(collision.gameObject);
            StopAllCoroutines();
            Destroy(gameObject);
        }
    }
}
