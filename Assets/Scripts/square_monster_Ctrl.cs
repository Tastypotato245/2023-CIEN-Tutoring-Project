using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;



public class Square_monster_Ctrl : MonoBehaviour
{
    //item 
    [Header("Item 관련")]
    [SerializeField] private GameObject hpPotion;
    [SerializeField] private GameObject delayReduction;
    public int hpPotion_SpawnChance = 3;
    public int delayReduction_SpawnChance = 10;


    [Header("그 외")]
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private GameObject player;

    public int hp = 1;

    public Vector2 target_Dir;
    public float move_Speed = 2.0f;

    private void Awake()  
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        target_Dir = (player.transform.position - this.transform.position).normalized;
        _rigidbody2D.MovePosition(_rigidbody2D.position + target_Dir * move_Speed * Time.fixedDeltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Attack_Object") || collision.CompareTag("Player"))
        {
            hp--; 
            if (hp == 0)
            {
                Spawn_Item();
                Destroy(this.gameObject);
            }
        }
    }


    private void Spawn_Item() //사망시 일정 확률로 아이템 드롭
    {
        int i = Random.Range(0,100);

        if (0 <= i && i < hpPotion_SpawnChance)
            Instantiate(hpPotion, transform.position, Quaternion.Euler(Vector3.zero));
        else if (hpPotion_SpawnChance <= i && i < hpPotion_SpawnChance+delayReduction_SpawnChance)
            Instantiate(delayReduction, transform.position, Quaternion.Euler(Vector3.zero));
    }
}
