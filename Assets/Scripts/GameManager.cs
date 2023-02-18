using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool isInProgress = false; //���� ������ ����������?


    [Header("���� ���� ������")]

    [SerializeField] private bool canBeSpawned = true; //���� ���� ������ ��������?

    public float first_SpawnDelayTime = 5.0f;             //inspector â���� ���� ������, ���� ���� ������ �ð�
    [SerializeField] private float spawnDelayTime;          //������ ���̴� spawnDelay �ð�.

    public int strongMonster_SpawnCycle = 5;            //������ ������ �����ֱ� : �� ���� �ѹ� �÷� ���� ���Ͱ� ������ �� ������ �����ϴ� ����. 
    [SerializeField] private int num = 0;               //

    [SerializeField] private GameObject player;   

    [Header("���� �����յ�")]

    [SerializeField] private GameObject monster_Basic;
    [SerializeField] private GameObject monster_Strong;

    [Header("�ð�")]
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
        if (num%strongMonster_SpawnCycle == 0) //num �� 5�� ����̸�
        {
            Instantiate(monster_Strong, Return_RandomPosition_Near_Player(), Quaternion.Euler(0, 0, 0));    //���� ���� ��ȯ
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


    private Vector2 Return_RandomPosition_Near_Player() //�÷��̾� �ֺ�(���� �Ÿ� �ٱ���) ���� �������� ��ȯ�ϴ� �Լ�
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
        spawnDelayTime = first_SpawnDelayTime; //monster_SpawnTime�� monster_SpawnTime_Setting�� �ð����� ������ (�ʱ�ȭ)
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
