using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Enemy : MonoBehaviour
{
    public void Shoot(Vector2 direction)
    {
        StartCoroutine(Routine(direction.normalized, 2f));
    }

    IEnumerator Routine(Vector2 direction, float speed)
    {
        float timer = 0f;
        while (timer < 10f)
        {
            transform.Translate(speed * Time.deltaTime * direction);
            timer += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().HP -= 1;
            StopAllCoroutines();
            Destroy(gameObject);
        }
    }
}
