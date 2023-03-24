using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;       // UI를 사용하려면 이 문장을 적어줘야 합니다.

public class UIManager : MonoBehaviour
{
    // 우리가 스크립트를 작성하다 보면, 어떠한 오브젝트에서도 사용하고 싶은 오브젝트가 있을 수 있습니다.
    public static UIManager Instance { get; private set; } = null;

    private void Awake()
    {
        Instance = this;
    }

    [Header("HP를 표현할 이미지")]
    public Image image_HP;
    [Header("시간을 표현할 텍스트")]
    public Text text_Timer;
    [Header("게임 오버 UI")]
    public GameObject ui_GameOver;

    public void SetTimer(int value)             // 타이머 UI를 해당 값으로 표시합니다.
    {
        if (text_Timer != null)
        {
            text_Timer.text = $"{value}";
        }
    }

    public void SetHP(int nowHP, int maxHP)     // HP UI를 해당 값으로 표시합니다.
    {
        if (image_HP != null)
        {
            image_HP.fillAmount = (float)nowHP / maxHP;
        }
    }

    public void SetGameOver()
    {
        if(ui_GameOver != null)
        {
            ui_GameOver.SetActive(true);
        }
    }

}
