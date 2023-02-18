using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool isInProgress = false; //지금 게임이 진행중인지?


    [Header("스폰 관련 변수들")]

    [SerializeField] private bool canBeSpawned = true; //지금 스폰 가능한 상태인지?

    public float first_SpawnDelayTime = 5.0f;             //inspector 창에서 설정 가능한, 몬스터 스폰 딜레이 시간
    [SerializeField] private float spawnDelayTime;          //실제로 쓰이는 spawnDelay 시간.

    public int strongMonster_SpawnCycle = 5;            //강력한 몬스터의 스폰주기 : 몇 번에 한번 꼴로 강한 몬스터가 나오게 할 것인지 설정하는 숫자. 
    [SerializeField] private int num = 0;               //

    [SerializeField] private GameObject player;   

    [Header("몬스터 프리팹들")]

    [SerializeField] private GameObject monster_Basic;
    [SerializeField] private GameObject monster_Strong;

    [Header("시간")]
    [SerializeField] private Timer timer;

    private void FixedUpdate()
    {
        Check_MonsterSpawn();
    }

    private void Check_MonsterSpawn()
    {
        if (isInProgress && canBeSpawned)
        {
            canBeSpawned = false;
            Invoke("Spawn_Monster", spawnDelayTime);
        }
    }

    private void Spawn_Monster()
    {
        num++;
        if (num%strongMonster_SpawnCycle == 0) //num 이 5의 배수이면
        {
            Instantiate(monster_Strong, Return_RandomPosition_Near_Player(), Quaternion.Euler(0, 0, 0));    //강한 몬스터 소환
        }
        else
        {
            Instantiate(monster_Basic, Return_RandomPosition_Near_Player(), Quaternion.Euler(0, 0, 0));
        }

        if (spawnDelayTime > 0.05f)
        {
            spawnDelayTime = spawnDelayTime - 1.0f/num;
        }
        canBeSpawned = true;
    }


    private Vector2 Return_RandomPosition_Near_Player() //플레이어 주변(일정 거리 바깥의) 랜덤 포지션을 반환하는 함수
    {
        int r = Random.Range(0,4);
        Vector2 pos = new Vector2(0,0);

        if(r == 0)
            pos = new Vector2(Random.Range(-15.0f, 15.0f), 10f);     //Up Side
        else if(r == 1)
            pos = new Vector2(Random.Range(-15.0f, 15.0f), -10f);    //Down Side
        else if(r == 2)
            pos = new Vector2(15.0f, Random.Range(-10f, 10f));     //Right Side
        else if(r == 3)
            pos = new Vector2(-15.0f, Random.Range(-10f, 10f));    //Left Side

        return (Vector2)(player.transform.position)+pos;
    }

    public void Start_Game()
    {
        isInProgress = true;
        timer.isInProgress = isInProgress;
        spawnDelayTime = first_SpawnDelayTime; //monster_SpawnTime을 monster_SpawnTime_Setting의 시간으로 변경함 (초기화)
    }

    public void End_Game() //
    {
        isInProgress = false;
        timer.isInProgress = isInProgress;

        Time.timeScale = 0;
    }

    public void Reset_Game()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Ingame");
    }
}
