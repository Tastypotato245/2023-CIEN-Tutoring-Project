using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } = null;

    private int score = 0;
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            UIManager_World.Instance.SetUI_Score(score);
        }
    }
    private int stage = 0;
    public int Stage
    {
        get
        {
            return stage;
        }
        set
        {
            stage = value;
            UIManager_World.Instance.SetUI_Stage(stage);
        }
    }

    private bool gameState = true;
    public bool GameState
    {
        get
        {
            return gameState;
        }
        set
        {
            gameState = value;
            Time.timeScale = gameState ? 1 : 0;
            UIManager_World.Instance.SetUI_Pause(!gameState);
        }
    }

    private bool isGameOver = false;
    public bool IsGameOver
    {
        get
        {
            return isGameOver;
        }
        set
        {
            isGameOver = value;
            if (isGameOver)
            {
                StopAllCoroutines();
                PlayerPrefs.SetInt("Score", 0);
                PlayerPrefs.SetInt("Stage", 1);
                AudioManager.Instance.StopBGM();
                UIManager_World.Instance.SetUI_GameOver(true);
            }
        }
    }

    public Action onSpawn;

    public GameObject[] spawnerGroup;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Score = PlayerPrefs.GetInt("Score", 0);
        Stage = PlayerPrefs.GetInt("Stage", 1);
        GameState = true;
        AudioManager.Instance.PlayBGM("worldBGM");
        StartCoroutine(Routine());
    }

    public void SaveStatus()
    {
        PlayerPrefs.SetInt("Score", Score);
        PlayerPrefs.SetInt("Stage", Stage);
    }

    IEnumerator Routine()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        while (true)
        {
            int spawnCount = Stage;

            player.HP = player.maxHP;

            if (Stage == 1)
            {
                spawnerGroup[0].SetActive(true);
                spawnerGroup[1].SetActive(false);
                spawnerGroup[2].SetActive(false);
            }
            else if (Stage == 2)
            {
                spawnerGroup[0].SetActive(false);
                spawnerGroup[1].SetActive(true);
                spawnerGroup[2].SetActive(false);
            }
            else if (Stage == 3)
            {
                spawnerGroup[0].SetActive(false);
                spawnerGroup[1].SetActive(false);
                spawnerGroup[2].SetActive(true);
            }
            else if (Stage == 4)
            {
                spawnerGroup[0].SetActive(true);
                spawnerGroup[1].SetActive(true);
                spawnerGroup[2].SetActive(false);
            }
            else if (Stage == 5)
            {
                spawnerGroup[0].SetActive(false);
                spawnerGroup[1].SetActive(true);
                spawnerGroup[2].SetActive(true);
            }
            else if (Stage == 6)
            {
                spawnerGroup[0].SetActive(true);
                spawnerGroup[1].SetActive(false);
                spawnerGroup[2].SetActive(true);
            }
            else
            {
                spawnerGroup[0].SetActive(true);
                spawnerGroup[1].SetActive(true);
                spawnerGroup[2].SetActive(true);
            }

            yield return new WaitForSeconds(5f);
            for(int i = 0; i < spawnCount; ++i)
            {
                onSpawn?.Invoke();
                yield return new WaitForSeconds(2f);
            }
            yield return new WaitUntil(() => GameObject.FindGameObjectsWithTag("Enemy").Length <= 0);
            AudioManager.Instance.PlaySFX("levelcomplete");
            Score += 1000 * Stage;
            yield return new WaitForSeconds(10f);
            Stage++;
        }
    }
}
