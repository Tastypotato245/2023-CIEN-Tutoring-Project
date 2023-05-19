using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] spawnableObject;

    private void Start()
    {
        GameManager.Instance.onSpawn += Spawn;
    }

    private void Spawn()
    {
        if (gameObject.activeInHierarchy)
        {
            GameObject newObject = Instantiate(spawnableObject[Random.Range(0, spawnableObject.Length)]);
            newObject.transform.position = transform.position;
        }
    }

}
