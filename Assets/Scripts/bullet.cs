using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;

    public float speed = 5;
    public float flying_Time = 2.5f;

    public Vector2 attack_dir;


    private void Start()
    {
        Invoke("Destroy_Self", flying_Time);
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + attack_dir*speed * Time.fixedDeltaTime);
    }


    private void Destroy_Self()
    {
        Destroy(this.gameObject);
    }
}